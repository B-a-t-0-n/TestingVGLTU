using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Data;
using TestingVGLTU.WinForms.Forms.Shared;
using TestingVGLTU.WinForms.Providers;

namespace TestingVGLTU.WinForms.Forms.AuthorizationAndRegistration
{
    public partial class SignInForm : Form
    {
        private PasswordHasher _passwordHasher;

        public SignInForm()
        {
            InitializeComponent();

            _passwordHasher = new PasswordHasher();
        }

        private void buttonRegestration_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            Hide();
            regForm.ShowDialog();
            Show();
        }

        private async void buttonSignIn_Click(object sender, EventArgs e)
        {
            var user = await GetUser(textBoxLogin.Text, textBoxPassword.Text);
            if (user == null)
                return;

            var mainForm = new MainForm(user);
            Hide();
            mainForm.ShowDialog();
            Show();
        }

        private async Task<User?> GetUser(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                labelErrorInfo.Text = "введите логин";
                return null;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                labelErrorInfo.Text = "введите пароль";
                return null;
            }

            using var dataContext = new DataContext();

            var user = await dataContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            if (user == null)
            {
                labelErrorInfo.Text = "данный логин не зарегестрирован";
                return null;
            }

            if(_passwordHasher.Verefy(password, user.Password))
            {
                labelErrorInfo.Text = "неверный пароль";
                return null;
            }

            return user;
        }
    }
}
