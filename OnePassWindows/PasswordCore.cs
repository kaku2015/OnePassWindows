using System;
using System.Collections.Generic;
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

                processSomeCharToNumber(result);

                String code32 = result.ToString();
                String code16;
                int passwordLength = 16;
                code16 = code32.Substring(0, passwordLength);
                return code16;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format(
                        "Error occured while encrypting password \"%s\" with key \"%s\"", passwordText, codeText), e);
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
