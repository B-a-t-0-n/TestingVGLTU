using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingVGLTU.WinForms.Data;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting
{
    public partial class EditTestingAndPublicationForm : Form
    {
        public EditTestingAndPublicationForm()
        {
            InitializeComponent();
        }


        private void TextBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void EditTestingForm_Load(object sender, EventArgs e)
        {
            using var dataContext = new DataContext();

            var typeTesting = dataContext.TypeTestings.ToArray();
            var typeOutputOfResult = dataContext.TypeOutputOfResults.ToArray();

            comboBoxCustomGroupType.Items.AddRange(typeTesting);
            comboBoxCustomTypeOutputOfResult.Items.AddRange(typeOutputOfResult);

            comboBoxCustomGroupType.SelectedIndex = 0;
            comboBoxCustomTypeOutputOfResult.SelectedIndex = 0;

            comboBoxCustomGroupType.Visible = false;
            comboBoxCustomGroupType.Visible = true;

            comboBoxCustomTypeOutputOfResult.Visible = false;
            comboBoxCustomTypeOutputOfResult.Visible = true;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
