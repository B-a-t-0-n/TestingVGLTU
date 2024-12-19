using System.ComponentModel;

namespace TestingVGLTU.WinForms.Forms.Shared.Cards
{
    public partial class RedactTestingCard : UserControl
    {
        public RedactTestingCard()
        {
            InitializeComponent();
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            panelCard = new Panel();
            panel8 = new Panel();
            labelAttempts = new Label();
            labelTimeTesting = new Label();
            labelTeacherName = new Label();
            panel9 = new Panel();
            richTextBoxNameTesting = new RichTextBox();
            panel7 = new Panel();
            panel6 = new Panel();
            panel10 = new Panel();
            buttonDelete = new Button();
            labelTypeTesting = new Label();
            panel1 = new Panel();
            buttonGoOver = new Button();
            panelCard.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
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
            panelCard.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(labelAttempts);
            panel8.Controls.Add(labelTimeTesting);
            panel8.Controls.Add(labelTeacherName);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 55);
            panel8.Name = "panel8";
            panel8.Size = new Size(392, 138);
            panel8.TabIndex = 3;
            // 
            // labelAttempts
            // 
            labelAttempts.AutoSize = true;
            labelAttempts.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelAttempts.ForeColor = Color.White;
            labelAttempts.Location = new Point(12, 110);
            labelAttempts.Name = "labelAttempts";
            labelAttempts.Size = new Size(88, 21);
            labelAttempts.TabIndex = 3;
            labelAttempts.Text = "Попытки: 3";
            // 
            // labelTimeTesting
            // 
            labelTimeTesting.AutoSize = true;
            labelTimeTesting.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTimeTesting.ForeColor = Color.White;
            labelTimeTesting.Location = new Point(12, 89);
            labelTimeTesting.Name = "labelTimeTesting";
            labelTimeTesting.Size = new Size(113, 21);
            labelTimeTesting.TabIndex = 2;
            labelTimeTesting.Text = "Время: 45 мин";
            // 
            // labelTeacherName
            // 
            labelTeacherName.AutoSize = true;
            labelTeacherName.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTeacherName.ForeColor = Color.White;
            labelTeacherName.Location = new Point(12, 68);
            labelTeacherName.Name = "labelTeacherName";
            labelTeacherName.Size = new Size(217, 21);
            labelTeacherName.TabIndex = 1;
            labelTeacherName.Text = "Преподаватель: Иванов И.И ";
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
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(labelTypeTesting);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(392, 53);
            panel6.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(buttonDelete);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(323, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(69, 53);
            panel10.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(64, 64, 64);
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Image = Properties.Resources.Delete;
            buttonDelete.Location = new Point(23, 11);
            buttonDelete.Margin = new Padding(3, 3, 12, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(34, 34);
            buttonDelete.TabIndex = 1;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
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
            buttonGoOver.BackColor = Color.FromArgb(53, 128, 56);
            buttonGoOver.Cursor = Cursors.Hand;
            buttonGoOver.Dock = DockStyle.Right;
            buttonGoOver.FlatAppearance.BorderSize = 0;
            buttonGoOver.FlatStyle = FlatStyle.Flat;
            buttonGoOver.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonGoOver.ForeColor = Color.White;
            buttonGoOver.Location = new Point(242, 0);
            buttonGoOver.Name = "buttonGoOver";
            buttonGoOver.Size = new Size(150, 45);
            buttonGoOver.TabIndex = 0;
            buttonGoOver.Text = "Перейти";
            buttonGoOver.UseVisualStyleBackColor = false;
            buttonGoOver.Click += buttonGoOver_Click;
            // 
            // TestingCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCard);
            Margin = new Padding(10, 20, 10, 3);
            MaximumSize = new Size(392, 238);
            MinimumSize = new Size(392, 238);
            Name = "TestingCard";
            Size = new Size(392, 238);
            panelCard.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel10.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        [Category("Data")]
        [Description("Тип тестирования.")]
        public string TypeTesting
        {
            get { return labelTypeTesting.Text; }
            set { labelTypeTesting.Text = value; }
        }

        [Category("Data")]
        [Description("Название тестирования.")]
        public string TestingName
        {
            get { return richTextBoxNameTesting.Text; }
            set { richTextBoxNameTesting.Text = value; }
        }

        [Category("Data")]
        [Description("Имя преподавателя.")]
        public string TeacherName
        {
            get { return labelTeacherName.Text; }
            set { labelTeacherName.Text = $"Преподаватель: {value}"; }
        }

        [Category("Data")]
        [Description("Оставшееся время на тестирование.")]
        public string TimeRemaining
        {
            get { return labelTimeTesting.Text; }
            set { labelTimeTesting.Text = $"Время: {value} мин"; }
        }

        [Category("Data")]
        [Description("Количество оставшихся попыток.")]
        public string AttemptsLeft
        {
            get { return labelAttempts.Text; }
            set { labelAttempts.Text = $"Попытки: {value}"; }
        }

        private Panel panelCard;
        private Panel panel8;
        private Label labelAttempts;
        private Label labelTimeTesting;
        private Label labelTeacherName;
        private Panel panel9;
        private RichTextBox richTextBoxNameTesting;
        private Panel panel7;
        private Panel panel6;
        private Panel panel10;
        private Button buttonDelete;
        private Label labelTypeTesting;
        private Panel panel1;
        private Button buttonGoOver;

        [Category("Action")]
        [Description("Кнопка для перехода к тестированию.")]
        public event EventHandler GoOverClicked;

        protected virtual void OnGoOverClicked(EventArgs e)
        {
            EventHandler handler = GoOverClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        [Category("Action")]
        [Description("Кнопка для удаления карточки.")]
        public event EventHandler DeleteClicked;

        protected virtual void OnDeleteClicked(EventArgs e)
        {
            EventHandler handler = DeleteClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClicked(e);
        }

        private void buttonGoOver_Click(object sender, EventArgs e)
        {
            OnGoOverClicked(e);
        }

    }
}
