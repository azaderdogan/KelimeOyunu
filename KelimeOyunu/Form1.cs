using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text.Equals("admin")& passwordTxt.Text.Equals("1234"))
            {
             ;
                alert.Text = "Başarılı";
                GameForm gameForm = new GameForm();
                gameForm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre Hatalı\nLütfen tekrar deneyiniz");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddQuestionForm addQuestionForm = new AddQuestionForm();
            addQuestionForm.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
