using Microsoft.EntityFrameworkCore;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.WinForms.Data;
using TestingVGLTU.WinForms.Forms.Shared;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion.TableElement;
using TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditTestingForm.CustomElement;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion
{
    public partial class EditQuestionForm : Form
    {
        public const string SEPARATOR = "~&&`~";

        private Testing _testing;
        private Question _question;

        public EditQuestionForm(int testingId)
        {
            InitializeComponent();

            using DataContext dataContext = new DataContext();

            _testing = dataContext.Testings.FirstOrDefault(t => t.Id == testingId)!;
            _question = new QuestionInputNumber();
        }

        public EditQuestionForm(int testingId, int questionId)
        {
            InitializeComponent();

            using DataContext dataContext = new DataContext();

            _testing = dataContext.Testings.FirstOrDefault(t => t.Id == testingId)!;
            _question = dataContext.Questions.FirstOrDefault(q => q.Id == questionId)!;
        }

        private void TextBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonCraeate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                labelName.ForeColor = Color.FromArgb(255, 128, 128);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxScore.Text) || int.Parse(textBoxScore.Text) <= 0)
            {
                labelScore.ForeColor = Color.FromArgb(255, 128, 128);
                return;
            }

            var question = QuestionCreate();
            if (question == null) 
                return;

            var mainForm = ParentForm as MainForm;
            mainForm!.OpenChildForm(new EditTestingAndPublicationForm(_testing.Id));
        }

        private async Task<Question?> QuestionCreate() 
        {
            var question = new Question();
            
            switch (comboBoxCustomType.SelectedItem)
            {
                case "ввод числа":
                    question = new QuestionInputNumber();
                    var questionInpNum = question as QuestionInputNumber;
                    questionInpNum!.CorrectAnswers = "";

                    foreach(var row in flowLayoutPanelAnswers.Controls)
                    {
                        if (row is AnswerInputRow)
                        {
                            var answer = (AnswerInputRow)row;

                            if (string.IsNullOrWhiteSpace(answer.Answer))
                            {
                                labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                                return null;
                            }

                            questionInpNum.CorrectAnswers += $"{answer.Answer}{SEPARATOR}";
                        }
                    }

                    if (string.IsNullOrWhiteSpace(questionInpNum!.CorrectAnswers))
                    {
                        labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                        return null;
                    }

                    question = questionInpNum;
                    break;
                case "ввод текста":
                    question = new QuestionInputText();

                    var questionInpText = question as QuestionInputText;
                    questionInpText!.CorrectAnswers = "";

                    foreach (var row in flowLayoutPanelAnswers.Controls)
                    {
                        if (row is AnswerInputRow)
                        {
                            var answer = (AnswerInputRow)row;

                            if (string.IsNullOrWhiteSpace(answer.Answer))
                            {
                                labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                                return null;
                            }

                            questionInpText.CorrectAnswers += $"{answer.Answer}{SEPARATOR}";
                        }
                    }

                    if (string.IsNullOrWhiteSpace(questionInpText!.CorrectAnswers))
                    {
                        labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                        return null;
                    }

                    question = questionInpText;
                    break;
                case "одиночный выбор":
                    question = new QuestionSingleSelection();

                    var questionTest = question as QuestionSingleSelection;
                    questionTest!.AnswerOptions = "";

                    foreach (var row in flowLayoutPanelAnswers.Controls)
                    {
                        if (row is AnswerTestRow)
                        {
                            var answer = (AnswerTestRow)row;

                            if (string.IsNullOrWhiteSpace(answer.Answer))
                            {
                                labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                                return null;
                            }

                            questionTest.AnswerOptions += $"{answer.Answer}{SEPARATOR}";

                            if (answer.IsRightAnswer)
                            {
                                questionTest.RightAnswer = answer.Answer;
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(questionTest!.AnswerOptions))
                    {
                        labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                        return null;
                    }

                    question = questionTest;
                    break;
                case "множественный выбор":
                    question = new QuestionMultipleChoice();

                    var questionTestMult = question as QuestionMultipleChoice;
                    questionTestMult!.AnswerOptions = "";
                    questionTestMult!.CorrectAnswers = "";

                    foreach (var row in flowLayoutPanelAnswers.Controls)
                    {
                        if (row is AnswerTestRow)
                        {
                            var answer = (AnswerTestRow)row;

                            if (string.IsNullOrWhiteSpace(answer.Answer))
                            {
                                labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                                return null;
                            }

                            questionTestMult.AnswerOptions += $"{answer.Answer}{SEPARATOR}";

                            if (answer.IsRightAnswer)
                            {
                                questionTestMult.CorrectAnswers += $"{answer.Answer}{SEPARATOR}";
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(questionTestMult!.AnswerOptions))
                    {
                        labelTableColumAnswer.ForeColor = Color.FromArgb(255, 128, 128);
                        return null;
                    }

                    question = questionTestMult;
                    break;
                default:
                    return null;
            }

            question.Text = textBoxName.Text;
            question.Scores = int.Parse(textBoxScore.Text);

            using DataContext dataContext = new DataContext();

            question.TestingId = _testing.Id;

            if (string.IsNullOrEmpty(_question.Number))
            {
                question.Number = (dataContext.Questions.Where(q => q.TestingId == _testing.Id).ToList().Count() + 1).ToString();
            }
            else
            {
                question.Number = _question.Number;
            }
            var oldQuestion = await dataContext.Questions.FirstOrDefaultAsync(q => q.Id == _question.Id);
            if (oldQuestion != null) 
            {
                dataContext.Remove(oldQuestion!);
            }
            await dataContext.Questions.AddAsync(question);
            await dataContext.SaveChangesAsync();
            return question;
        }

        private void EditQuestionForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = _question.Text;
            textBoxScore.Text = _question.Scores.ToString();

            comboBoxCustomType.Items.Clear();
            comboBoxCustomType.Items.AddRange(["ввод числа", "ввод текста", "одиночный выбор", "множественный выбор"]);

            if (_question is QuestionInputNumber)
            {
                comboBoxCustomType.SelectedItem = "ввод числа";
            }
            else if (_question is QuestionInputText)
            {
                comboBoxCustomType.SelectedItem = "ввод текста";
            }
            else if (_question is QuestionSingleSelection)
            {
                comboBoxCustomType.SelectedItem = "одиночный выбор";
            }
            else if (_question is QuestionMultipleChoice)
            {
                comboBoxCustomType.SelectedItem = "множественный выбор";
            }
        }

        private void answerRow_GoDeleteClicked(object sender, EventArgs e)
        {
            var row = sender as UserControl;
            flowLayoutPanelAnswers.Controls.Remove(row);
        }

        private void addAnswerRow_GoAddClicked(object sender, EventArgs e)
        {
            var userControl = new UserControl();

            switch (comboBoxCustomType.SelectedItem)
            {
                case "ввод числа":
                    userControl = GetAnswerInputRow();
                    break;
                case "ввод текста":
                    userControl = GetAnswerInputRow();
                    break;
                case "одиночный выбор":
                    userControl = GetAnswerTestRow();
                    break;
                case "множественный выбор":
                    userControl = GetAnswerTestRow();
                    break;
                default:
                    return;
            }

            flowLayoutPanelAnswers.Controls.Add(userControl);
            flowLayoutPanelAnswers.Controls.Remove(sender as UserControl);
            flowLayoutPanelAnswers.Controls.Add(GetAddAnswerRow());
        }

        private void comboBoxCustomType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelAnswers.Controls.Clear();
            flowLayoutPanelAnswers.Controls.Add(GetAddAnswerRow());
        }

        private AddAnswerRow GetAddAnswerRow()
        {
            var addAnswerRow = new AddAnswerRow();

            addAnswerRow.Margin = new Padding(0, 10, 0, 0);
            addAnswerRow.Size = new Size(736, 44);
            addAnswerRow.TabIndex = 2;
            addAnswerRow.GoAddClicked += addAnswerRow_GoAddClicked!;

            return addAnswerRow;
        }

        private AnswerTestRow GetAnswerTestRow() 
        {
            var answerTestRow = new AnswerTestRow();

            answerTestRow.Answer = "";
            answerTestRow.Margin = new Padding(0, 10, 0, 0);
            answerTestRow.IsRightAnswer = false;
            answerTestRow.Size = new Size(736, 44);
            answerTestRow.TabIndex = 1;
            answerTestRow.GoDeleteClicked += answerRow_GoDeleteClicked!;

            return answerTestRow;
        }

        private AnswerInputRow GetAnswerInputRow() 
        {
            var answerInputRow = new AnswerInputRow();

            answerInputRow.Answer = "";
            answerInputRow.Margin = new Padding(0, 10, 0, 0);
            answerInputRow.Size = new Size(736, 44);
            answerInputRow.TabIndex = 0;
            answerInputRow.GoDeleteClicked += answerRow_GoDeleteClicked!;

            return answerInputRow;
        }
    }
}
