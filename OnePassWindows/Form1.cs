using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnePassWindows
{
    public partial class Form1 : Form
    {
        private String mGenerateCode;
        private bool mIsRememberPassword;

        public Form1()
        {
            InitializeComponent();
            mIsRememberPassword = ConfigurationManager.AppSettings["remember_password"] == "1";
            if (mIsRememberPassword)
            {
                MemoryPasswordTb.Text = ConfigurationManager.AppSettings["memory_password"];
            }

            setShowPassword();
        }

        private void setShowPassword()
        {
            bool isShowPassword = ConfigurationManager.AppSettings["show_password"] == "1";
            MemoryPasswordTb.PasswordChar = isShowPassword ? '\0' : '*';
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            updateCode();
        }

        private void CodeTb_TextChanged(object sender, EventArgs e)
        {
            updateCode();
        }

        private void updateCode()
        {
            if (String.IsNullOrEmpty(MemoryPasswordTb.Text) || String.IsNullOrEmpty(CodeTb.Text))
            {
                CopyBtn.Text = "密码生成区(点击复制)";
            }
            else
            {
                try
                {
                    mGenerateCode = PasswordCore.encrypt(MemoryPasswordTb.Text, CodeTb.Text);
                    CopyBtn.Text = mGenerateCode;
                    //  CopyBtn.Text = MyHmac.CreateToken("1","1");
                }
                catch (Exception e)
                {
                    CopyBtn.Text = "密码生成区(点击复制)";
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (mIsRememberPassword)
            {
                CodeTb.TabIndex = 1;
            }

        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MemoryPasswordTb.Text) || String.IsNullOrEmpty(CodeTb.Text))
            {
                return;
            }

            String oldPassword = ConfigurationManager.AppSettings["memory_password"];
            if (!String.IsNullOrEmpty(oldPassword) && oldPassword != MemoryPasswordTb.Text)
            {
                MessageBox.Show("您此次输入的记忆密码与最近一次输入的记忆密码不同，请检查一下输入是否正确。我们建议使用相同的记忆密码，以避免出现忘记密码、记忆混乱的问题。");
            }

            processCopy();
        }

        private void processCopy()
        {
            String oldPassword = ConfigurationManager.AppSettings["memory_password"];
            if (String.IsNullOrEmpty(oldPassword) || oldPassword != MemoryPasswordTb.Text)
            {
                saveParameter("memory_password", MemoryPasswordTb.Text);
            }

            Clipboard.SetDataObject(mGenerateCode);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //调用系统默认的浏览器 
            System.Diagnostics.Process.Start("https://github.com/kaku2015/OnePassWindows/blob/master/donate/donate.md");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kaku2015/OnePassWindows");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parameter form = new parameter();
            form.DataChange += new parameter.DataChangeHandler(DataChanged);
            form.ShowDialog();
        }

        public void DataChanged(object sender, DataChangeEventArgs args)
        {
            if ( 0  == args.mType)
            {
                updateCode();
            } else if (1 == args.mType) {
                setShowPassword();
            }
        }

        private void saveParameter(String name, String value)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings[name].Value = value;
            cfg.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
