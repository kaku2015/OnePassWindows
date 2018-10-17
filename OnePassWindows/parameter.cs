using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Resources;
using System.Reflection;

namespace OnePassWindows
{
    public partial class parameter : Form
    {
        // 定义委托
        // public delegate void DataChangeHandler(string x); 一次可以传递一个string
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        // 声明事件
        public event DataChangeHandler DataChange;

        // 调用事件函数
        public void OnDataChange(object sender, DataChangeEventArgs args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        private ResourceManager resourceManager;
        private bool isEn = true;
        public parameter()
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

            with_symbol_cb.Checked = ConfigurationManager.AppSettings["with_symbol"] == "1";
            first_capital_letter_cb.Checked = ConfigurationManager.AppSettings["first_capital_letter"] == "1";
            remember_password_cb.Checked = ConfigurationManager.AppSettings["remember_password"] == "1";
            show_password_cb.Checked = ConfigurationManager.AppSettings["show_password"] == "1";

           password_length_tb.Value = int.Parse(ConfigurationManager.AppSettings["password_length"]);
            password_length_tv.Text = resourceManager.GetString("password_length_value") + ConfigurationManager.AppSettings["password_length"] + "]";
            with_symbol_cb.Text = resourceManager.GetString("with_character");
            first_capital_letter_cb.Text = resourceManager.GetString("first_capital_letter");
            remember_password_cb.Text = resourceManager.GetString("remember_password");
            show_password_cb.Text = resourceManager.GetString("show_password");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            saveParameter("first_capital_letter", first_capital_letter_cb.CheckState == CheckState.Checked ? "1" : "0");
            OnDataChange(this, new DataChangeEventArgs(0));
        }

        private void parameter_Load(object sender, EventArgs e)
        {

        }

        private void with_symbol_CheckedChanged(object sender, EventArgs e)
        {
            saveParameter("with_symbol", with_symbol_cb.CheckState == CheckState.Checked ? "1" : "0");
            OnDataChange(this, new DataChangeEventArgs(0));
        }

        private void saveParameter(String name, String value)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings[name].Value = value;
            cfg.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void remember_password_cb_CheckedChanged(object sender, EventArgs e)
        {
            saveParameter("remember_password", remember_password_cb.CheckState == CheckState.Checked ? "1" : "0");
            if (remember_password_cb.CheckState != CheckState.Checked)
            {
                saveParameter("memory_password", "");
            }
        }

        private void password_length_tb_Scroll(object sender, EventArgs e)
        {
            password_length_tv.Text = resourceManager.GetString("password_length_value") + password_length_tb.Value + "]";
            saveParameter("password_length", password_length_tb.Value + "");
            OnDataChange(this, new DataChangeEventArgs(0));

        }

        private void show_emember_password_cb_CheckedChanged(object sender, EventArgs e)
        {
            saveParameter("show_password", show_password_cb.CheckState == CheckState.Checked ? "1" : "0");
            OnDataChange(this, new DataChangeEventArgs(1));
        }
    }


    /// <summary>
    /// 自定义事件参数类型，根据需要可设定多种参数便于传递
    /// </summary>
    public class DataChangeEventArgs : EventArgs
    {
        public int mType { get; set; }
        public DataChangeEventArgs(int type)
        {
            mType = type;
        }
    }
}
