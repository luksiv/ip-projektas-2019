﻿namespace WindowsFormsApp1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.knn_start = new System.Windows.Forms.Button();
            this.bajes_start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.alNum = new System.Windows.Forms.NumericUpDown();
            this.caNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.baNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.kNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.riNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.siNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.mgNum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.feNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.naNum = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.alNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.naNum)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sukurti neuroninį tinklą";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(305, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(409, 426);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(15, 148);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(275, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Vykdyti neuroninio tinklo apmokymą";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(87, 235);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(138, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "Išvalyti tekstą";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Programa";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 105);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Visi duomenys";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(199, 105);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(91, 17);
            this.radioButton3.TabIndex = 17;
            this.radioButton3.Text = "Be nutolusiųjų";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Pasirinkite duomenų tipą";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(53, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Gauti duomenis iš tinklapio";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // knn_start
            // 
            this.knn_start.Enabled = false;
            this.knn_start.Location = new System.Drawing.Point(15, 177);
            this.knn_start.Name = "knn_start";
            this.knn_start.Size = new System.Drawing.Size(275, 23);
            this.knn_start.TabIndex = 21;
            this.knn_start.Text = "kNN";
            this.knn_start.UseVisualStyleBackColor = true;
            this.knn_start.Click += new System.EventHandler(this.Knn_start_Click);
            // 
            // bajes_start
            // 
            this.bajes_start.Enabled = false;
            this.bajes_start.Location = new System.Drawing.Point(15, 206);
            this.bajes_start.Name = "bajes_start";
            this.bajes_start.Size = new System.Drawing.Size(275, 23);
            this.bajes_start.TabIndex = 22;
            this.bajes_start.Text = "Bajeso algoritmas";
            this.bajes_start.UseVisualStyleBackColor = true;
            this.bajes_start.Click += new System.EventHandler(this.bajes_start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Al";
            // 
            // alNum
            // 
            this.alNum.DecimalPlaces = 4;
            this.alNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.alNum.Location = new System.Drawing.Point(53, 271);
            this.alNum.Name = "alNum";
            this.alNum.Size = new System.Drawing.Size(67, 20);
            this.alNum.TabIndex = 24;
            this.alNum.Value = new decimal(new int[] {
            18,
            0,
            0,
            65536});
            // 
            // caNum
            // 
            this.caNum.DecimalPlaces = 4;
            this.caNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.caNum.Location = new System.Drawing.Point(223, 271);
            this.caNum.Name = "caNum";
            this.caNum.Size = new System.Drawing.Size(67, 20);
            this.caNum.TabIndex = 26;
            this.caNum.Value = new decimal(new int[] {
            861,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ca";
            // 
            // baNum
            // 
            this.baNum.DecimalPlaces = 4;
            this.baNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.baNum.Location = new System.Drawing.Point(223, 297);
            this.baNum.Name = "baNum";
            this.baNum.Size = new System.Drawing.Size(67, 20);
            this.baNum.TabIndex = 30;
            this.baNum.Value = new decimal(new int[] {
            154,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ba";
            // 
            // kNum
            // 
            this.kNum.DecimalPlaces = 4;
            this.kNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kNum.Location = new System.Drawing.Point(53, 297);
            this.kNum.Name = "kNum";
            this.kNum.Size = new System.Drawing.Size(67, 20);
            this.kNum.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "K";
            // 
            // riNum
            // 
            this.riNum.DecimalPlaces = 4;
            this.riNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.riNum.Location = new System.Drawing.Point(223, 323);
            this.riNum.Name = "riNum";
            this.riNum.Size = new System.Drawing.Size(67, 20);
            this.riNum.TabIndex = 34;
            this.riNum.Value = new decimal(new int[] {
            1518,
            0,
            0,
            196608});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Lūžio rodiklis";
            // 
            // siNum
            // 
            this.siNum.DecimalPlaces = 4;
            this.siNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.siNum.Location = new System.Drawing.Point(53, 323);
            this.siNum.Name = "siNum";
            this.siNum.Size = new System.Drawing.Size(67, 20);
            this.siNum.TabIndex = 32;
            this.siNum.Value = new decimal(new int[] {
            7298,
            0,
            0,
            131072});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Si";
            // 
            // mgNum
            // 
            this.mgNum.DecimalPlaces = 4;
            this.mgNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.mgNum.Location = new System.Drawing.Point(223, 349);
            this.mgNum.Name = "mgNum";
            this.mgNum.Size = new System.Drawing.Size(67, 20);
            this.mgNum.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Mg";
            // 
            // feNum
            // 
            this.feNum.DecimalPlaces = 4;
            this.feNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.feNum.Location = new System.Drawing.Point(53, 349);
            this.feNum.Name = "feNum";
            this.feNum.Size = new System.Drawing.Size(67, 20);
            this.feNum.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 349);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Fe";
            // 
            // naNum
            // 
            this.naNum.DecimalPlaces = 4;
            this.naNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.naNum.Location = new System.Drawing.Point(53, 375);
            this.naNum.Name = "naNum";
            this.naNum.Size = new System.Drawing.Size(67, 20);
            this.naNum.TabIndex = 40;
            this.naNum.Value = new decimal(new int[] {
            1495,
            0,
            0,
            131072});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Na";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 23);
            this.button3.TabIndex = 41;
            this.button3.Text = "Klasifikuoti stiklą";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.naNum);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.mgNum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.feNum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.riNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.siNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.baNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.kNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.caNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.alNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.knn_start);
            this.Controls.Add(this.bajes_start);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.alNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.naNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button knn_start;
		private System.Windows.Forms.Button bajes_start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown alNum;
        private System.Windows.Forms.NumericUpDown caNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown baNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown kNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown riNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown siNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown mgNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown feNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown naNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
    }
}

