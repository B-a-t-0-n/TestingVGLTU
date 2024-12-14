using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.WinForms.Forms.Shared
{
    public partial class MainForm : Form
    {
        public User User { get; set; }

        public MainForm(User user)
        {
            InitializeComponent();

            User = user;

            if(User is Teacher)
            {
                buttonActiveStudent.Visible = false;
                buttonHome.Visible = false;
                buttonMail.Visible = false;
            }
            if (User is Student)
            {
                buttonActiveTeacher.Visible = false;
                buttonCreateTesting.Visible = false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
