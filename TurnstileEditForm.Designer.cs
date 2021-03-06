﻿namespace TurnCtrl
{
    partial class TurnstileEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.leftInvNum = new System.Windows.Forms.TextBox();
            this.leftSNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rightInvNum = new System.Windows.Forms.TextBox();
            this.rightSNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outEnable = new System.Windows.Forms.CheckBox();
            this.inEnable = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.express = new System.Windows.Forms.CheckBox();
            this.baggage = new System.Windows.Forms.CheckBox();
            this.passNum = new System.Windows.Forms.NumericUpDown();
            this.address = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSNum)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер прохода:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Адрес:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "COM-порт:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.leftInvNum);
            this.groupBox1.Controls.Add(this.leftSNum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(337, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Левая стойка";
            // 
            // leftInvNum
            // 
            this.leftInvNum.Location = new System.Drawing.Point(151, 46);
            this.leftInvNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftInvNum.MaxLength = 20;
            this.leftInvNum.Name = "leftInvNum";
            this.leftInvNum.Size = new System.Drawing.Size(177, 22);
            this.leftInvNum.TabIndex = 7;
            // 
            // leftSNum
            // 
            this.leftSNum.Location = new System.Drawing.Point(151, 17);
            this.leftSNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftSNum.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.leftSNum.Name = "leftSNum";
            this.leftSNum.Size = new System.Drawing.Size(179, 22);
            this.leftSNum.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Инвентарный №:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Серийный №:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rightInvNum);
            this.groupBox2.Controls.Add(this.rightSNum);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(361, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(337, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Правая стойка";
            // 
            // rightInvNum
            // 
            this.rightInvNum.Location = new System.Drawing.Point(151, 46);
            this.rightInvNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rightInvNum.MaxLength = 20;
            this.rightInvNum.Name = "rightInvNum";
            this.rightInvNum.Size = new System.Drawing.Size(177, 22);
            this.rightInvNum.TabIndex = 8;
            // 
            // rightSNum
            // 
            this.rightSNum.Location = new System.Drawing.Point(151, 17);
            this.rightSNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rightSNum.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.rightSNum.Name = "rightSNum";
            this.rightSNum.Size = new System.Drawing.Size(179, 22);
            this.rightSNum.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Инвентарный №:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Серийный №:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outEnable);
            this.groupBox3.Controls.Add(this.inEnable);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(361, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(180, 80);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Направления прохода";
            // 
            // outEnable
            // 
            this.outEnable.AutoSize = true;
            this.outEnable.Location = new System.Drawing.Point(8, 48);
            this.outEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outEnable.Name = "outEnable";
            this.outEnable.Size = new System.Drawing.Size(120, 21);
            this.outEnable.TabIndex = 1;
            this.outEnable.Text = "С платформы";
            this.outEnable.UseVisualStyleBackColor = true;
            // 
            // inEnable
            // 
            this.inEnable.AutoSize = true;
            this.inEnable.Location = new System.Drawing.Point(8, 22);
            this.inEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inEnable.Name = "inEnable";
            this.inEnable.Size = new System.Drawing.Size(126, 21);
            this.inEnable.TabIndex = 0;
            this.inEnable.Text = "На платформу";
            this.inEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.express);
            this.groupBox4.Controls.Add(this.baggage);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(549, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(149, 80);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Разное";
            // 
            // express
            // 
            this.express.AutoSize = true;
            this.express.Location = new System.Drawing.Point(8, 50);
            this.express.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.express.Name = "express";
            this.express.Size = new System.Drawing.Size(91, 21);
            this.express.TabIndex = 1;
            this.express.Text = "Экспресс";
            this.express.UseVisualStyleBackColor = true;
            // 
            // baggage
            // 
            this.baggage.AutoSize = true;
            this.baggage.Location = new System.Drawing.Point(8, 22);
            this.baggage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.baggage.Name = "baggage";
            this.baggage.Size = new System.Drawing.Size(95, 21);
            this.baggage.TabIndex = 0;
            this.baggage.Text = "Багажный";
            this.baggage.UseVisualStyleBackColor = true;
            // 
            // passNum
            // 
            this.passNum.Location = new System.Drawing.Point(167, 9);
            this.passNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.passNum.Name = "passNum";
            this.passNum.Size = new System.Drawing.Size(187, 22);
            this.passNum.TabIndex = 11;
            this.passNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(167, 38);
            this.address.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.address.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.address.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(187, 22);
            this.address.TabIndex = 12;
            this.address.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(167, 68);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(599, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 15;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TurnstileEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 228);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.address);
            this.Controls.Add(this.passNum);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TurnstileEditForm";
            this.Text = "Настройка прохода";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSNum)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown leftSNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown rightSNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox outEnable;
        private System.Windows.Forms.CheckBox inEnable;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox express;
        private System.Windows.Forms.CheckBox baggage;
        private System.Windows.Forms.NumericUpDown passNum;
        private System.Windows.Forms.NumericUpDown address;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox leftInvNum;
        private System.Windows.Forms.TextBox rightInvNum;
    }
}