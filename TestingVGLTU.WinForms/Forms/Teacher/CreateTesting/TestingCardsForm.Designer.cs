namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting
{
    partial class TestingCardsForm
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
            flowLayoutPanelCards = new FlowLayoutPanel();
            panelCardAddTesting = new Panel();
            buttonAddTesting = new Button();
            flowLayoutPanelCards.SuspendLayout();
            panelCardAddTesting.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelCards
            // 
            flowLayoutPanelCards.AutoScroll = true;
            flowLayoutPanelCards.Controls.Add(panelCardAddTesting);
            flowLayoutPanelCards.Dock = DockStyle.Fill;
            flowLayoutPanelCards.Location = new Point(0, 0);
            flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            flowLayoutPanelCards.Padding = new Padding(10, 0, 0, 0);
            flowLayoutPanelCards.Size = new Size(1267, 598);
            flowLayoutPanelCards.TabIndex = 0;
            // 
            // panelCardAddTesting
            // 
            panelCardAddTesting.BackColor = Color.FromArgb(64, 64, 64);
            panelCardAddTesting.Controls.Add(buttonAddTesting);
            panelCardAddTesting.Location = new Point(20, 20);
            panelCardAddTesting.Margin = new Padding(10, 20, 10, 3);
            panelCardAddTesting.MaximumSize = new Size(392, 238);
            panelCardAddTesting.MinimumSize = new Size(392, 238);
            panelCardAddTesting.Name = "panelCardAddTesting";
            panelCardAddTesting.Size = new Size(392, 238);
            panelCardAddTesting.TabIndex = 1;
            // 
            // buttonAddTesting
            // 
            buttonAddTesting.BackColor = Color.FromArgb(84, 84, 84);
            buttonAddTesting.Cursor = Cursors.Hand;
            buttonAddTesting.FlatAppearance.BorderSize = 0;
            buttonAddTesting.FlatStyle = FlatStyle.Flat;
            buttonAddTesting.Image = Properties.Resources._;
            buttonAddTesting.Location = new Point(162, 83);
            buttonAddTesting.Name = "buttonAddTesting";
            buttonAddTesting.Size = new Size(68, 68);
            buttonAddTesting.TabIndex = 0;
            buttonAddTesting.UseVisualStyleBackColor = false;
            buttonAddTesting.Click += buttonAddTesting_Click;
            // 
            // TestingCardsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(1267, 598);
            Controls.Add(flowLayoutPanelCards);
            Name = "TestingCardsForm";
            Text = "TestingCardsForm";
            Load += TestingCardsForm_Load;
            flowLayoutPanelCards.ResumeLayout(false);
            panelCardAddTesting.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelCards;
        private Panel panelCardAddTesting;
        private Button buttonAddTesting;
    }
}