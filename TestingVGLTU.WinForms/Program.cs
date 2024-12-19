using TestingVGLTU.WinForms.Forms.AuthorizationAndRegistration;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion;

namespace TestingVGLTU.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SignInForm());
        }
    }
}