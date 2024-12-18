using System.ComponentModel;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditTestingForm.CustomElement
{
    partial class QuestionAdd
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
            panel22 = new Panel();
            buttonAddQuestion = new Button();
            panel22.SuspendLayout();
            SuspendLayout();
            // 
            // panel22
            // 
            panel22.BackColor = Color.FromArgb(84, 84, 84);
            panel22.Controls.Add(buttonAddQuestion);
            panel22.Location = new Point(0, 0);
            panel22.Margin = new Padding(0, 10, 0, 0);
            panel22.Name = "panel22";
            panel22.Size = new Size(929, 50);
            panel22.TabIndex = 4;
            // 
            // buttonAddQuestion
            // 
            buttonAddQuestion.BackColor = Color.FromArgb(74, 74, 74);
            buttonAddQuestion.Cursor = Cursors.Hand;
            buttonAddQuestion.FlatAppearance.BorderSize = 0;
            buttonAddQuestion.FlatStyle = FlatStyle.Flat;
            buttonAddQuestion.Image = Properties.Resources.___18_33_1;
            buttonAddQuestion.Location = new Point(443, 5);
            buttonAddQuestion.Name = "buttonAddQuestion";
            buttonAddQuestion.Size = new Size(42, 42);
            buttonAddQuestion.TabIndex = 0;
            buttonAddQuestion.UseVisualStyleBackColor = false;
            buttonAddQuestion.Click += buttonAdd_Click;
            // 
            // QuestionAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel22);
            Name = "QuestionAdd";
            Size = new Size(929, 50);
            panel22.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel22;
        private Button buttonAddQuestion;

        [Category("Action")]
        [Description("Кнопка добавления")]
        public event EventHandler GoAddClicked;

        protected virtual void OnAddClicked(EventArgs e)
        {
            EventHandler handler = GoAddClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OnAddClicked(e);
        }
    }
}
