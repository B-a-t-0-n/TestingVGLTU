using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting
{
    public partial class TestingCardsForm : Form
    {
        public TestingCardsForm()
        {
            InitializeComponent();
        }

        private void testingCard1_DeleteClicked(object sender, EventArgs e)
        {
            MessageBox.Show("кнопка удалить");
        }

        private void testingCard1_GoOverClicked(object sender, EventArgs e)
        {
            MessageBox.Show("кнопка перейти");
        }


    }
}
