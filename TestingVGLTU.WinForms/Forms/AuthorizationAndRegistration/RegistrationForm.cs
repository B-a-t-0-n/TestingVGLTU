using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Data;
using TestingVGLTU.WinForms.Providers;

namespace TestingVGLTU.WinForms.Forms.AuthorizationAndRegistration
{
    public partial class RegistrationForm : Form
    {
        private PasswordHasher _passwordHasher;
        private bool _isRegStudent = true;

        private bool IsRegStudent
        {
            get
            {
                return _isRegStudent;
            }
            set
            {
                if (value)
                {
                    labelTeacherReg.ForeColor = Color.White;
                    labelStudentReg.ForeColor = Color.FromArgb(76, 175, 80);

                    comboBoxCustomGroup.Visible = true;
                    textBoxNumberBook.Visible = true;
                    labelNameTextBoxGroup.Visible = true;
                    labelNameTextBoxNumberBook.Visible = true;
                }
                else
                {
                    labelStudentReg.ForeColor = Color.White;
                    labelTeacherReg.ForeColor = Color.FromArgb(76, 175, 80);

                    comboBoxCustomGroup.Visible = false;
                    textBoxNumberBook.Visible = false;
                    labelNameTextBoxGroup.Visible = false;
                    labelNameTextBoxNumberBook.Visible = false;

                }

                _isRegStudent = value;
            }
        }

        public RegistrationForm()
        {
            InitializeComponent();

            _passwordHasher = new PasswordHasher();

            LoadData();
        }

        private async void LoadData()
        {
            using DataContext dataContext = new DataContext();

            var groups = await dataContext.Groups.ToArrayAsync();

            comboBoxCustomGroup.Items.AddRange(groups);
            comboBoxCustomGroup.SelectedIndex = 0;

            comboBoxCustomGroup.Visible = false;
            comboBoxCustomGroup.Visible = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != textBoxRepeatPassword.Text)
            {
                labelErrorInfo.Text = "пароли должны совпадать";
                return;
            }

            await Register(
                textBoxName.Text,
                textBoxSurname.Text,
                textBoxPatronomic.Text,
                textBoxLogin.Text,
                textBoxPassword.Text,
                textBoxNumberBook.Text,
                comboBoxCustomGroup.Texts
                );

            Close();
        }

        public async Task Register(string name, string surname, string patronymic, string login, string password, string numberRecordBook, string groupName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                labelErrorInfo.Text = "поле имя не должно быть пустым";
                return;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                labelErrorInfo.Text = "поле фамилия не должно быть пустым";
                return;
            }

            if (string.IsNullOrWhiteSpace(patronymic))
            {
                labelErrorInfo.Text = "поле отчество не должно быть пустым";
                return;
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                labelErrorInfo.Text = "поле логин не должно быть пустым";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                labelErrorInfo.Text = "поле пароль не должно быть пустым";
                return;
            }

            using var dataContext = new DataContext();

            var user = await dataContext.Users.FirstOrDefaultAsync(s => s.Login == login);

            if (user != null)
            {
                labelErrorInfo.Text = "данный логин уже используется";
                return;
            }

            var heshedPassword = _passwordHasher.Generate(password);

            if (IsRegStudent)
            {
                var group = await dataContext.Groups.FirstOrDefaultAsync(s => s.Name == groupName);

                if (group == null)
                {
                    labelErrorInfo.Text = "группа не найдена";
                    return;
                }

                if (string.IsNullOrWhiteSpace(groupName))
                {
                    labelErrorInfo.Text = "поле группа не должно быть пустым";
                    return;
                }

                if (string.IsNullOrWhiteSpace(numberRecordBook))
                {
                    labelErrorInfo.Text = "поле номер зачётной книжки не должно быть пустым";
                    return;
                }

                var student = new Student()
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Login = login,
                    Password = heshedPassword,
                    NumberRecordBook = int.Parse(numberRecordBook),
                    GroupId = group!.Id
                };

                await dataContext.AddAsync(student);
            }
            else
            {
                var teacher = new Models.Entity.Teacher()
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Login = login,
                    Password = heshedPassword
                };

                await dataContext.AddAsync(teacher);
            }

            await dataContext.SaveChangesAsync();
        }

        private void labelStudentReg_Click(object sender, EventArgs e)
        {
            IsRegStudent = true;
        }

        private void labelTeacherReg_Click(object sender, EventArgs e)
        {
            IsRegStudent = false;
        }

        private void TextBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBoxCustomGroup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCustomGroup.Visible = false;
            comboBoxCustomGroup.Visible = true;
        }
    }
}
