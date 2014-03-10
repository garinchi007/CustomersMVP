namespace WindowsFormsApplication1.View
{
    partial class MainForm
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
            this.Settings_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customerSearchView1 = new WindowsFormsApplication1.View.CustomerSearchView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings_btn
            // 
            this.Settings_btn.Location = new System.Drawing.Point(3, 3);
            this.Settings_btn.Name = "Settings_btn";
            this.Settings_btn.Size = new System.Drawing.Size(75, 23);
            this.Settings_btn.TabIndex = 9;
            this.Settings_btn.Text = "Настройки";
            this.Settings_btn.UseVisualStyleBackColor = true;
            this.Settings_btn.Click += new System.EventHandler(this.Settings_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Settings_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 28);
            this.panel1.TabIndex = 10;
            // 
            // customerSearchView1
            // 
            this.customerSearchView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerSearchView1.IsNextButEnabled = false;
            this.customerSearchView1.IsPreviuosButEnabled = false;
            this.customerSearchView1.Location = new System.Drawing.Point(0, 0);
            this.customerSearchView1.Name = "customerSearchView1";
            this.customerSearchView1.Size = new System.Drawing.Size(818, 295);
            this.customerSearchView1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 332);
            this.Controls.Add(this.customerSearchView1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(438, 185);
            this.Name = "MainForm";
            this.Text = "Поиск клиентов";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Settings_btn;
        private System.Windows.Forms.Panel panel1;
        private CustomerSearchView customerSearchView1;
    }
}

