namespace WinFormsApp1
{
    partial class displayForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(displayForm));
            dataGridView1 = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            Route = new Button();
            search = new Button();
            back = new Button();
            show = new Button();
            runtime = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AccessibleRole = AccessibleRole.None;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Transparent;
            dataGridViewCellStyle2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(605, 173);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new Size(606, 528);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(220, 178);
            label4.Name = "label4";
            label4.Size = new Size(17, 22);
            label4.TabIndex = 7;
            label4.Text = "x";
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 176);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 27);
            textBox1.TabIndex = 6;
            textBox1.Text = "1,00";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = SystemColors.ButtonFace;
            trackBar1.Cursor = Cursors.Hand;
            trackBar1.Location = new Point(151, 209);
            trackBar1.Maximum = 1000;
            trackBar1.Minimum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeft = RightToLeft.No;
            trackBar1.Size = new Size(402, 56);
            trackBar1.TabIndex = 5;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Value = 100;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // Route
            // 
            Route.BackColor = Color.Transparent;
            Route.BackgroundImageLayout = ImageLayout.Center;
            Route.Cursor = Cursors.Hand;
            Route.FlatAppearance.BorderSize = 0;
            Route.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Route.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Route.FlatStyle = FlatStyle.Flat;
            Route.ForeColor = Color.Transparent;
            Route.Location = new Point(34, 486);
            Route.Margin = new Padding(3, 4, 3, 4);
            Route.Name = "Route";
            Route.Size = new Size(253, 63);
            Route.TabIndex = 8;
            Route.UseVisualStyleBackColor = false;
            Route.Click += Route_Click;
            // 
            // search
            // 
            search.BackColor = Color.Transparent;
            search.BackgroundImageLayout = ImageLayout.Center;
            search.Cursor = Cursors.Hand;
            search.FlatAppearance.BorderSize = 0;
            search.FlatAppearance.MouseDownBackColor = Color.Transparent;
            search.FlatAppearance.MouseOverBackColor = Color.Transparent;
            search.FlatStyle = FlatStyle.Flat;
            search.ForeColor = Color.Transparent;
            search.Location = new Point(295, 486);
            search.Margin = new Padding(3, 4, 3, 4);
            search.Name = "search";
            search.Size = new Size(253, 63);
            search.TabIndex = 9;
            search.UseVisualStyleBackColor = false;
            search.Click += search_Click;
            // 
            // back
            // 
            back.BackColor = Color.Transparent;
            back.BackgroundImageLayout = ImageLayout.Center;
            back.Cursor = Cursors.Hand;
            back.FlatAppearance.BorderSize = 0;
            back.FlatAppearance.MouseDownBackColor = Color.Transparent;
            back.FlatAppearance.MouseOverBackColor = Color.Transparent;
            back.FlatStyle = FlatStyle.Flat;
            back.ForeColor = Color.Transparent;
            back.Location = new Point(48, 29);
            back.Margin = new Padding(3, 4, 3, 4);
            back.Name = "back";
            back.Size = new Size(69, 63);
            back.TabIndex = 10;
            back.UseVisualStyleBackColor = false;
            back.Click += back_Click;
            // 
            // show
            // 
            show.BackColor = Color.Transparent;
            show.BackgroundImageLayout = ImageLayout.Center;
            show.Cursor = Cursors.Hand;
            show.FlatAppearance.BorderSize = 0;
            show.FlatAppearance.MouseDownBackColor = Color.Transparent;
            show.FlatAppearance.MouseOverBackColor = Color.Transparent;
            show.FlatStyle = FlatStyle.Flat;
            show.ForeColor = Color.Transparent;
            show.Location = new Point(34, 419);
            show.Margin = new Padding(3, 4, 3, 4);
            show.Name = "show";
            show.Size = new Size(514, 62);
            show.TabIndex = 11;
            show.UseVisualStyleBackColor = false;
            show.Click += show_Click;
            // 
            // runtime
            // 
            runtime.AutoSize = true;
            runtime.BackColor = Color.Transparent;
            runtime.Font = new Font("Impact", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            runtime.Location = new Point(179, 670);
            runtime.Name = "runtime";
            runtime.Size = new Size(19, 28);
            runtime.TabIndex = 12;
            runtime.Text = "-";
            runtime.Click += runtime_Click;
            // 
            // displayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 785);
            Controls.Add(runtime);
            Controls.Add(show);
            Controls.Add(back);
            Controls.Add(search);
            Controls.Add(Route);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(trackBar1);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "displayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maze Solver";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private TextBox textBox1;
        private TrackBar trackBar1;
        private Button Route;
        private Button search;
        private Button back;
        private Button show;
        private Label runtime;
    }
}