namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion
{
    partial class EditQuestionForm
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
            panel1 = new Panel();
            panel5 = new Panel();
            buttonCraeate = new Button();
            flowLayoutPanelQuestion = new FlowLayoutPanel();
            panel2 = new Panel();
            label6 = new Label();
            panel9 = new Panel();
            textBoxName = new TextBox();
            labelName = new Label();
            panel7 = new Panel();
            comboBoxCustomType = new WinformsElements.ComboBoxCustom();
            labelType = new Label();
            panel16 = new Panel();
            labelScore = new Label();
            textBoxScore = new TextBox();
            panel3 = new Panel();
            label2 = new Label();
            panel4 = new Panel();
            labelTableColumAnswer = new Label();
            flowLayoutPanelAnswers = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            flowLayoutPanelQuestion.SuspendLayout();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel16.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(flowLayoutPanelQuestion);
            panel1.Location = new Point(160, 63);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 587);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(buttonCraeate);
            panel5.Location = new Point(27, 525);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(736, 48);
            panel5.TabIndex = 1;
            // 
            // buttonCraeate
            // 
            buttonCraeate.BackColor = Color.FromArgb(53, 128, 56);
            buttonCraeate.Cursor = Cursors.Hand;
            buttonCraeate.Dock = DockStyle.Right;
            buttonCraeate.FlatAppearance.BorderSize = 0;
            buttonCraeate.FlatStyle = FlatStyle.Flat;
            buttonCraeate.Font = new Font("Segoe UI", 14.25F);
            buttonCraeate.ForeColor = Color.White;
            buttonCraeate.Location = new Point(613, 0);
            buttonCraeate.Name = "buttonCraeate";
            buttonCraeate.Size = new Size(123, 48);
            buttonCraeate.TabIndex = 0;
            buttonCraeate.Text = "Создать";
            buttonCraeate.UseVisualStyleBackColor = false;
            buttonCraeate.Click += buttonCraeate_Click;
            // 
            // flowLayoutPanelQuestion
            // 
            flowLayoutPanelQuestion.Controls.Add(panel2);
            flowLayoutPanelQuestion.Controls.Add(panel9);
            flowLayoutPanelQuestion.Controls.Add(panel7);
            flowLayoutPanelQuestion.Controls.Add(panel16);
            flowLayoutPanelQuestion.Controls.Add(panel3);
            flowLayoutPanelQuestion.Controls.Add(flowLayoutPanelAnswers);
            flowLayoutPanelQuestion.Location = new Point(27, 15);
            flowLayoutPanelQuestion.Name = "flowLayoutPanelQuestion";
            flowLayoutPanelQuestion.Size = new Size(736, 512);
            flowLayoutPanelQuestion.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(736, 40);
            panel2.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(248, 37);
            label6.TabIndex = 3;
            label6.Text = "Создание вопроса";
            // 
            // panel9
            // 
            panel9.Controls.Add(textBoxName);
            panel9.Controls.Add(labelName);
            panel9.Location = new Point(0, 50);
            panel9.Margin = new Padding(0, 10, 0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(736, 92);
            panel9.TabIndex = 3;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.FromArgb(84, 84, 84);
            textBoxName.BorderStyle = BorderStyle.None;
            textBoxName.Dock = DockStyle.Bottom;
            textBoxName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxName.ForeColor = Color.White;
            textBoxName.Location = new Point(0, 28);
            textBoxName.Margin = new Padding(0);
            textBoxName.Multiline = true;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(736, 64);
            textBoxName.TabIndex = 2;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelName.ForeColor = Color.White;
            labelName.Location = new Point(3, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(136, 25);
            labelName.TabIndex = 1;
            labelName.Text = "Текст вопроса";
            // 
            // panel7
            // 
            panel7.Controls.Add(comboBoxCustomType);
            panel7.Controls.Add(labelType);
            panel7.Location = new Point(0, 147);
            panel7.Margin = new Padding(0, 5, 0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(293, 54);
            panel7.TabIndex = 4;
            // 
            // comboBoxCustomType
            // 
            comboBoxCustomType.BackColor = Color.FromArgb(84, 84, 84);
            comboBoxCustomType.BorderColor = Color.FromArgb(84, 84, 84);
            comboBoxCustomType.BorderSize = 0;
            comboBoxCustomType.Dock = DockStyle.Bottom;
            comboBoxCustomType.FlatStyle = FlatStyle.Flat;
            comboBoxCustomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxCustomType.ForeColor = Color.White;
            comboBoxCustomType.FormattingEnabled = true;
            comboBoxCustomType.IconColor = Color.FromArgb(76, 175, 80);
            comboBoxCustomType.ListBackColor = Color.FromArgb(84, 84, 84);
            comboBoxCustomType.ListTextColor = Color.White;
            comboBoxCustomType.Location = new Point(0, 25);
            comboBoxCustomType.MinimumSize = new Size(200, 0);
            comboBoxCustomType.Name = "comboBoxCustomType";
            comboBoxCustomType.Size = new Size(293, 29);
            comboBoxCustomType.TabIndex = 17;
            comboBoxCustomType.Texts = "";
            comboBoxCustomType.OnSelectedIndexChanged += comboBoxCustomType_OnSelectedIndexChanged;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelType.ForeColor = Color.White;
            labelType.Location = new Point(3, 0);
            labelType.Name = "labelType";
            labelType.Size = new Size(122, 25);
            labelType.TabIndex = 1;
            labelType.Text = "Тип вопроса";
            // 
            // panel16
            // 
            panel16.Controls.Add(labelScore);
            panel16.Controls.Add(textBoxScore);
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(308, 147);
            panel16.Margin = new Padding(15, 5, 0, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(135, 54);
            panel16.TabIndex = 5;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelScore.ForeColor = Color.White;
            labelScore.Location = new Point(3, 0);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(66, 25);
            labelScore.TabIndex = 1;
            labelScore.Text = "Баллы";
            // 
            // textBoxScore
            // 
            textBoxScore.BackColor = Color.FromArgb(84, 84, 84);
            textBoxScore.BorderStyle = BorderStyle.None;
            textBoxScore.Dock = DockStyle.Bottom;
            textBoxScore.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxScore.ForeColor = Color.White;
            textBoxScore.Location = new Point(0, 26);
            textBoxScore.Name = "textBoxScore";
            textBoxScore.Size = new Size(135, 28);
            textBoxScore.TabIndex = 0;
            textBoxScore.KeyPress += TextBoxNum_KeyPress;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(labelTableColumAnswer);
            panel3.Location = new Point(0, 211);
            panel3.Margin = new Padding(0, 10, 0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(736, 32);
            panel3.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(500, 2);
            label2.Name = "label2";
            label2.Size = new Size(184, 25);
            label2.TabIndex = 4;
            label2.Text = "правильные ответы";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 30);
            panel4.Name = "panel4";
            panel4.Size = new Size(736, 2);
            panel4.TabIndex = 3;
            // 
            // labelTableColumAnswer
            // 
            labelTableColumAnswer.AutoSize = true;
            labelTableColumAnswer.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTableColumAnswer.ForeColor = Color.White;
            labelTableColumAnswer.Location = new Point(156, 2);
            labelTableColumAnswer.Name = "labelTableColumAnswer";
            labelTableColumAnswer.Size = new Size(169, 25);
            labelTableColumAnswer.TabIndex = 2;
            labelTableColumAnswer.Text = "варианты ответов";
            // 
            // flowLayoutPanelAnswers
            // 
            flowLayoutPanelAnswers.AutoScroll = true;
            flowLayoutPanelAnswers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelAnswers.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelAnswers.Location = new Point(0, 253);
            flowLayoutPanelAnswers.Margin = new Padding(0, 10, 0, 0);
            flowLayoutPanelAnswers.Name = "flowLayoutPanelAnswers";
            flowLayoutPanelAnswers.Size = new Size(736, 257);
            flowLayoutPanelAnswers.TabIndex = 7;
            // 
            // EditQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(1145, 712);
            Controls.Add(panel1);
            Name = "EditQuestionForm";
            Text = "EditQuestionForm";
            Load += EditQuestionForm_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            flowLayoutPanelQuestion.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanelQuestion;
        private Panel panel2;
        private Label label6;
        private Panel panel9;
        private TextBox textBoxName;
        private Label labelName;
        private Panel panel7;
        private WinformsElements.ComboBoxCustom comboBoxCustomType;
        private Label labelType;
        private Panel panel16;
        private Label labelScore;
        private TextBox textBoxScore;
        private Panel panel3;
        private Label label2;
        private Panel panel4;
        private Label labelTableColumAnswer;
        private FlowLayoutPanel flowLayoutPanelAnswers;
        private Panel panel5;
        private Button buttonCraeate;
    }
}