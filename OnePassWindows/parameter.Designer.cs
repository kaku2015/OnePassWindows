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
            this.special_symbol = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.password_tb = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.password_tb)).BeginInit();
            this.SuspendLayout();
            // 
            // special_symbol
            // 
            resources.ApplyResources(this.special_symbol, "special_symbol");
            this.special_symbol.ForeColor = System.Drawing.Color.White;
            this.special_symbol.Name = "special_symbol";
            this.special_symbol.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // password_tb
            // 
            resources.ApplyResources(this.password_tb, "password_tb");
            this.password_tb.Maximum = 32;
            this.password_tb.Minimum = 6;
            this.password_tb.Name = "password_tb";
            this.password_tb.Value = 16;
            // 
            // parameter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.special_symbol);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "parameter";
            this.Load += new System.EventHandler(this.parameter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.password_tb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox special_symbol;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar password_tb;
    }
}