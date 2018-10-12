namespace OnePassWindows
{
    partial class parameter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(parameter));
            this.with_symbol_cb = new System.Windows.Forms.CheckBox();
            this.first_capital_letter_cb = new System.Windows.Forms.CheckBox();
            this.password_length_tv = new System.Windows.Forms.Label();
            this.password_length_tb = new System.Windows.Forms.TrackBar();
            this.remember_password_cb = new System.Windows.Forms.CheckBox();
            this.show_password_cb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.password_length_tb)).BeginInit();
            this.SuspendLayout();
            // 
            // with_symbol_cb
            // 
            resources.ApplyResources(this.with_symbol_cb, "with_symbol_cb");
            this.with_symbol_cb.ForeColor = System.Drawing.Color.White;
            this.with_symbol_cb.Name = "with_symbol_cb";
            this.with_symbol_cb.UseVisualStyleBackColor = true;
            this.with_symbol_cb.CheckedChanged += new System.EventHandler(this.with_symbol_CheckedChanged);
            // 
            // first_capital_letter_cb
            // 
            resources.ApplyResources(this.first_capital_letter_cb, "first_capital_letter_cb");
            this.first_capital_letter_cb.ForeColor = System.Drawing.Color.White;
            this.first_capital_letter_cb.Name = "first_capital_letter_cb";
            this.first_capital_letter_cb.UseVisualStyleBackColor = true;
            this.first_capital_letter_cb.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // password_length_tv
            // 
            resources.ApplyResources(this.password_length_tv, "password_length_tv");
            this.password_length_tv.ForeColor = System.Drawing.Color.White;
            this.password_length_tv.Name = "password_length_tv";
            // 
            // password_length_tb
            // 
            resources.ApplyResources(this.password_length_tb, "password_length_tb");
            this.password_length_tb.Maximum = 32;
            this.password_length_tb.Minimum = 6;
            this.password_length_tb.Name = "password_length_tb";
            this.password_length_tb.Value = 16;
            this.password_length_tb.Scroll += new System.EventHandler(this.password_length_tb_Scroll);
            // 
            // remember_password_cb
            // 
            resources.ApplyResources(this.remember_password_cb, "remember_password_cb");
            this.remember_password_cb.ForeColor = System.Drawing.Color.White;
            this.remember_password_cb.Name = "remember_password_cb";
            this.remember_password_cb.UseVisualStyleBackColor = true;
            this.remember_password_cb.CheckedChanged += new System.EventHandler(this.remember_password_cb_CheckedChanged);
            // 
            // show_password_cb
            // 
            resources.ApplyResources(this.show_password_cb, "show_password_cb");
            this.show_password_cb.ForeColor = System.Drawing.Color.White;
            this.show_password_cb.Name = "show_password_cb";
            this.show_password_cb.UseVisualStyleBackColor = true;
            this.show_password_cb.CheckedChanged += new System.EventHandler(this.show_emember_password_cb_CheckedChanged);
            // 
            // parameter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.show_password_cb);
            this.Controls.Add(this.remember_password_cb);
            this.Controls.Add(this.password_length_tb);
            this.Controls.Add(this.password_length_tv);
            this.Controls.Add(this.first_capital_letter_cb);
            this.Controls.Add(this.with_symbol_cb);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "parameter";
            this.Load += new System.EventHandler(this.parameter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.password_length_tb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox with_symbol_cb;
        private System.Windows.Forms.CheckBox first_capital_letter_cb;
        private System.Windows.Forms.Label password_length_tv;
        private System.Windows.Forms.TrackBar password_length_tb;
        private System.Windows.Forms.CheckBox remember_password_cb;
        private System.Windows.Forms.CheckBox show_password_cb;
    }
}