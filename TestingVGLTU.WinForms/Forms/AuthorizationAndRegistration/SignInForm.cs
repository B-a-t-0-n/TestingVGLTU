namespace TestingVGLTU.WinForms.Forms.AuthorizationAndRegistration
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void buttonRegestration_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            Hide();
            regForm.ShowDialog();
            Show();
        }
    }
}
