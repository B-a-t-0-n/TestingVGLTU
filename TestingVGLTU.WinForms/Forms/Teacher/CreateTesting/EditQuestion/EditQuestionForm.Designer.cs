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
            flowLayoutPanel1 = new FlowLayoutPanel();
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
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            answerInputRow1 = new TableElement.AnswerInputRow();
            answerTestRow1 = new TableElement.AnswerTestRow();
            addAnswerRow1 = new TableElement.AddAnswerRow();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel16.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(158, 81);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 546);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel9);
            flowLayoutPanel1.Controls.Add(panel7);
            flowLayoutPanel1.Controls.Add(panel16);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Location = new Point(27, 15);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(736, 510);
            flowLayoutPanel1.TabIndex = 0;
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
            panel3.Controls.Add(label1);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(156, 2);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 2;
            label1.Text = "варианты ответов";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(answerInputRow1);
            flowLayoutPanel2.Controls.Add(answerTestRow1);
            flowLayoutPanel2.Controls.Add(addAnswerRow1);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(0, 253);
            flowLayoutPanel2.Margin = new Padding(0, 10, 0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(736, 257);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // answerInputRow1
            // 
            answerInputRow1.Answer = "";
            answerInputRow1.Location = new Point(0, 10);
            answerInputRow1.Margin = new Padding(0, 10, 0, 0);
            answerInputRow1.Name = "answerInputRow1";
            answerInputRow1.Size = new Size(736, 44);
            answerInputRow1.TabIndex = 0;
            // 
            // answerTestRow1
            // 
            answerTestRow1.Answer = "";
            answerTestRow1.Location = new Point(0, 64);
            answerTestRow1.Margin = new Padding(0, 10, 0, 0);
            answerTestRow1.Name = "answerTestRow1";
            answerTestRow1.RightAnswer = false;
            answerTestRow1.Size = new Size(736, 44);
            answerTestRow1.TabIndex = 1;
            // 
            // addAnswerRow1
            // 
            addAnswerRow1.Location = new Point(0, 118);
            addAnswerRow1.Margin = new Padding(0, 10, 0, 0);
            addAnswerRow1.Name = "addAnswerRow1";
            addAnswerRow1.Size = new Size(736, 44);
            addAnswerRow1.TabIndex = 2;
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
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
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
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
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
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableElement.AnswerInputRow answerInputRow1;
        private TableElement.AnswerTestRow answerTestRow1;
        private TableElement.AddAnswerRow addAnswerRow1;
    }
}