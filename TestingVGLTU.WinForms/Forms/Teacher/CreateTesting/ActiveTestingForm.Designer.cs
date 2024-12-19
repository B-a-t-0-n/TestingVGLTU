namespace TestingVGLTU.WinForms.Forms.Teacher
{
    partial class ActiveTestingForm
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
            SuspendLayout();
            // 
            // flowLayoutPanelCards
            // 
            flowLayoutPanelCards.AutoScroll = true;
            flowLayoutPanelCards.Dock = DockStyle.Fill;
            flowLayoutPanelCards.Location = new Point(0, 0);
            flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            flowLayoutPanelCards.Padding = new Padding(10, 0, 0, 0);
            flowLayoutPanelCards.Size = new Size(1267, 598);
            flowLayoutPanelCards.TabIndex = 1;
            // 
            // ActiveTestingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(1267, 598);
            Controls.Add(flowLayoutPanelCards);
            Name = "ActiveTestingForm";
            Text = "ActiveTestingForm";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelCards;
    }
}