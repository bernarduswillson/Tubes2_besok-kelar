namespace WinFormsApp1
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            startButton = new Button();
            Choose = new Button();
            BFS = new RadioButton();
            DFS = new RadioButton();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.Transparent;
            startButton.BackgroundImageLayout = ImageLayout.Center;
            startButton.Cursor = Cursors.Hand;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            startButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.ForeColor = Color.Transparent;
            startButton.Location = new Point(280, 367);
            startButton.Name = "startButton";
            startButton.Size = new Size(241, 42);
            startButton.TabIndex = 0;
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // Choose
            // 
            Choose.BackColor = Color.Transparent;
            Choose.BackgroundImageLayout = ImageLayout.Center;
            Choose.Cursor = Cursors.Hand;
            Choose.FlatAppearance.BorderSize = 0;
            Choose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Choose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Choose.FlatStyle = FlatStyle.Flat;
            Choose.ForeColor = Color.Transparent;
            Choose.Location = new Point(206, 137);
            Choose.Name = "Choose";
            Choose.Size = new Size(374, 45);
            Choose.TabIndex = 1;
            Choose.UseVisualStyleBackColor = false;
            Choose.Click += Choose_Click;
            // 
            // BFS
            // 
            BFS.AutoSize = true;
            BFS.BackColor = Color.Transparent;
            BFS.Location = new Point(262, 213);
            BFS.Name = "BFS";
            BFS.Size = new Size(14, 13);
            BFS.TabIndex = 2;
            BFS.TabStop = true;
            BFS.UseVisualStyleBackColor = false;
            BFS.CheckedChanged += BFS_CheckedChanged;
            // 
            // DFS
            // 
            DFS.AutoSize = true;
            DFS.BackColor = Color.Transparent;
            DFS.Location = new Point(262, 263);
            DFS.Name = "DFS";
            DFS.Size = new Size(14, 13);
            DFS.TabIndex = 3;
            DFS.TabStop = true;
            DFS.UseVisualStyleBackColor = false;
            DFS.CheckedChanged += DFS_CheckedChanged;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(784, 461);
            Controls.Add(DFS);
            Controls.Add(BFS);
            Controls.Add(Choose);
            Controls.Add(startButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maze Solver";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button Choose;
        private RadioButton BFS;
        private RadioButton DFS;
    }
}