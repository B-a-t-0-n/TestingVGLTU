using System.ComponentModel;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditTestingForm.CustomElement
{
    partial class QuestionRow
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
            panel1 = new Panel();
            richTextBoxType = new RichTextBox();
            richTextBoxTextQuestion = new RichTextBox();
            labelNum = new Label();
            buttonDelete = new Button();
            buttonRedact = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(84, 84, 84);
            panel1.Controls.Add(buttonRedact);
            panel1.Controls.Add(buttonDelete);
            panel1.Controls.Add(richTextBoxType);
            panel1.Controls.Add(richTextBoxTextQuestion);
            panel1.Controls.Add(labelNum);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0, 10, 0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(929, 50);
            panel1.TabIndex = 4;
            // 
            // richTextBoxType
            // 
            richTextBoxType.BackColor = Color.FromArgb(84, 84, 84);
            richTextBoxType.BorderStyle = BorderStyle.None;
            richTextBoxType.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBoxType.ForeColor = Color.White;
            richTextBoxType.Location = new Point(572, 11);
            richTextBoxType.Name = "richTextBoxType";
            richTextBoxType.ReadOnly = true;
            richTextBoxType.RightToLeft = RightToLeft.No;
            richTextBoxType.Size = new Size(221, 25);
            richTextBoxType.TabIndex = 4;
            richTextBoxType.Text = "Одиночный выбор";
            // 
            // richTextBoxTextQuestion
            // 
            richTextBoxTextQuestion.BackColor = Color.FromArgb(84, 84, 84);
            richTextBoxTextQuestion.BorderStyle = BorderStyle.None;
            richTextBoxTextQuestion.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBoxTextQuestion.ForeColor = Color.White;
            richTextBoxTextQuestion.Location = new Point(111, 11);
            richTextBoxTextQuestion.Name = "richTextBoxTextQuestion";
            richTextBoxTextQuestion.ReadOnly = true;
            richTextBoxTextQuestion.Size = new Size(444, 25);
            richTextBoxTextQuestion.TabIndex = 3;
            richTextBoxTextQuestion.Text = "Текст вопроса...";
            // 
            // labelNum
            // 
            labelNum.AutoSize = true;
            labelNum.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelNum.ForeColor = Color.White;
            labelNum.Location = new Point(33, 11);
            labelNum.Name = "labelNum";
            labelNum.Size = new Size(22, 25);
            labelNum.TabIndex = 2;
            labelNum.Text = "1";
            // 
            // buttonDelete
            // 
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Image = Properties.Resources.Delete25I30;
            buttonDelete.Location = new Point(861, 0);
            buttonDelete.Margin = new Padding(0, 0, 23, 0);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(45, 50);
            buttonDelete.TabIndex = 5;
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRedact
            // 
            buttonRedact.Cursor = Cursors.Hand;
            buttonRedact.FlatAppearance.BorderSize = 0;
            buttonRedact.FlatStyle = FlatStyle.Flat;
            buttonRedact.Image = Properties.Resources.Create;
            buttonRedact.Location = new Point(803, 1);
            buttonRedact.Margin = new Padding(0, 0, 13, 0);
            buttonRedact.Name = "buttonRedact";
            buttonRedact.Size = new Size(45, 50);
            buttonRedact.TabIndex = 6;
            buttonRedact.UseVisualStyleBackColor = true;
            buttonRedact.Click += buttonCreateClicked_Click;
            // 
            // QuestionRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QuestionRow";
            Size = new Size(929, 50);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion


        [Category("Data")]
        [Description("Тип вопроса.")]
        public string TypeQuestion
        {
            get { return richTextBoxType.Text; }
            set { richTextBoxType.Text = value; }
        }

        [Category("Data")]
        [Description("Номер вопроса.")]
        public string Number
        {
            get { return labelNum.Text; }
            set { labelNum.Text = value; }
        }

        [Category("Data")]
        [Description("Вопрос.")]
        public string Question
        {
            get { return richTextBoxTextQuestion.Text; }
            set { richTextBoxTextQuestion.Text = value; }
        }

        private Panel panel1;
        private Label labelNum;
        private RichTextBox richTextBoxTextQuestion;
        private RichTextBox richTextBoxType;
        private Button buttonDelete;
        private Button buttonRedact;

        [Category("Action")]
        [Description("Кнопка для перехода к вопросу.")]
        public event EventHandler CreateClicked;

        protected virtual void OnCreateClicked(EventArgs e)
        {
            EventHandler handler = CreateClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        [Category("Action")]
        [Description("Кнопка для удаления.")]
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

        private void buttonCreateClicked_Click(object sender, EventArgs e)
        {
            OnCreateClicked(e);
        }
    }
}
