﻿namespace TurnCtrl
{
    partial class Turnstile
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
            this.passNum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.passOut = new System.Windows.Forms.PictureBox();
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
            // passNum
            // 
            this.passNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.passNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.passNum.Location = new System.Drawing.Point(20, 130);
            this.passNum.Margin = new System.Windows.Forms.Padding(0);
            this.passNum.Name = "passNum";
            this.passNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passNum.Size = new System.Drawing.Size(40, 20);
            this.passNum.TabIndex = 9;
            this.passNum.Text = "#";
            this.passNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.passNum.UseMnemonic = false;
            this.passNum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.passNum_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TurnCtrl.Properties.Resources.ARROW_IN;
            this.pictureBox1.Location = new System.Drawing.Point(25, 121);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 9);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // passOut
            // 
            this.passOut.Image = global::TurnCtrl.Properties.Resources.ARROW_OUT;
            this.passOut.Location = new System.Drawing.Point(25, 0);
            this.passOut.Margin = new System.Windows.Forms.Padding(4);
            this.passOut.Name = "passOut";
            this.passOut.Size = new System.Drawing.Size(30, 9);
            this.passOut.TabIndex = 10;
            this.passOut.TabStop = false;
            // 
            // Laser_I_1
            // 
            this.Laser_I_1.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_I_1.Location = new System.Drawing.Point(20, 97);
            this.Laser_I_1.Margin = new System.Windows.Forms.Padding(4);
            this.Laser_I_1.Name = "Laser_I_1";
            this.Laser_I_1.Size = new System.Drawing.Size(40, 3);
            this.Laser_I_1.TabIndex = 5;
            this.Laser_I_1.TabStop = false;
            // 
            // Laser_I_0
            // 
            this.Laser_I_0.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_I_0.Location = new System.Drawing.Point(20, 112);
            this.Laser_I_0.Margin = new System.Windows.Forms.Padding(4);
            this.Laser_I_0.Name = "Laser_I_0";
            this.Laser_I_0.Size = new System.Drawing.Size(40, 3);
            this.Laser_I_0.TabIndex = 4;
            this.Laser_I_0.TabStop = false;
            // 
            // Laser_O_1
            // 
            this.Laser_O_1.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_O_1.Location = new System.Drawing.Point(20, 30);
            this.Laser_O_1.Margin = new System.Windows.Forms.Padding(4);
            this.Laser_O_1.Name = "Laser_O_1";
            this.Laser_O_1.Size = new System.Drawing.Size(40, 3);
            this.Laser_O_1.TabIndex = 3;
            this.Laser_O_1.TabStop = false;
            // 
            // Laser_O_0
            // 
            this.Laser_O_0.Image = global::TurnCtrl.Properties.Resources.Laser;
            this.Laser_O_0.Location = new System.Drawing.Point(20, 15);
            this.Laser_O_0.Margin = new System.Windows.Forms.Padding(4);
            this.Laser_O_0.Name = "Laser_O_0";
            this.Laser_O_0.Size = new System.Drawing.Size(40, 3);
            this.Laser_O_0.TabIndex = 2;
            this.Laser_O_0.TabStop = false;
            // 
            // inHead
            // 
            this.inHead.Location = new System.Drawing.Point(60, 65);
            this.inHead.Margin = new System.Windows.Forms.Padding(4);
            this.inHead.Name = "inHead";
            this.inHead.Size = new System.Drawing.Size(20, 65);
            this.inHead.TabIndex = 1;
            this.inHead.TabStop = false;
            this.inHead.MouseHover += new System.EventHandler(this.PassHead_MouseHover);
            // 
            // outHead
            // 
            this.outHead.Location = new System.Drawing.Point(0, 0);
            this.outHead.Margin = new System.Windows.Forms.Padding(4);
            this.outHead.Name = "outHead";
            this.outHead.Size = new System.Drawing.Size(20, 65);
            this.outHead.TabIndex = 0;
            this.outHead.TabStop = false;
            this.outHead.MouseHover += new System.EventHandler(this.PassHead_MouseHover);
            // 
            // Turnstile
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
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Turnstile";
            this.Size = new System.Drawing.Size(80, 150);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Turnstile_Paint);
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
        private System.Windows.Forms.PictureBox passOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label passNum;
    }
}
