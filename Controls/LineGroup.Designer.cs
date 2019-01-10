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
            this.groupName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupName
            // 
            this.groupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupName.Location = new System.Drawing.Point(0, 0);
            this.groupName.Name = "groupName";
            this.groupName.Size = new System.Drawing.Size(110, 25);
            this.groupName.TabIndex = 0;
            this.groupName.Text = "Pp";
            this.groupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.groupName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.groupName_MouseClick);
            // 
            // LineGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Controls.Add(this.groupName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LineGroup";
            this.Size = new System.Drawing.Size(110, 215);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.LineGroup_ControlRemoved);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label groupName;
    }
}
