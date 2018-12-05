namespace TurnCtrl
{
    partial class Turnstile_2000
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.passOut = new System.Windows.Forms.PictureBox();
            this.passNum = new System.Windows.Forms.Button();
            this.Laser_I_1 = new System.Windows.Forms.PictureBox();
            this.Laser_I_0 = new System.Windows.Forms.PictureBox();
            this.Laser_O_1 = new System.Windows.Forms.PictureBox();
            this.Laser_O_0 = new System.Windows.Forms.PictureBox();
            this.inHead = new System.Windows.Forms.PictureBox();
            this.outHead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_I_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_I_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_O_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_O_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outHead)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 2);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label2.Location = new System.Drawing.Point(42, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 2);
            this.label2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TurnCtrl.Properties.Resources.ARROW_IN;
            this.pictureBox1.Location = new System.Drawing.Point(25, 121);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 9);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // passOut
            // 
            this.passOut.Image = global::TurnCtrl.Properties.Resources.ARROW_OUT;
            this.passOut.Location = new System.Drawing.Point(25, 0);
            this.passOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passOut.Name = "passOut";
            this.passOut.Size = new System.Drawing.Size(30, 9);
            this.passOut.TabIndex = 10;
            this.passOut.TabStop = false;
            this.passOut.Visible = false;
            // 
            // passNum
            // 
            this.passNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.passNum.FlatAppearance.BorderSize = 0;
            this.passNum.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.passNum.Location = new System.Drawing.Point(20, 130);
            this.passNum.Margin = new System.Windows.Forms.Padding(0);
            this.passNum.Name = "passNum";
            this.passNum.Size = new System.Drawing.Size(40, 20);
            this.passNum.TabIndex = 9;
            this.passNum.TabStop = false;
            this.passNum.Text = "#";
            this.passNum.UseVisualStyleBackColor = false;
            this.passNum.MouseHover += new System.EventHandler(this.SpecButton_MouseHover);
            // 
            // Laser_I_1
            // 
            this.Laser_I_1.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_I_1.Location = new System.Drawing.Point(20, 97);
            this.Laser_I_1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Laser_I_1.Name = "Laser_I_1";
            this.Laser_I_1.Size = new System.Drawing.Size(40, 3);
            this.Laser_I_1.TabIndex = 5;
            this.Laser_I_1.TabStop = false;
            this.Laser_I_1.Visible = false;
            // 
            // Laser_I_0
            // 
            this.Laser_I_0.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_I_0.Location = new System.Drawing.Point(20, 112);
            this.Laser_I_0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Laser_I_0.Name = "Laser_I_0";
            this.Laser_I_0.Size = new System.Drawing.Size(40, 3);
            this.Laser_I_0.TabIndex = 4;
            this.Laser_I_0.TabStop = false;
            this.Laser_I_0.Visible = false;
            // 
            // Laser_O_1
            // 
            this.Laser_O_1.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_O_1.Location = new System.Drawing.Point(20, 30);
            this.Laser_O_1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Laser_O_1.Name = "Laser_O_1";
            this.Laser_O_1.Size = new System.Drawing.Size(40, 3);
            this.Laser_O_1.TabIndex = 3;
            this.Laser_O_1.TabStop = false;
            this.Laser_O_1.Visible = false;
            // 
            // Laser_O_0
            // 
            this.Laser_O_0.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_O_0.Location = new System.Drawing.Point(20, 15);
            this.Laser_O_0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Laser_O_0.Name = "Laser_O_0";
            this.Laser_O_0.Size = new System.Drawing.Size(40, 3);
            this.Laser_O_0.TabIndex = 2;
            this.Laser_O_0.TabStop = false;
            this.Laser_O_0.Visible = false;
            // 
            // inHead
            // 
            this.inHead.Image = global::TurnCtrl.Properties.Resources.ut2000_head_in_normal;
            this.inHead.Location = new System.Drawing.Point(60, 65);
            this.inHead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inHead.Name = "inHead";
            this.inHead.Size = new System.Drawing.Size(20, 65);
            this.inHead.TabIndex = 1;
            this.inHead.TabStop = false;
            // 
            // outHead
            // 
            this.outHead.Image = global::TurnCtrl.Properties.Resources.ut2000_head_out_normal;
            this.outHead.Location = new System.Drawing.Point(0, 0);
            this.outHead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outHead.Name = "outHead";
            this.outHead.Size = new System.Drawing.Size(20, 65);
            this.outHead.TabIndex = 0;
            this.outHead.TabStop = false;
            // 
            // Turnstile_2000
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.passOut);
            this.Controls.Add(this.passNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Laser_I_1);
            this.Controls.Add(this.Laser_I_0);
            this.Controls.Add(this.Laser_O_1);
            this.Controls.Add(this.Laser_O_0);
            this.Controls.Add(this.inHead);
            this.Controls.Add(this.outHead);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Turnstile_2000";
            this.Size = new System.Drawing.Size(80, 150);
            this.Load += new System.EventHandler(this.Turnstile_2000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_I_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_I_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_O_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_O_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox outHead;
        private System.Windows.Forms.PictureBox inHead;
        private System.Windows.Forms.PictureBox Laser_O_0;
        private System.Windows.Forms.PictureBox Laser_O_1;
        private System.Windows.Forms.PictureBox Laser_I_0;
        private System.Windows.Forms.PictureBox Laser_I_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button passNum;
        private System.Windows.Forms.PictureBox passOut;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
