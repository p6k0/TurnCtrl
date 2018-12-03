namespace TurnCtrl
{
    partial class LineGroup
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupText
            // 
            this.groupText.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupText.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupText.Location = new System.Drawing.Point(0, 0);
            this.groupText.Name = "groupText";
            this.groupText.Size = new System.Drawing.Size(441, 25);
            this.groupText.TabIndex = 0;
            this.groupText.Text = "PpYy";
            this.groupText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupText);
            this.Name = "LineGroup";
            this.Size = new System.Drawing.Size(441, 280);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label groupText;
    }
}
