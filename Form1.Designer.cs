using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Title = new Label();
            label2 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button2 = new Button();
            splitContainer1 = new SplitContainer();
            button3 = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.BackColor = Color.Transparent;
            Title.FlatStyle = FlatStyle.Popup;
            Title.Font = new Font("Impact", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Title.ForeColor = Color.White;
            Title.Location = new Point(17, 9);
            Title.Margin = new Padding(2, 0, 2, 0);
            Title.Name = "Title";
            Title.RightToLeft = RightToLeft.No;
            Title.Size = new Size(249, 34);
            Title.TabIndex = 0;
            Title.Text = "Treasure Hunt Solver";
            Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Sienna;
            label2.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(63, 199);
            label2.Margin = new Padding(2, 2, 2, 2);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 6;
            label2.Text = "Algorithm";
            label2.Click += label2_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Sienna;
            radioButton2.Cursor = Cursors.Hand;
            radioButton2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton2.ForeColor = Color.White;
            radioButton2.Location = new Point(64, 253);
            radioButton2.Margin = new Padding(2, 2, 2, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(43, 20);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.Text = "DFS";
            radioButton2.UseVisualStyleBackColor = false;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Sienna;
            radioButton1.Cursor = Cursors.Hand;
            radioButton1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton1.ForeColor = Color.White;
            radioButton1.Location = new Point(64, 228);
            radioButton1.Margin = new Padding(2, 2, 2, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(43, 20);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "BFS";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(63, 368);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(175, 38);
            button1.TabIndex = 2;
            button1.Text = "SEARCH!";
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(314, 60);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(542, 406);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Sienna;
            label1.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(63, 77);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(51, 23);
            label1.TabIndex = 0;
            label1.Text = "Input";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 64, 0);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Impact", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(63, 105);
            button2.Name = "button2";
            button2.Size = new Size(98, 23);
            button2.TabIndex = 7;
            button2.Text = "Upload File";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(1, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Sienna;
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(trackBar1);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Tan;
            splitContainer1.Panel2.Controls.Add(Title);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(876, 480);
            splitContainer1.SplitterDistance = 291;
            splitContainer1.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(178, 253);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 5;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(171, 310);
            label4.Name = "label4";
            label4.Size = new Size(22, 16);
            label4.TabIndex = 4;
            label4.Text = "ms";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(114, 308);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(58, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // trackBar1
            // 
            trackBar1.Cursor = Cursors.Hand;
            trackBar1.Location = new Point(62, 332);
            trackBar1.Margin = new Padding(3, 2, 3, 2);
            trackBar1.Maximum = 1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(175, 45);
            trackBar1.TabIndex = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(62, 131);
            label3.Name = "label3";
            label3.Size = new Size(23, 16);
            label3.TabIndex = 0;
            label3.Text = ".txt";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(875, 477);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(radioButton2);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Treasure Hunt Solver";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Label label2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button2;
        private SplitContainer splitContainer1;
        private Label label3;
        private TrackBar trackBar1;
        private TextBox textBox1;
        private Label label4;
        private Button button3;
    }
}