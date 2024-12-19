﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingVGLTU.WinForms.Forms.Teacher.CreateTesting.EditQuestion
{
    public partial class EditQuestionForm : Form
    {
        public EditQuestionForm()
        {
            InitializeComponent();
        }

        private void TextBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
