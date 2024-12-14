namespace TestingVGLTU.WinForms.Forms.Shared
{
    partial class MainForm
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
            panelLeft = new Panel();
            flowLayoutPanelNawButtons = new FlowLayoutPanel();
            buttonHome = new Button();
            buttonMail = new Button();
            buttonActiveStudent = new Button();
            buttonCreateTesting = new Button();
            buttonActiveTeacher = new Button();
            panel1 = new Panel();
            pictureBoxLogo = new PictureBox();
            buttonExit = new Button();
            panelTop = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            buttonBack = new Button();
            panelCenter = new Panel();
            panelLeft.SuspendLayout();
            flowLayoutPanelNawButtons.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelTop.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(64, 64, 64);
            panelLeft.Controls.Add(flowLayoutPanelNawButtons);
            panelLeft.Controls.Add(panel1);
            panelLeft.Controls.Add(buttonExit);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(82, 651);
            panelLeft.TabIndex = 0;
            // 
            // flowLayoutPanelNawButtons
            // 
            flowLayoutPanelNawButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanelNawButtons.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanelNawButtons.Controls.Add(buttonHome);
            flowLayoutPanelNawButtons.Controls.Add(buttonMail);
            flowLayoutPanelNawButtons.Controls.Add(buttonActiveStudent);
            flowLayoutPanelNawButtons.Controls.Add(buttonCreateTesting);
            flowLayoutPanelNawButtons.Controls.Add(buttonActiveTeacher);
            flowLayoutPanelNawButtons.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelNawButtons.Location = new Point(0, 88);
            flowLayoutPanelNawButtons.Margin = new Padding(3, 3, 5, 3);
            flowLayoutPanelNawButtons.Name = "flowLayoutPanelNawButtons";
            flowLayoutPanelNawButtons.Size = new Size(82, 506);
            flowLayoutPanelNawButtons.TabIndex = 2;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.FromArgb(84, 84, 84);
            buttonHome.Cursor = Cursors.Hand;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Image = Properties.Resources.Home;
            buttonHome.Location = new Point(0, 0);
            buttonHome.Margin = new Padding(0, 0, 0, 10);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(82, 60);
            buttonHome.TabIndex = 0;
            buttonHome.UseVisualStyleBackColor = false;
            // 
            // buttonMail
            // 
            buttonMail.BackColor = Color.FromArgb(84, 84, 84);
            buttonMail.Cursor = Cursors.Hand;
            buttonMail.FlatAppearance.BorderSize = 0;
            buttonMail.FlatStyle = FlatStyle.Flat;
            buttonMail.Image = Properties.Resources.Mail;
            buttonMail.Location = new Point(0, 70);
            buttonMail.Margin = new Padding(0, 0, 0, 10);
            buttonMail.Name = "buttonMail";
            buttonMail.Size = new Size(82, 60);
            buttonMail.TabIndex = 1;
            buttonMail.UseVisualStyleBackColor = false;
            // 
            // buttonActiveStudent
            // 
            buttonActiveStudent.BackColor = Color.FromArgb(84, 84, 84);
            buttonActiveStudent.Cursor = Cursors.Hand;
            buttonActiveStudent.FlatAppearance.BorderSize = 0;
            buttonActiveStudent.FlatStyle = FlatStyle.Flat;
            buttonActiveStudent.Image = Properties.Resources.Active;
            buttonActiveStudent.Location = new Point(0, 140);
            buttonActiveStudent.Margin = new Padding(0, 0, 0, 10);
            buttonActiveStudent.Name = "buttonActiveStudent";
            buttonActiveStudent.Size = new Size(82, 60);
            buttonActiveStudent.TabIndex = 2;
            buttonActiveStudent.UseVisualStyleBackColor = false;
            // 
            // buttonCreateTesting
            // 
            buttonCreateTesting.BackColor = Color.FromArgb(84, 84, 84);
            buttonCreateTesting.Cursor = Cursors.Hand;
            buttonCreateTesting.FlatAppearance.BorderSize = 0;
            buttonCreateTesting.FlatStyle = FlatStyle.Flat;
            buttonCreateTesting.Image = Properties.Resources.Create;
            buttonCreateTesting.Location = new Point(0, 210);
            buttonCreateTesting.Margin = new Padding(0, 0, 0, 10);
            buttonCreateTesting.Name = "buttonCreateTesting";
            buttonCreateTesting.Size = new Size(82, 60);
            buttonCreateTesting.TabIndex = 3;
            buttonCreateTesting.UseVisualStyleBackColor = false;
            // 
            // buttonActiveTeacher
            // 
            buttonActiveTeacher.BackColor = Color.FromArgb(84, 84, 84);
            buttonActiveTeacher.Cursor = Cursors.Hand;
            buttonActiveTeacher.FlatAppearance.BorderSize = 0;
            buttonActiveTeacher.FlatStyle = FlatStyle.Flat;
            buttonActiveTeacher.Image = Properties.Resources.Active;
            buttonActiveTeacher.Location = new Point(0, 280);
            buttonActiveTeacher.Margin = new Padding(0, 0, 0, 10);
            buttonActiveTeacher.Name = "buttonActiveTeacher";
            buttonActiveTeacher.Size = new Size(82, 60);
            buttonActiveTeacher.TabIndex = 4;
            buttonActiveTeacher.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBoxLogo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(82, 82);
            panel1.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Anchor = AnchorStyles.None;
            pictureBoxLogo.Image = Properties.Resources.logo_2_1;
            pictureBoxLogo.Location = new Point(12, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 60);
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // buttonExit
            // 
            buttonExit.Cursor = Cursors.Hand;
            buttonExit.Dock = DockStyle.Bottom;
            buttonExit.FlatAppearance.BorderColor = Color.White;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonExit.ForeColor = Color.White;
            buttonExit.Image = Properties.Resources.Vector;
            buttonExit.Location = new Point(0, 600);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(82, 51);
            buttonExit.TabIndex = 0;
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(panel2);
            panelTop.Controls.Add(buttonBack);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(82, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1185, 65);
            panelTop.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(917, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(268, 65);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(84, 84, 84);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(268, 50);
            panel4.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(0, 35);
            label1.TabIndex = 0;
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.FromArgb(84, 84, 84);
            buttonBack.Cursor = Cursors.Hand;
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonBack.ForeColor = Color.White;
            buttonBack.Image = Properties.Resources.Back;
            buttonBack.Location = new Point(25, 0);
            buttonBack.Margin = new Padding(25, 3, 3, 3);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(65, 65);
            buttonBack.TabIndex = 0;
            buttonBack.UseVisualStyleBackColor = false;
            // 
            // panelCenter
            // 
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Location = new Point(82, 65);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(1185, 586);
            panelCenter.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(1267, 651);
            Controls.Add(panelCenter);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            MinimumSize = new Size(1283, 690);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            panelLeft.ResumeLayout(false);
            flowLayoutPanelNawButtons.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelTop.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelTop;
        private Button buttonExit;
        private Panel panelCenter;
        private Panel panel1;
        private PictureBox pictureBoxLogo;
        private FlowLayoutPanel flowLayoutPanelNawButtons;
        private Button buttonHome;
        private Button buttonMail;
        private Button buttonActiveStudent;
        private Button buttonCreateTesting;
        private Button buttonActiveTeacher;
        private Button buttonBack;
        private Panel panel2;
        private Panel panel4;
        private Label label1;
    }
}