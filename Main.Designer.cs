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
            this.seeCommandResult = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // resultsCommands
            // 
            this.resultsCommands.AcceptsTab = true;
            this.resultsCommands.AutoWordSelection = true;
            this.resultsCommands.BackColor = System.Drawing.Color.DarkGray;
            this.resultsCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultsCommands.Location = new System.Drawing.Point(819, 12);
            this.resultsCommands.Name = "resultsCommands";
            this.resultsCommands.Size = new System.Drawing.Size(432, 426);
            this.resultsCommands.TabIndex = 1;
            this.resultsCommands.Text = "";
            this.resultsCommands.TextChanged += new System.EventHandler(this.resultsCommands_TextChanged);
            this.resultsCommands.Leave += new System.EventHandler(this.resultsCommands_Leave);
            // 
            // inputServices
            // 
            this.inputServices.BackColor = System.Drawing.Color.DarkGray;
            this.inputServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputServices.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputServices.Location = new System.Drawing.Point(548, 12);
            this.inputServices.Name = "inputServices";
            this.inputServices.Size = new System.Drawing.Size(210, 426);
            this.inputServices.TabIndex = 2;
            this.inputServices.Text = "";
            this.inputServices.Leave += new System.EventHandler(this.inputServices_Leave);
            // 
            // seeCommandResult
            // 
            this.seeCommandResult.AutoSize = true;
            this.seeCommandResult.Location = new System.Drawing.Point(12, 482);
            this.seeCommandResult.Name = "seeCommandResult";
            this.seeCommandResult.Size = new System.Drawing.Size(168, 17);
            this.seeCommandResult.TabIndex = 3;
            this.seeCommandResult.Text = "Показывать вывод команд";
            this.seeCommandResult.UseVisualStyleBackColor = true;
            this.seeCommandResult.CheckedChanged += new System.EventHandler(this.seeCommandResult_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1284, 511);
            this.Controls.Add(this.seeCommandResult);
            this.Controls.Add(this.inputServices);
            this.Controls.Add(this.resultsCommands);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "ServiceApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox resultsCommands;
        private System.Windows.Forms.RichTextBox inputServices;
        private System.Windows.Forms.CheckBox seeCommandResult;
    }
}

