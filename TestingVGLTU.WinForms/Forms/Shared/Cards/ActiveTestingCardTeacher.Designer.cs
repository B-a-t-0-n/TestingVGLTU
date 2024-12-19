namespace TestingVGLTU.WinForms.Forms.Teacher.Cards
{
    partial class ActiveTestingCardTeacher
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panelCard = new Panel();
            panel8 = new Panel();
            labelTimeTesting = new Label();
            labelTeacherName = new Label();
            panel9 = new Panel();
            richTextBoxNameTesting = new RichTextBox();
            panel7 = new Panel();
            panel6 = new Panel();
            labelTypeTesting = new Label();
            panel1 = new Panel();
            buttonGoOver = new Button();
            panelCard.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(64, 64, 64);
            panelCard.Controls.Add(panel8);
            panelCard.Controls.Add(panel7);
            panelCard.Controls.Add(panel6);
            panelCard.Controls.Add(panel1);
            panelCard.Dock = DockStyle.Fill;
            panelCard.Location = new Point(0, 0);
            panelCard.Margin = new Padding(10, 20, 10, 3);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(392, 238);
            panelCard.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.Controls.Add(labelTimeTesting);
            panel8.Controls.Add(labelTeacherName);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 55);
            panel8.Name = "panel8";
            panel8.Size = new Size(392, 138);
            panel8.TabIndex = 3;
            // 
            // labelTimeTesting
            // 
            labelTimeTesting.AutoSize = true;
            labelTimeTesting.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTimeTesting.ForeColor = Color.White;
            labelTimeTesting.Location = new Point(12, 103);
            labelTimeTesting.Name = "labelTimeTesting";
            labelTimeTesting.Size = new Size(108, 21);
            labelTimeTesting.TabIndex = 2;
            labelTimeTesting.Text = "Пройденых: 0";
            // 
            // labelTeacherName
            // 
            labelTeacherName.AutoSize = true;
            labelTeacherName.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTeacherName.ForeColor = Color.White;
            labelTeacherName.Location = new Point(12, 76);
            labelTeacherName.Name = "labelTeacherName";
            labelTeacherName.Size = new Size(93, 21);
            labelTeacherName.TabIndex = 1;
            labelTeacherName.Text = "Активных: 0";
            // 
            // panel9
            // 
            panel9.Controls.Add(richTextBoxNameTesting);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(392, 73);
            panel9.TabIndex = 0;
            // 
            // richTextBoxNameTesting
            // 
            richTextBoxNameTesting.BackColor = Color.FromArgb(64, 64, 64);
            richTextBoxNameTesting.BorderStyle = BorderStyle.None;
            richTextBoxNameTesting.Font = new Font("Segoe UI", 15.4F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBoxNameTesting.ForeColor = Color.White;
            richTextBoxNameTesting.Location = new Point(12, 6);
            richTextBoxNameTesting.Name = "richTextBoxNameTesting";
            richTextBoxNameTesting.ReadOnly = true;
            richTextBoxNameTesting.Size = new Size(367, 64);
            richTextBoxNameTesting.TabIndex = 0;
            richTextBoxNameTesting.Text = "Проектирование и дизайн инф. систем";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(53, 128, 56);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 53);
            panel7.Name = "panel7";
            panel7.Size = new Size(392, 2);
            panel7.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.Controls.Add(labelTypeTesting);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(392, 53);
            panel6.TabIndex = 1;
            // 
            // labelTypeTesting
            // 
            labelTypeTesting.AutoSize = true;
            labelTypeTesting.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTypeTesting.ForeColor = Color.White;
            labelTypeTesting.Location = new Point(12, 11);
            labelTypeTesting.Name = "labelTypeTesting";
            labelTypeTesting.Size = new Size(59, 32);
            labelTypeTesting.TabIndex = 0;
            labelTypeTesting.Text = "Тест";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonGoOver);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 193);
            panel1.Name = "panel1";
            panel1.Size = new Size(392, 45);
            panel1.TabIndex = 0;
            // 
            // buttonGoOver
            // 
            buttonGoOver.BackColor = Color.FromArgb(84, 84, 84);
            buttonGoOver.Cursor = Cursors.Hand;
            buttonGoOver.Dock = DockStyle.Right;
            buttonGoOver.FlatAppearance.BorderSize = 0;
            buttonGoOver.FlatStyle = FlatStyle.Flat;
            buttonGoOver.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonGoOver.ForeColor = Color.White;
            buttonGoOver.Location = new Point(218, 0);
            buttonGoOver.Name = "buttonGoOver";
            buttonGoOver.Size = new Size(174, 45);
            buttonGoOver.TabIndex = 0;
            buttonGoOver.Text = "Завершить";
            buttonGoOver.UseVisualStyleBackColor = false;
            // 
            // ActiveTestingCardTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCard);
            Name = "ActiveTestingCardTeacher";
            Size = new Size(392, 238);
            panelCard.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private Panel panel8;
        private Label labelTimeTesting;
        private Label labelTeacherName;
        private Panel panel9;
        private RichTextBox richTextBoxNameTesting;
        private Panel panel7;
        private Panel panel6;
        private Label labelTypeTesting;
        private Panel panel1;
        private Button buttonGoOver;
    }
}
