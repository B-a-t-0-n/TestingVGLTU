namespace TestingVGLTU.WinForms.Forms.AuthorizationAndRegistration
{
    partial class SignInForm
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
            labelErrorInfo = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            panel3 = new Panel();
            buttonRegestration = new Button();
            buttonSignIn = new Button();
            panel2 = new Panel();
            labelPageInfo = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(138, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(497, 396);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(labelErrorInfo);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBoxPassword);
            panel4.Controls.Add(textBoxLogin);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 56);
            panel4.Name = "panel4";
            panel4.Size = new Size(497, 282);
            panel4.TabIndex = 2;
            // 
            // labelErrorInfo
            // 
            labelErrorInfo.AutoSize = true;
            labelErrorInfo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelErrorInfo.ForeColor = Color.FromArgb(255, 128, 128);
            labelErrorInfo.Location = new Point(30, 232);
            labelErrorInfo.Name = "labelErrorInfo";
            labelErrorInfo.Size = new Size(0, 30);
            labelErrorInfo.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(30, 142);
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
            label2.Location = new Point(30, 35);
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
            textBoxPassword.Location = new Point(30, 177);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(434, 39);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxLogin
            // 
            textBoxLogin.BackColor = Color.FromArgb(84, 84, 84);
            textBoxLogin.BorderStyle = BorderStyle.FixedSingle;
            textBoxLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxLogin.ForeColor = Color.White;
            textBoxLogin.Location = new Point(30, 70);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(434, 39);
            textBoxLogin.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonRegestration);
            panel3.Controls.Add(buttonSignIn);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 338);
            panel3.Name = "panel3";
            panel3.Size = new Size(497, 58);
            panel3.TabIndex = 1;
            // 
            // buttonRegestration
            // 
            buttonRegestration.BackColor = Color.FromArgb(84, 84, 84);
            buttonRegestration.Cursor = Cursors.Hand;
            buttonRegestration.FlatAppearance.BorderSize = 0;
            buttonRegestration.FlatStyle = FlatStyle.Flat;
            buttonRegestration.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRegestration.ForeColor = Color.White;
            buttonRegestration.Location = new Point(30, 0);
            buttonRegestration.Name = "buttonRegestration";
            buttonRegestration.Size = new Size(227, 43);
            buttonRegestration.TabIndex = 2;
            buttonRegestration.Text = "Зарегестрироваться";
            buttonRegestration.UseVisualStyleBackColor = false;
            buttonRegestration.Click += buttonRegestration_Click;
            // 
            // buttonSignIn
            // 
            buttonSignIn.BackColor = Color.FromArgb(53, 128, 56);
            buttonSignIn.Cursor = Cursors.Hand;
            buttonSignIn.FlatAppearance.BorderSize = 0;
            buttonSignIn.FlatStyle = FlatStyle.Flat;
            buttonSignIn.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSignIn.ForeColor = Color.White;
            buttonSignIn.Location = new Point(286, 0);
            buttonSignIn.Name = "buttonSignIn";
            buttonSignIn.Size = new Size(178, 43);
            buttonSignIn.TabIndex = 1;
            buttonSignIn.Text = "Войти";
            buttonSignIn.UseVisualStyleBackColor = false;
            buttonSignIn.Click += buttonSignIn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelPageInfo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(497, 56);
            panel2.TabIndex = 0;
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPageInfo.ForeColor = Color.White;
            labelPageInfo.Location = new Point(204, 13);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(84, 40);
            labelPageInfo.TabIndex = 0;
            labelPageInfo.Text = "Вход";
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 41, 41);
            ClientSize = new Size(800, 590);
            Controls.Add(panel1);
            Name = "SignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignInForm";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private Label labelPageInfo;
        private Button buttonRegestration;
        private Button buttonSignIn;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label label2;
        private Label label3;
        private Label labelErrorInfo;
    }
}