using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Data;
using TestingVGLTU.WinForms.Forms.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting
{
    public partial class CreateTestingForm : Form
    {
        public CreateTestingForm()
        {
            InitializeComponent();
        }

        private void CreateTestingForm_Load(object sender, EventArgs e)
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

        private void comboBoxCustomGroup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCustomGroupType.Visible = false;
            comboBoxCustomGroupType.Visible = true;

            comboBoxCustomTypeOutputOfResult.Visible = false;
            comboBoxCustomTypeOutputOfResult.Visible = true;
        }

        private async void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxAttemps.Text))
                {
                    labelAttemps.ForeColor = Color.FromArgb(255, 128, 128);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    labelName.ForeColor = Color.FromArgb(255, 128, 128);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxTime.Text))
                {
                    labelTime.ForeColor = Color.FromArgb(255, 128, 128);
                    return;
                }

                var type = comboBoxCustomGroupType.SelectedItem as TypeTesting;
                var typeOutPut = comboBoxCustomTypeOutputOfResult.SelectedItem as TypeOutputOfResult;

                var testing = await CreateTesting(textBoxName.Text,
                    uint.Parse(textBoxAttemps.Text),
                    int.Parse(textBoxTime.Text),
                    type!.Id,
                    typeOutPut!.Id
                    );
                if (testing == null)
                    return;

                using DataContext dataContext = new DataContext();

                dataContext.Testings.Add(testing);
                dataContext.SaveChanges();

                var mainForm = (MainForm)ParentForm!;
                mainForm.OpenChildForm(new EditTestingAndPublicationForm(testing.Id));

            }
            catch (Exception ex)
            {

            }

        }

        private async Task<Testing?> CreateTesting(string name, uint attemps, int time, int typeOutputOfResultId, int typeTestingId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                labelName.ForeColor = Color.FromArgb(255, 128, 128);
                return null;
            }

            if (attemps < 0)
            {
                labelAttemps.ForeColor = Color.FromArgb(255, 128, 128);
                return null;
            }

            if (time < 0)
            {
                labelTime.ForeColor = Color.FromArgb(255, 128, 128);
                return null;
            }

            var mainForm = ParentForm as MainForm;

            var hours = time / 60;
            var minutes = time % 60;

            var timeOnly = new TimeOnly(hours, minutes);

            var testing = new Testing()
            {
                Name = name,
                TeacherId = mainForm!.User.Id,
                Attempts = attemps,
                Time = timeOnly,
                TimeCreate = DateTime.Now,
                TypeOutputOfResultId = typeOutputOfResultId,
                TypeTestingId = typeTestingId,
            };

            var dataContext = new DataContext();

            if (!dataContext.TypeTestings.Any(i => i.Id == typeTestingId))
            {
                labelType.ForeColor = Color.FromArgb(255, 128, 128);
                return null;
            }

            if (!dataContext.TypeOutputOfResults.Any(i => i.Id == typeOutputOfResultId))
            {
                labelTypeOutputOfResult.ForeColor = Color.FromArgb(255, 128, 128);
                return null;
            }

            await dataContext.AddAsync(testing);
            await dataContext.SaveChangesAsync();

            return testing;
        }

        private void TextBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


    }
}
