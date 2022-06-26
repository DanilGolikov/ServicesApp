namespace ServicesApp
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.resultsCommands = new System.Windows.Forms.RichTextBox();
            this.inputServices = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // resultsCommands
            // 
            this.resultsCommands.Location = new System.Drawing.Point(819, 12);
            this.resultsCommands.Name = "resultsCommands";
            this.resultsCommands.Size = new System.Drawing.Size(432, 426);
            this.resultsCommands.TabIndex = 1;
            this.resultsCommands.Text = "";
            // 
            // inputServices
            // 
            this.inputServices.Location = new System.Drawing.Point(548, 12);
            this.inputServices.Name = "inputServices";
            this.inputServices.Size = new System.Drawing.Size(210, 426);
            this.inputServices.TabIndex = 2;
            this.inputServices.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1312, 450);
            this.Controls.Add(this.inputServices);
            this.Controls.Add(this.resultsCommands);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "ServiceApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox resultsCommands;
        private System.Windows.Forms.RichTextBox inputServices;
    }
}

