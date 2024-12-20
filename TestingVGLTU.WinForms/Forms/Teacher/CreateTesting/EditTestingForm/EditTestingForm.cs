using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Data;
using TestingVGLTU.WinForms.Forms.Shared;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditTestingForm.CustomElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting
{
    public partial class EditTestingAndPublicationForm : Form
    {
        private Testing _testing;

        public EditTestingAndPublicationForm(int testingId)
        {
            InitializeComponent();

            using var dataContext = new DataContext();
            _testing = dataContext.Testings.Include(t => t.Questions).FirstOrDefault(t => t.Id == testingId) ?? new Testing();
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
            var groups = dataContext.Groups.ToArray();

            comboBoxCustomGroupType.Items.Clear();
            comboBoxCustomTypeOutputOfResult.Items.Clear();
            comboBoxCustomGroup.Items.Clear();

            comboBoxCustomGroupType.Items.AddRange(typeTesting);
            comboBoxCustomTypeOutputOfResult.Items.AddRange(typeOutputOfResult);
            comboBoxCustomGroup.Items.AddRange(groups);

            foreach (var item in comboBoxCustomGroupType.Items)
            {
                var type = item as TypeTesting;
                if (type!.Id == _testing.TypeTestingId)
                {
                    comboBoxCustomGroupType.SelectedItem = item;
                }
            }

            foreach (var item in comboBoxCustomTypeOutputOfResult.Items)
            {
                var type = item as TypeOutputOfResult;
                if (type!.Id == _testing.TypeOutputOfResultId)
                {
                    comboBoxCustomTypeOutputOfResult.SelectedItem = item;
                }
            }

            comboBoxCustomGroupType.Visible = false;
            comboBoxCustomGroupType.Visible = true;

            comboBoxCustomTypeOutputOfResult.Visible = false;
            comboBoxCustomTypeOutputOfResult.Visible = true;

            comboBoxCustomGroup.Visible = false;
            comboBoxCustomGroup.Visible = true;

            textBoxName.Text = _testing.Name;
            textBoxAttemps.Text = _testing.Attempts.ToString();
            textBoxTime.Text = (_testing.Time.Minute + _testing.Time.Hour * 60).ToString();

            textBoxScore5.Text = _testing.ScoresFor5.ToString();
            textBoxScore4.Text = _testing.ScoresFor4.ToString();
            textBoxScore3.Text = _testing.ScoresFor3.ToString();
            

            labelScore5.Text = $"до {_testing.Questions.Sum(q => q.Scores)}";
            labelScore4.Text = $"до {textBoxScore5.Text}";
            labelScore3.Text = $"до {textBoxScore4.Text}";
            labelScore3.Text = $"до {textBoxScore3.Text}";

            textBoxScore2.Text = "0";

            labelQuestionNumber.Text = $"Всего вопросов: {_testing.Questions.Count()}";
            labelMaxScore.Text = $"Всего баллов: {_testing.Questions.Sum(q => q.Scores)}";

            flowLayoutPanelQuestionRows.Controls.Clear();

            flowLayoutPanelQuestionRows.Controls.AddRange(GetQuestionRows(_testing.Questions.OrderBy(q => int.Parse(q.Number))).ToArray());
            flowLayoutPanelQuestionRows.Controls.Add(GetQuestionAdd());
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
                    typeOutPut!.Id,
                    type!.Id
                    );
                if (testing == null)
                    return;

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

            await dataContext.Testings.AddAsync(testing);
            await dataContext.SaveChangesAsync();

            return testing;
        }

        private IEnumerable<QuestionRow> GetQuestionRows(IEnumerable<Question> questions)
        {
            foreach (Question question in questions)
            {
                var questionRow = new QuestionRow();
                questionRow.Margin = new Padding(0, 10, 0, 0);
                questionRow.Tag = question.Id;
                questionRow.Number = question.Number;
                questionRow.Question = question.Text;
                questionRow.Size = new Size(929, 50);
                questionRow.TabIndex = 5;
                questionRow.CreateClicked += questionRow_CreateClicked!;
                questionRow.DeleteClicked += questionRow_DeleteClicked!;
                if (question is QuestionInputNumber)
                {
                    questionRow.TypeQuestion = "ввод числа";
                }
                else if (question is QuestionInputText)
                {
                    questionRow.TypeQuestion = "ввод текста";
                }
                else if (question is QuestionSingleSelection)
                {
                    questionRow.TypeQuestion = "одиночный выбор";
                }
                else if (question is QuestionMultipleChoice)
                {
                    questionRow.TypeQuestion = "множественный выбор";
                }

                yield return questionRow;
            }
        }

        private QuestionAdd GetQuestionAdd()
        {
            var questionAdd = new QuestionAdd();
            questionAdd.Margin = new Padding(0, 10, 0, 0);
            questionAdd.Size = new Size(929, 50);
            questionAdd.TabIndex = 6;
            questionAdd.GoAddClicked += questionAdd_GoAddClicked!;

            return questionAdd;
        }

        private void questionAdd_GoAddClicked(object sender, EventArgs e)
        {
            var mainForm = ParentForm as MainForm;
            mainForm!.OpenChildForm(new EditQuestionForm(_testing.Id));
        }


        private void questionRow_CreateClicked(object sender, EventArgs e)
        {
            var row = sender as QuestionRow;
            var mainForm = ParentForm as MainForm;
            mainForm!.OpenChildForm(new EditQuestionForm(_testing.Id, int.Parse(row!.Tag!.ToString()!)));
        }

        private void questionRow_DeleteClicked(object sender, EventArgs e)
        {
            var row = sender as QuestionRow;

            using var dataContext = new DataContext();

            var question = dataContext.Questions.FirstOrDefault(q => q.Id == int.Parse(row!.Tag!.ToString()!));

            dataContext.Questions.Remove(question!);
            dataContext.SaveChanges();
            flowLayoutPanelQuestionRows.Controls.Remove(row);
        }

        private void groupRow_GoDeleteClicked(object sender, EventArgs e)
        {
            flowLayoutPanelGroups.Controls.Remove(sender as GroupRow);
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            var group = comboBoxCustomGroup.SelectedItem as Group;
            if (group == null)
                return;

            foreach (var row in flowLayoutPanelGroups.Controls)
            {
                var tempGroupRow = row as GroupRow;
                if (tempGroupRow!.Number == group.Name)
                    return;
            }

            var groupRow = GetGroupRow(group);

            flowLayoutPanelGroups.Controls.Add(groupRow);
        }

        private GroupRow GetGroupRow(Group group)
        {
            var groupRow = new GroupRow();
            groupRow.Margin = new Padding(0, 10, 0, 0);
            groupRow.Tag = group.Id;
            groupRow.Number = group.Name;
            groupRow.Size = new Size(270, 30);
            groupRow.TabIndex = 0;
            groupRow.GoDeleteClicked += groupRow_GoDeleteClicked!;

            return groupRow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var dataContext = new DataContext();

            var testing = dataContext.Testings.FirstOrDefault(t => t.Id == _testing.Id);

            testing!.ScoresFor5 = int.Parse(textBoxScore5.Text);
            testing!.ScoresFor4 = int.Parse(textBoxScore4.Text);
            testing!.ScoresFor3 = int.Parse(textBoxScore3.Text);

            dataContext.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanelGroups.Controls)
            {

            }
        }
    }
}
