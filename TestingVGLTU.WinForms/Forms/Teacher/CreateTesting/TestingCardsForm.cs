using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Data;
using TestingVGLTU.WinForms.Forms.Shared;
using TestingVGLTU.WinForms.Forms.Shared.Cards;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting
{
    public partial class TestingCardsForm : Form
    {
        public TestingCardsForm()
        {
            InitializeComponent();

        }

        public async Task LoadData()
        {
            var mainForm = (MainForm)ParentForm!;
            using DataContext context = new DataContext();

            var testings = await context.Testings.Include(t => t.Teacher).Include(t => t.TypeTesting).Where(t => t.TeacherId == mainForm.User.Id).ToArrayAsync();

            var cards = GetTestingCards(testings);

            flowLayoutPanelCards.Controls.AddRange(cards.ToArray());
        }

        private void buttonAddTesting_Click(object sender, EventArgs e)
        {
            var mainForm = (MainForm)ParentForm!;
            mainForm.OpenChildForm(new CreateTestingForm());
        }

        private async void TestingCardsForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private List<RedactTestingCard> GetTestingCards(Testing[] testings)
        {
            var cards = new List<RedactTestingCard>();
            foreach (var testing in testings)
            {
                var card = new RedactTestingCard();

                card.AttemptsLeft = $"{testing.Attempts}";
                card.Location = new Point(432, 20);
                card.Margin = new Padding(10, 20, 10, 3);
                card.MaximumSize = new Size(392, 238);
                card.MinimumSize = new Size(392, 238);
                card.Tag = $"{testing.Id}";
                card.Size = new Size(392, 238);
                card.TabIndex = 2;
                card.TeacherName = $"{testing.Teacher.Surname} {testing.Teacher.Name[0]}. {testing.Teacher.Patronymic[0]}.";
                card.TestingName = $"{testing.Name}";
                card.TimeRemaining = $"{testing.Time.Minute + testing.Time.Hour * 60}";
                card.TypeTesting = $"{testing.TypeTesting.Name}";
                card.GoOverClicked += Card_GoOverClicked;
                card.DeleteClicked += Card_DeleteClicked;

                cards.Add(card);
            }

            return cards;
        }

        private async void Card_DeleteClicked(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите удалить?",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return;

            var card = (RedactTestingCard)sender!;

            var dataContext = new DataContext();

            var testingId = int.Parse(card.Tag!.ToString()!);
            var testing = await dataContext.Testings.FirstOrDefaultAsync(t => t.Id == testingId);
            dataContext.Testings.Remove(testing!);
            
            await dataContext.SaveChangesAsync();
            card.Visible = false;
        }

        private void Card_GoOverClicked(object? sender, EventArgs e)
        {
            var card = (RedactTestingCard) sender!;
            var mainForm = (MainForm)ParentForm!;
            mainForm.OpenChildForm(new EditTestingAndPublicationForm(int.Parse(card.Tag!.ToString()!)));
        }
    }
}
