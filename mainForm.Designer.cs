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
            TSP = new CheckBox();
            name = new Label();
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
            startButton.Location = new Point(568, 780);
            startButton.Margin = new Padding(4, 5, 4, 5);
            startButton.Name = "startButton";
            startButton.Size = new Size(479, 92);
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
            Choose.Location = new Point(418, 295);
            Choose.Margin = new Padding(4, 5, 4, 5);
            Choose.Name = "Choose";
            Choose.Size = new Size(749, 90);
            Choose.TabIndex = 1;
            Choose.UseVisualStyleBackColor = false;
            Choose.Click += Choose_Click;
            // 
            // BFS
            // 
            BFS.AutoSize = true;
            BFS.BackColor = Color.Transparent;
            BFS.Location = new Point(544, 458);
            BFS.Margin = new Padding(4, 5, 4, 5);
            BFS.Name = "BFS";
            BFS.Size = new Size(21, 20);
            BFS.TabIndex = 2;
            BFS.TabStop = true;
            BFS.UseVisualStyleBackColor = false;
            BFS.CheckedChanged += BFS_CheckedChanged;
            // 
            // DFS
            // 
            DFS.AutoSize = true;
            DFS.BackColor = Color.Transparent;
            DFS.Location = new Point(544, 562);
            DFS.Margin = new Padding(4, 5, 4, 5);
            DFS.Name = "DFS";
            DFS.Size = new Size(21, 20);
            DFS.TabIndex = 3;
            DFS.TabStop = true;
            DFS.UseVisualStyleBackColor = false;
            DFS.CheckedChanged += DFS_CheckedChanged;
            // 
            // TSP
            // 
            TSP.AutoSize = true;
            TSP.BackColor = Color.Transparent;
            TSP.Location = new Point(1019, 709);
            TSP.Margin = new Padding(4, 5, 4, 5);
            TSP.Name = "TSP";
            TSP.Size = new Size(22, 21);
            TSP.TabIndex = 4;
            TSP.UseVisualStyleBackColor = false;
            TSP.CheckedChanged += TSP_CheckedChanged;
            // 
            // name
            // 
            name.AutoSize = true;
            name.BackColor = Color.Transparent;
            name.Font = new Font("Candara", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            name.ForeColor = Color.White;
            name.Location = new Point(496, 382);
            name.Margin = new Padding(4, 0, 4, 0);
            name.Name = "name";
            name.Size = new Size(187, 35);
            name.TabIndex = 5;
            name.Text = "File Name: .txt";
            name.Click += name_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1578, 981);
            Controls.Add(name);
            Controls.Add(TSP);
            Controls.Add(DFS);
            Controls.Add(BFS);
            Controls.Add(Choose);
            Controls.Add(startButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
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
        private CheckBox TSP;
        private Label name;
    }
}