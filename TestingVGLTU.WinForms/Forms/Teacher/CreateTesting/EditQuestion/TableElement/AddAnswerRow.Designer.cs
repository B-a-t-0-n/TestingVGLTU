using System.ComponentModel;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion.TableElement
{
    partial class AddAnswerRow
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
            panel5 = new Panel();
            buttonAddAnswer = new Button();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(84, 84, 84);
            panel5.Controls.Add(buttonAddAnswer);
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0, 8, 0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(736, 44);
            panel5.TabIndex = 1;
            // 
            // buttonAddAnswer
            // 
            buttonAddAnswer.BackColor = Color.FromArgb(74, 74, 74);
            buttonAddAnswer.Cursor = Cursors.Hand;
            buttonAddAnswer.FlatAppearance.BorderSize = 0;
            buttonAddAnswer.FlatStyle = FlatStyle.Flat;
            buttonAddAnswer.Image = Properties.Resources.___18_33_1;
            buttonAddAnswer.Location = new Point(344, 3);
            buttonAddAnswer.Margin = new Padding(0);
            buttonAddAnswer.Name = "buttonAddAnswer";
            buttonAddAnswer.Size = new Size(42, 40);
            buttonAddAnswer.TabIndex = 1;
            buttonAddAnswer.UseVisualStyleBackColor = false;
            buttonAddAnswer.Click += buttonAdd_Click;
            // 
            // AddAnswerRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Margin = new Padding(0, 0, 0, 0);
            Name = "AddAnswerRow";
            Size = new Size(736, 44);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private Button buttonAddAnswer;

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
