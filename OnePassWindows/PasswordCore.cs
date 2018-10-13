using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OnePassWindows
{
    class PasswordCore
    {

        public static String encrypt(String passwordText, String codeText)
        {
            if (passwordText == "" || codeText == "")
            {
                return "";
            }
            try
            {
                String encryptOne = hmacSHA256(passwordText, codeText);
                Debug.Print("encryptOne: " + encryptOne);
                String encryptTwo = hmacSHA256(encryptOne, PasswordUtil.getKeyPassword());
                Debug.Print("encryptTwo: " + encryptTwo);
                StringBuilder result = new StringBuilder(encryptTwo);

                if (ConfigurationManager.AppSettings["with_symbol"] == "1")
                {
                    processSomeCharToCharacter(encryptTwo, result);
                }
                processSomeCharToNumber(result);
                if (ConfigurationManager.AppSettings["first_capital_letter"] == "1")
                {
                    processFirstCapitalLetterToUpperCase(result);
                }

                String code32 = result.ToString();
                String code16;
                int passwordLength = int.Parse(ConfigurationManager.AppSettings["password_length"]);
                code16 = code32.Substring(0, passwordLength);
                return code16;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured while encrypting password " + passwordText + " with code " + codeText, e);
            }
        }

        private static void processSomeCharToNumber(StringBuilder source)
        {
            for (int i = 0; i <= 31; ++i)
            {
                if ('+' == (source[i]) ||
                        '/' == (source[i]))
                {
                    //                KLog.w("+ / occurs");
                    source[i] = '6';
                }
            }
        }

        private static void processSomeCharToCharacter(String encryptTwo, StringBuilder source)
        {
            for (int i = 1; i <= 31; ++i)
            {
                if (!Char.IsNumber(source[i]))
                {
                    switch (encryptTwo[i])
                    {
                        case 'a':
                        case 'A':
                            source[i] = '!';
                            break;
                        case 'e':
                        case 'E':
                            source[i] = '@';
                            break;
                        case 'i':
                        case 'I':
                            source[i] = '#';
                            break;
                        case 'm':
                        case 'M':
                            source[i] = '$';
                            break;
                        case 'q':
                        case 'Q':
                            source[i] = '%';
                            break;
                        case 'u':
                        case 'U':
                            source[i] = '^';
                            break;
                        case 'y':
                        case 'Y':
                            source[i] = '&';
                            break;
                        case 'z':
                            source[i] = '*';
                            break;
                    }
                }
            }
        }

        private static void processFirstCapitalLetterToUpperCase(StringBuilder result)
        {
            char code1 = result[0];
            if (Char.IsNumber(code1))
            {
                result[0] = 'M';
            }
            else if (Char.IsLower(code1))
            {
                result[0] = Char.ToUpper(code1);
            }
        }

        public static string hmacSHA256(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] messageBytes = encoding.GetBytes(message);
            byte[] keyBytes = encoding.GetBytes(secret);
            using (var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyBytes))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage, Base64FormattingOptions.InsertLineBreaks) + "\n";
            }
        }
    }
}
