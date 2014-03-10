namespace WindowsFormsApplication1.View
{
    partial class CustomerSearchView
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
            this.Search_btn = new System.Windows.Forms.Button();
            this.CompanyName_tBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Country_cbox = new System.Windows.Forms.ComboBox();
            this.City_cbox = new System.Windows.Forms.ComboBox();
            this.ending = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.page_tbox = new System.Windows.Forms.TextBox();
            this.beginning = new System.Windows.Forms.Button();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(170, 88);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(75, 23);
            this.Search_btn.TabIndex = 14;
            this.Search_btn.Text = "Поиск";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // CompanyName_tBox
            // 
            this.CompanyName_tBox.Location = new System.Drawing.Point(85, 62);
            this.CompanyName_tBox.Name = "CompanyName_tBox";
            this.CompanyName_tBox.Size = new System.Drawing.Size(160, 20);
            this.CompanyName_tBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Компания";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Город";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Страна";
            // 
            // Country_cbox
            // 
            this.Country_cbox.FormattingEnabled = true;
            this.Country_cbox.Location = new System.Drawing.Point(85, 8);
            this.Country_cbox.Name = "Country_cbox";
            this.Country_cbox.Size = new System.Drawing.Size(160, 21);
            this.Country_cbox.TabIndex = 9;
            this.Country_cbox.SelectedIndexChanged += new System.EventHandler(this.Country_cbox_SelectedIndexChanged);
            this.Country_cbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Country_cbox_KeyUp);
            // 
            // City_cbox
            // 
            this.City_cbox.FormattingEnabled = true;
            this.City_cbox.Location = new System.Drawing.Point(85, 35);
            this.City_cbox.Name = "City_cbox";
            this.City_cbox.Size = new System.Drawing.Size(160, 21);
            this.City_cbox.TabIndex = 8;
            // 
            // ending
            // 
            this.ending.Enabled = false;
            this.ending.Location = new System.Drawing.Point(138, 8);
            this.ending.Name = "ending";
            this.ending.Size = new System.Drawing.Size(29, 20);
            this.ending.TabIndex = 26;
            this.ending.Text = ">>";
            this.ending.UseVisualStyleBackColor = true;
            this.ending.Click += new System.EventHandler(this.ending_Click);
            // 
            // next
            // 
            this.next.Enabled = false;
            this.next.Location = new System.Drawing.Point(107, 8);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(29, 20);
            this.next.TabIndex = 25;
            this.next.Text = ">";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.Enabled = false;
            this.previous.Location = new System.Drawing.Point(34, 7);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(29, 20);
            this.previous.TabIndex = 24;
            this.previous.Text = "<";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // page_tbox
            // 
            this.page_tbox.Enabled = false;
            this.page_tbox.Location = new System.Drawing.Point(66, 8);
            this.page_tbox.MaxLength = 4;
            this.page_tbox.Name = "page_tbox";
            this.page_tbox.Size = new System.Drawing.Size(38, 20);
            this.page_tbox.TabIndex = 23;
            this.page_tbox.Text = "0";
            this.page_tbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.page_tbox_KeyPress);
            // 
            // beginning
            // 
            this.beginning.Enabled = false;
            this.beginning.Location = new System.Drawing.Point(3, 7);
            this.beginning.Name = "beginning";
            this.beginning.Size = new System.Drawing.Size(29, 20);
            this.beginning.TabIndex = 22;
            this.beginning.Text = "<<";
            this.beginning.UseVisualStyleBackColor = true;
            this.beginning.Click += new System.EventHandler(this.beginning_Click);
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.AllowUserToAddRows = false;
            this.dataGridViewCustomers.AllowUserToDeleteRows = false;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(0, 8);
            this.dataGridViewCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.Size = new System.Drawing.Size(565, 243);
            this.dataGridViewCustomers.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.City_cbox);
            this.panel1.Controls.Add(this.Country_cbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CompanyName_tBox);
            this.panel1.Controls.Add(this.Search_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 286);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.beginning);
            this.panel2.Controls.Add(this.page_tbox);
            this.panel2.Controls.Add(this.ending);
            this.panel2.Controls.Add(this.previous);
            this.panel2.Controls.Add(this.next);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(249, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 35);
            this.panel2.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewCustomers);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(249, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 8, 5, 0);
            this.panel3.Size = new System.Drawing.Size(570, 251);
            this.panel3.TabIndex = 29;
            // 
            // CustomerSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerSearchView";
            this.Size = new System.Drawing.Size(819, 286);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox CompanyName_tBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Country_cbox;
        private System.Windows.Forms.ComboBox City_cbox;
        private System.Windows.Forms.Button ending;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.TextBox page_tbox;
        private System.Windows.Forms.Button beginning;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
