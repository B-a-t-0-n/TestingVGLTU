using System.ComponentModel;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion.TableElement
{
    partial class AnswerInputRow
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
            textBoxAnswer = new TextBox();
            buttonDelete = new Button();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(84, 84, 84);
            panel5.Controls.Add(textBoxAnswer);
            panel5.Controls.Add(buttonDelete);
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0, 0, 0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(736, 44);
            panel5.TabIndex = 4;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.BackColor = Color.FromArgb(74, 74, 74);
            textBoxAnswer.BorderStyle = BorderStyle.None;
            textBoxAnswer.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxAnswer.ForeColor = Color.White;
            textBoxAnswer.Location = new Point(7, 8);
            textBoxAnswer.Margin = new Padding(0);
            textBoxAnswer.Multiline = true;
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.Size = new Size(660, 28);
            textBoxAnswer.TabIndex = 3;
            // 
            // buttonDelete
            // 
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Image = Properties.Resources.Delete;
            buttonDelete.Location = new Point(680, 0);
            buttonDelete.Margin = new Padding(0);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(44, 44);
            buttonDelete.TabIndex = 0;
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // AnswerInputRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Margin = new Padding(0, 0, 0, 0);
            Name = "AnswerInputRow";
            Size = new Size(736, 44);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        [Category("Data")]
        [Description("Ответ")]
        public string Answer
        {
            get { return textBoxAnswer.Text; }
            set { textBoxAnswer.Text = value; }
        }

        private Panel panel5;
        private TextBox textBoxAnswer;
        private Button buttonDelete;

        [Category("Action")]
        [Description("Кнопка удаления")]
        public event EventHandler GoDeleteClicked;

        protected virtual void OnDeleteClicked(EventArgs e)
        {
            EventHandler handler = GoDeleteClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClicked(e);
        }
    }
}
