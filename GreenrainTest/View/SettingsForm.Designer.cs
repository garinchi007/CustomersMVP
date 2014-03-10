namespace WindowsFormsApplication1.View
{
    partial class SettingsForm
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
            this.viewSettings1 = new WindowsFormsApplication1.View.ViewSettings();
            this.SuspendLayout();
            // 
            // viewSettings1
            // 
            this.viewSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSettings1.Location = new System.Drawing.Point(0, 0);
            this.viewSettings1.Name = "viewSettings1";
            this.viewSettings1.Size = new System.Drawing.Size(334, 163);
            this.viewSettings1.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 163);
            this.Controls.Add(this.viewSettings1);
            this.MinimumSize = new System.Drawing.Size(300, 201);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);

        }

        #endregion
        private ViewSettings viewSettings1;
    }
}