namespace TurnCtrl
{
    partial class TurnLine
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
            this.TextLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lastEmptyHead = new System.Windows.Forms.PictureBox();
            this.firstEmptyHead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lastEmptyHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstEmptyHead)).BeginInit();
            this.SuspendLayout();
            // 
            // TextLbl
            // 
            this.TextLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.TextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextLbl.Location = new System.Drawing.Point(20, 0);
            this.TextLbl.Name = "TextLbl";
            this.TextLbl.Size = new System.Drawing.Size(80, 20);
            this.TextLbl.TabIndex = 0;
            this.TextLbl.Text = "Линейка";
            this.TextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lastEmptyHead
            // 
            this.lastEmptyHead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lastEmptyHead.Location = new System.Drawing.Point(75, 25);
            this.lastEmptyHead.Name = "lastEmptyHead";
            this.lastEmptyHead.Size = new System.Drawing.Size(20, 65);
            this.lastEmptyHead.TabIndex = 3;
            this.lastEmptyHead.TabStop = false;
            // 
            // firstEmptyHead
            // 
            this.firstEmptyHead.Location = new System.Drawing.Point(5, 90);
            this.firstEmptyHead.Name = "firstEmptyHead";
            this.firstEmptyHead.Size = new System.Drawing.Size(20, 65);
            this.firstEmptyHead.TabIndex = 2;
            this.firstEmptyHead.TabStop = false;
            // 
            // TurnLine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lastEmptyHead);
            this.Controls.Add(this.firstEmptyHead);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextLbl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TurnLine";
            this.Size = new System.Drawing.Size(100, 180);
            ((System.ComponentModel.ISupportInitialize)(this.lastEmptyHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstEmptyHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox firstEmptyHead;
        private System.Windows.Forms.PictureBox lastEmptyHead;
    }
}
