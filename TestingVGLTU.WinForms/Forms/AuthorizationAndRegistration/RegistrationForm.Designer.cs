using TestingVGLTU.WinForms.WinformsElements;

namespace TestingVGLTU.WinForms.Forms.AuthorizationAndRegistration
{
    partial class RegistrationForm
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
            panel4 = new Panel();
            comboBoxCustomGroup = new ComboBoxCustom();
            labelNameTextBoxNumberBook = new Label();
            labelNameTextBoxGroup = new Label();
            textBoxNumberBook = new TextBox();
            label5 = new Label();
            textBoxPatronomic = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBoxSurname = new TextBox();
            textBoxName = new TextBox();
            label4 = new Label();
            textBoxRepeatPassword = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            panel3 = new Panel();
            labelErrorInfo = new Label();
            buttonRegister = new Button();
            buttonBack = new Button();
            panel2 = new Panel();
            panel6 = new Panel();
            labelTeacherReg = new Label();
            labelStudentReg = new Label();
            panel5 = new Panel();
            labelPageInfo = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(104, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(1254, 503);
            panel1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBoxCustomGroup);
            panel4.Controls.Add(labelNameTextBoxNumberBook);
            panel4.Controls.Add(labelNameTextBoxGroup);
            panel4.Controls.Add(textBoxNumberBook);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(textBoxPatronomic);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(textBoxSurname);
            panel4.Controls.Add(textBoxName);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(textBoxRepeatPassword);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBoxPassword);
            panel4.Controls.Add(textBoxLogin);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 56);
            panel4.Name = "panel4";
            panel4.Size = new Size(1254, 389);
            panel4.TabIndex = 2;
            // 
            // comboBoxCustomGroup
            // 
            comboBoxCustomGroup.BackColor = Color.FromArgb(84, 84, 84);
            comboBoxCustomGroup.BorderColor = Color.FromArgb(84, 84, 84);
            comboBoxCustomGroup.BorderSize = 0;
            comboBoxCustomGroup.FlatStyle = FlatStyle.Flat;
            comboBoxCustomGroup.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxCustomGroup.ForeColor = Color.White;
            comboBoxCustomGroup.FormattingEnabled = true;
            comboBoxCustomGroup.IconColor = Color.FromArgb(76, 175, 80);
            comboBoxCustomGroup.ListBackColor = Color.FromArgb(84, 84, 84);
            comboBoxCustomGroup.ListTextColor = Color.White;
            comboBoxCustomGroup.Location = new Point(888, 89);
            comboBoxCustomGroup.MinimumSize = new Size(200, 0);
            comboBoxCustomGroup.Name = "comboBoxCustomGroup";
            comboBoxCustomGroup.Size = new Size(312, 40);
            comboBoxCustomGroup.TabIndex = 16;
            comboBoxCustomGroup.Texts = "";
            comboBoxCustomGroup.OnSelectedIndexChanged += comboBoxCustomGroup_OnSelectedIndexChanged;
            // 
            // labelNameTextBoxNumberBook
            // 
            labelNameTextBoxNumberBook.AutoSize = true;
            labelNameTextBoxNumberBook.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelNameTextBoxNumberBook.ForeColor = Color.White;
            labelNameTextBoxNumberBook.Location = new Point(888, 161);
            labelNameTextBoxNumberBook.Name = "labelNameTextBoxNumberBook";
            labelNameTextBoxNumberBook.Size = new Size(289, 32);
            labelNameTextBoxNumberBook.TabIndex = 15;
            labelNameTextBoxNumberBook.Text = "Номер зачётной книжки";
            // 
            // labelNameTextBoxGroup
            // 
            labelNameTextBoxGroup.AutoSize = true;
            labelNameTextBoxGroup.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelNameTextBoxGroup.ForeColor = Color.White;
            labelNameTextBoxGroup.Location = new Point(888, 54);
            labelNameTextBoxGroup.Name = "labelNameTextBoxGroup";
            labelNameTextBoxGroup.Size = new Size(91, 32);
            labelNameTextBoxGroup.TabIndex = 14;
            labelNameTextBoxGroup.Text = "Группа";
            // 
            // textBoxNumberBook
            // 
            textBoxNumberBook.BackColor = Color.FromArgb(84, 84, 84);
            textBoxNumberBook.BorderStyle = BorderStyle.FixedSingle;
            textBoxNumberBook.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNumberBook.ForeColor = Color.White;
            textBoxNumberBook.Location = new Point(888, 196);
            textBoxNumberBook.Name = "textBoxNumberBook";
            textBoxNumberBook.Size = new Size(312, 39);
            textBoxNumberBook.TabIndex = 13;
            textBoxNumberBook.KeyPress += TextBoxNum_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.White;
            label5.Location = new Point(458, 263);
            label5.Name = "label5";
            label5.Size = new Size(117, 32);
            label5.TabIndex = 11;
            label5.Text = "Отчество";
            // 
            // textBoxPatronomic
            // 
            textBoxPatronomic.BackColor = Color.FromArgb(84, 84, 84);
            textBoxPatronomic.BorderStyle = BorderStyle.FixedSingle;
            textBoxPatronomic.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPatronomic.ForeColor = Color.White;
            textBoxPatronomic.Location = new Point(458, 298);
            textBoxPatronomic.Name = "textBoxPatronomic";
            textBoxPatronomic.Size = new Size(312, 39);
            textBoxPatronomic.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.White;
            label6.Location = new Point(458, 161);
            label6.Name = "label6";
            label6.Size = new Size(113, 32);
            label6.TabIndex = 9;
            label6.Text = "Фамилия";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.White;
            label7.Location = new Point(458, 54);
            label7.Name = "label7";
            label7.Size = new Size(61, 32);
            label7.TabIndex = 8;
            label7.Text = "Имя";
            // 
            // textBoxSurname
            // 
            textBoxSurname.BackColor = Color.FromArgb(84, 84, 84);
            textBoxSurname.BorderStyle = BorderStyle.FixedSingle;
            textBoxSurname.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxSurname.ForeColor = Color.White;
            textBoxSurname.Location = new Point(458, 196);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(312, 39);
            textBoxSurname.TabIndex = 7;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.FromArgb(84, 84, 84);
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxName.ForeColor = Color.White;
            textBoxName.Location = new Point(458, 89);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(312, 39);
            textBoxName.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(33, 263);
            label4.Name = "label4";
            label4.Size = new Size(226, 32);
            label4.TabIndex = 5;
            label4.Text = "Повторите пароль ";
            // 
            // textBoxRepeatPassword
            // 
            textBoxRepeatPassword.BackColor = Color.FromArgb(84, 84, 84);
            textBoxRepeatPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxRepeatPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxRepeatPassword.ForeColor = Color.White;
            textBoxRepeatPassword.Location = new Point(33, 298);
            textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            textBoxRepeatPassword.PasswordChar = '*';
            textBoxRepeatPassword.Size = new Size(312, 39);
            textBoxRepeatPassword.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(33, 161);
            label3.Name = "label3";
            label3.Size = new Size(96, 32);
            label3.TabIndex = 3;
            label3.Text = "Пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(33, 54);
            label2.Name = "label2";
            label2.Size = new Size(81, 32);
            label2.TabIndex = 2;
            label2.Text = "Логин";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(84, 84, 84);
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPassword.ForeColor = Color.White;
            textBoxPassword.Location = new Point(33, 196);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(312, 39);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxLogin
            // 
            textBoxLogin.BackColor = Color.FromArgb(84, 84, 84);
            textBoxLogin.BorderStyle = BorderStyle.FixedSingle;
            textBoxLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxLogin.ForeColor = Color.White;
            textBoxLogin.Location = new Point(33, 89);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(312, 39);
            textBoxLogin.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(labelErrorInfo);
            panel3.Controls.Add(buttonRegister);
            panel3.Controls.Add(buttonBack);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 445);
            panel3.Name = "panel3";
            panel3.Size = new Size(1254, 58);
            panel3.TabIndex = 1;
            // 
            // labelErrorInfo
            // 
            labelErrorInfo.AutoSize = true;
            labelErrorInfo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelErrorInfo.ForeColor = Color.FromArgb(255, 128, 128);
            labelErrorInfo.Location = new Point(30, 6);
            labelErrorInfo.Name = "labelErrorInfo";
            labelErrorInfo.Size = new Size(0, 30);
            labelErrorInfo.TabIndex = 16;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.FromArgb(53, 128, 56);
            buttonRegister.Cursor = Cursors.Hand;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.Location = new Point(997, 0);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(227, 43);
            buttonRegister.TabIndex = 2;
            buttonRegister.Text = "Зарегестрироваться";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.FromArgb(84, 84, 84);
            buttonBack.Cursor = Cursors.Hand;
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonBack.ForeColor = Color.White;
            buttonBack.Location = new Point(792, 0);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(178, 43);
            buttonBack.TabIndex = 1;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += buttonBack_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(labelPageInfo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1254, 56);
            panel2.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(84, 84, 84);
            panel6.Controls.Add(labelTeacherReg);
            panel6.Controls.Add(labelStudentReg);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(946, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(308, 56);
            panel6.TabIndex = 5;
            // 
            // labelTeacherReg
            // 
            labelTeacherReg.AutoSize = true;
            labelTeacherReg.Cursor = Cursors.Hand;
            labelTeacherReg.Font = new Font("Segoe UI", 15F, FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTeacherReg.ForeColor = Color.White;
            labelTeacherReg.Location = new Point(134, 13);
            labelTeacherReg.Name = "labelTeacherReg";
            labelTeacherReg.Size = new Size(153, 28);
            labelTeacherReg.TabIndex = 1;
            labelTeacherReg.Text = "Преподаватель";
            labelTeacherReg.Click += labelTeacherReg_Click;
            // 
            // labelStudentReg
            // 
            labelStudentReg.AutoSize = true;
            labelStudentReg.Cursor = Cursors.Hand;
            labelStudentReg.Font = new Font("Segoe UI", 15F, FontStyle.Underline, GraphicsUnit.Point, 204);
            labelStudentReg.ForeColor = Color.FromArgb(76, 175, 80);
            labelStudentReg.Location = new Point(33, 13);
            labelStudentReg.Name = "labelStudentReg";
            labelStudentReg.Size = new Size(83, 28);
            labelStudentReg.TabIndex = 0;
            labelStudentReg.Text = "Студент";
            labelStudentReg.Click += labelStudentReg_Click;
            // 
            // panel5
            // 
            panel5.Location = new Point(30, 56);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 109);
            panel5.TabIndex = 4;
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPageInfo.ForeColor = Color.White;
            labelPageInfo.Location = new Point(526, 13);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(184, 40);
            labelPageInfo.TabIndex = 0;
            labelPageInfo.Text = "Регистрация";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(1469, 590);
            Controls.Add(panel1);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrationForm";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Label label3;
        private Label label2;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Panel panel3;
        private Button buttonRegister;
        private Button buttonBack;
        private Panel panel2;
        private Label labelPageInfo;
        private Label label4;
        private TextBox textBoxRepeatPassword;
        private Panel panel5;
        private Label labelNameTextBoxNumberBook;
        private Label labelNameTextBoxGroup;
        private TextBox textBoxNumberBook;
        private Label label5;
        private TextBox textBoxPatronomic;
        private Label label6;
        private Label label7;
        private TextBox textBoxSurname;
        private TextBox textBoxName;
        private Label labelErrorInfo;
        private Panel panel6;
        private Label labelStudentReg;
        private Label labelTeacherReg;
        private ComboBoxCustom comboBoxCustomGroup;
    }
}