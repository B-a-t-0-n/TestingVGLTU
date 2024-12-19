using System.Reflection;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting;

namespace TestingVGLTU.WinForms.Forms.Shared
{
    public partial class MainForm : Form
    {
        private Form _activeForm = new Form();

        public User User { get; set; }

        public MainForm(User user)
        {
            InitializeComponent();

            User = user;

            if (User is Models.Entity.Teacher)
            {
                buttonActiveStudent.Visible = false;
                buttonHome.Visible = false;
                buttonMail.Visible = false;
 
                OpenChildForm(new TestingCardsForm());
            }
            if (User is Models.Entity.Student)
            {
                buttonActiveTeacher.Visible = false;
                buttonCreateTesting.Visible = false;
            }

            buttonBack.Visible = false;

            labelFullNameUser.Text = $"{User.Surname} {User.Name[0]}. {User.Patronymic[0]}.";
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

        }

        private void buttonMail_Click(object sender, EventArgs e)
        {

        }

        private void buttonActiveStudent_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateTesting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TestingCardsForm());
        }

        private void buttonActiveTeacher_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        public void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(childForm);
            panelCenter.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        
    }
}
