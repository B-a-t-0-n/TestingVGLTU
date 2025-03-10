using System.ComponentModel;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditTestingForm.CustomElement
{
    partial class GroupRow
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
            panel27 = new Panel();
            buttonRemove = new Button();
            labelGroup = new Label();
            panel27.SuspendLayout();
            SuspendLayout();
            // 
            // panel27
            // 
            panel27.BackColor = Color.FromArgb(84, 84, 84);
            panel27.Controls.Add(buttonRemove);
            panel27.Controls.Add(labelGroup);
            panel27.Location = new Point(0, 0);
            panel27.Margin = new Padding(0, 0, 0, 0);
            panel27.Name = "panel27";
            panel27.Size = new Size(270, 30);
            panel27.TabIndex = 2;
            // 
            // buttonRemove
            // 
            buttonRemove.BackColor = Color.FromArgb(84, 84, 84);
            buttonRemove.Cursor = Cursors.Hand;
            buttonRemove.FlatAppearance.BorderSize = 0;
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.ForeColor = Color.Black;
            buttonRemove.Image = Properties.Resources.Remove;
            buttonRemove.Location = new Point(212, 0);
            buttonRemove.Margin = new Padding(0, 0, 20, 0);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(30, 30);
            buttonRemove.TabIndex = 4;
            buttonRemove.UseVisualStyleBackColor = false;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelGroup.ForeColor = Color.White;
            labelGroup.Location = new Point(37, 0);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(118, 25);
            labelGroup.TabIndex = 3;
            labelGroup.Text = "ИС1-213-ОТ";
            // 
            // GroupRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel27);
            Name = "GroupRow";
            Size = new Size(270, 30);
            panel27.ResumeLayout(false);
            panel27.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        [Category("Data")]
        [Description("группа.")]
        public string Number
        {
            get { return labelGroup.Text; }
            set { labelGroup.Text = value; }
        }

        private Panel panel27;
        private Button buttonRemove;
        private Label labelGroup;

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

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            OnDeleteClicked(e);
        }
    }
}
