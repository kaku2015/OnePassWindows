using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace OnePassWindows
{
    public partial class enter_tv : Form
    {
        private String mGenerateCode;
        private bool mIsRememberPassword;
        private ResourceManager resourceManager;
        private bool isEn = true;

        public enter_tv()
        {
            InitializeComponent();


            if (isEn)
            {
                resourceManager = new ResourceManager(
                Resource.ResourceManager.BaseName, Assembly.GetExecutingAssembly());
            }
            else
            {
                resourceManager = new ResourceManager(
                Resource_zh_CN.ResourceManager.BaseName, Assembly.GetExecutingAssembly());
            }
            //只需修改str的值就可以获取不同的语言
            //  string str = "zh-CN";//CultureInfo.CurrentUICulture.Name;
            //en-US    zh-CN
            //  System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(str);


            mIsRememberPassword = ConfigurationManager.AppSettings["remember_password"] == "1";
            if (mIsRememberPassword)
            {
                MemoryPasswordTb.Text = ConfigurationManager.AppSettings["memory_password"];
            }

            setShowPassword();


            input.Text = resourceManager.GetString("input");
            get_tv.Text = resourceManager.GetString("get");
            memory_password_tv.Text = resourceManager.GetString("memory_password");
            code_tv.Text = resourceManager.GetString("code_number");
            memory_password_msg_tv.Text = resourceManager.GetString("use_explanation1");
            code_mag_tv.Text = resourceManager.GetString("use_explanation2");
            strong_password_tv.Text = resourceManager.GetString("strong_password");
            CopyBtn.Text = resourceManager.GetString("code_generate_area");
            settings_tv.Text = resourceManager.GetString("setting");
            open_source_ltv.Text = resourceManager.GetString("open_source");

            if (isEn)
            {
                donate_btn.Visible = false;
                wechat_iv.Visible = false;
                alipay_iv.Visible = false;
                qq_iv.Visible = false;
            }
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
                CopyBtn.Text = resourceManager.GetString("code_generate_area");
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
                    CopyBtn.Text = resourceManager.GetString("code_generate_area");
                    MessageBox.Show(e.Message + ": " + e.InnerException);
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
                MessageBox.Show(resourceManager.GetString("different_password_msg"));            }

            processCopy();
        }

        private void processCopy()
        {
            String oldPassword = ConfigurationManager.AppSettings["memory_password"];
            if (String.IsNullOrEmpty(oldPassword) || oldPassword != MemoryPasswordTb.Text)
            {
                if (mIsRememberPassword)
                {
                    saveParameter("memory_password", MemoryPasswordTb.Text);
                }
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
            if (isEn)
            {
                System.Diagnostics.Process.Start("https://github.com/kaku2015/OnePassWindows/tree/master/OnePassWindows");
            }
            else
            {
                System.Diagnostics.Process.Start("https://github.com/kaku2015/OnePassWindows");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parameter form = new parameter();
            form.DataChange += new parameter.DataChangeHandler(DataChanged);
            form.ShowDialog();
        }

        public void DataChanged(object sender, DataChangeEventArgs args)
        {
            if (0 == args.mType)
            {
                updateCode();
            }
            else if (1 == args.mType)
            {
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
