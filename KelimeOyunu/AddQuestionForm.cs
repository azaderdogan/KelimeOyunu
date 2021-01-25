using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class AddQuestionForm : Form
    {
        public AddQuestionForm()
        {
            InitializeComponent();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addAsk_Click(object sender, EventArgs e)
        {
            using (KelimeOyunu kelimeOyunu = new KelimeOyunu())
            {
                AskQuestion askQuestion = new AskQuestion();
                askQuestion.ask = question.Text ;
                askQuestion.word = word.Text;
                Console.WriteLine(askQuestion.ask);
                DbHelper.GetDbHelper().save(askQuestion);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            
        }
    }
}
