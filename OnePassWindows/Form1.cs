using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Form1()
        {
            InitializeComponent();
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

        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MemoryPasswordTb.Text) || String.IsNullOrEmpty(CodeTb.Text))
            {
                return;
            }

            processCopy();
        }

        private void processCopy()
        {
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
            form.ShowDialog();
        }
    }
}
