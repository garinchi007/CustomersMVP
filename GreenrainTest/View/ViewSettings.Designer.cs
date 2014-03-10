namespace WindowsFormsApplication1.View
{
    partial class ViewSettings
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (Disposed != null) Disposed();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label90 = new System.Windows.Forms.Label();
            this.bd_is = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.bd_pass = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.bd_server = new System.Windows.Forms.TextBox();
            this.bd_name = new System.Windows.Forms.TextBox();
            this.bd_user = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(3, 3);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 139;
            this.button_ok.Text = "Сохранить";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(82, 3);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 138;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(4, 111);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(96, 13);
            this.label90.TabIndex = 132;
            this.label90.Text = "Integrated Security";
            // 
            // bd_is
            // 
            this.bd_is.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bd_is.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bd_is.FormattingEnabled = true;
            this.bd_is.Items.AddRange(new object[] {
            "true",
            "false"});
            this.bd_is.Location = new System.Drawing.Point(0, 4);
            this.bd_is.Name = "bd_is";
            this.bd_is.Size = new System.Drawing.Size(222, 21);
            this.bd_is.TabIndex = 137;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(4, 7);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(106, 13);
            this.label47.TabIndex = 128;
            this.label47.Text = "Имя пользователя:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(4, 33);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(48, 13);
            this.label46.TabIndex = 129;
            this.label46.Text = "Пароль:";
            // 
            // bd_pass
            // 
            this.bd_pass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bd_pass.Location = new System.Drawing.Point(0, 4);
            this.bd_pass.Name = "bd_pass";
            this.bd_pass.Size = new System.Drawing.Size(222, 20);
            this.bd_pass.TabIndex = 134;
            this.bd_pass.UseSystemPasswordChar = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(4, 85);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(51, 13);
            this.label45.TabIndex = 130;
            this.label45.Text = "Имя БД:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(4, 59);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(47, 13);
            this.label44.TabIndex = 131;
            this.label44.Text = "Сервер:";
            // 
            // bd_server
            // 
            this.bd_server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bd_server.Location = new System.Drawing.Point(0, 4);
            this.bd_server.Name = "bd_server";
            this.bd_server.Size = new System.Drawing.Size(222, 20);
            this.bd_server.TabIndex = 135;
            this.bd_server.Text = "localhost";
            // 
            // bd_name
            // 
            this.bd_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bd_name.Location = new System.Drawing.Point(0, 4);
            this.bd_name.Name = "bd_name";
            this.bd_name.Size = new System.Drawing.Size(222, 20);
            this.bd_name.TabIndex = 136;
            this.bd_name.Text = "Northwind";
            // 
            // bd_user
            // 
            this.bd_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bd_user.Location = new System.Drawing.Point(0, 4);
            this.bd_user.Name = "bd_user";
            this.bd_user.Size = new System.Drawing.Size(222, 20);
            this.bd_user.TabIndex = 133;
            this.bd_user.Text = "sa";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label47);
            this.panel1.Controls.Add(this.label44);
            this.panel1.Controls.Add(this.label45);
            this.panel1.Controls.Add(this.label90);
            this.panel1.Controls.Add(this.label46);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 163);
            this.panel1.TabIndex = 140;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bd_user);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(117, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.panel2.Size = new System.Drawing.Size(227, 26);
            this.panel2.TabIndex = 141;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bd_pass);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(117, 26);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.panel3.Size = new System.Drawing.Size(227, 26);
            this.panel3.TabIndex = 142;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.bd_server);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(117, 52);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.panel4.Size = new System.Drawing.Size(227, 26);
            this.panel4.TabIndex = 143;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bd_name);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(117, 78);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.panel5.Size = new System.Drawing.Size(227, 26);
            this.panel5.TabIndex = 144;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.bd_is);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(117, 104);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.panel6.Size = new System.Drawing.Size(227, 26);
            this.panel6.TabIndex = 145;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(117, 130);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(227, 30);
            this.panel7.TabIndex = 146;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(65, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(162, 30);
            this.panel8.TabIndex = 140;
            // 
            // ViewSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ViewSettings";
            this.Size = new System.Drawing.Size(344, 163);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.ComboBox bd_is;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox bd_pass;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox bd_server;
        private System.Windows.Forms.TextBox bd_name;
        private System.Windows.Forms.TextBox bd_user;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
    }
}
