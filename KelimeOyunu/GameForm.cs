using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KelimeOyunu
{
    public partial class GameForm : Form
    {
        private int totalPoint = 0;
        private List<AskQuestion> askQuestions;
        Random random = new Random();
        private int randomNumber;
        private int randomLetterNumber;
        public GameForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void otherAsk_Click(object sender, EventArgs e)
        {
            randomNumber = random.Next(0, (askQuestions.Count - 1));
           
            panel.Controls.Clear();
            letters.Clear();
            openedIndex.Clear();
            openedLetterLabel.Clear();
            
            setAsk();
        }

        async void getAll()
        {
            askQuestions = DbHelper.GetDbHelper().GetAllQuestion();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
           getAll();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            randomNumber = random.Next(0,(askQuestions.Count-1 ));
            setAsk();
        }

       
        
        private int minute = 4;
        private int second = 59;
        private void timer1_Tick(object sender, EventArgs e)
        {
            second--;
            if (second == 0)
            {
                minute--;
                second = 59;
            }

            if (minute == 0 && second == 0)
            {
                finishGame();
            }
            timerLabel.Text = minute+" : "+second;
        }

        private void finishGame()
        {

        }

        private HashSet<Label> openedLetterLabel = new HashSet<Label>();
        private List<int> openedIndex = new List<int>();
        private void letterTakeBtn_Click(object sender, EventArgs e)
        {
            
            int nowLetter = 0;
            if (openedIndex.Count == currentaskQuestion.word.Length)
            {
                return;
            }
            while (true)
            {
                bool isSelected = false;
                nowLetter = random.Next(0, currentaskQuestion.word.Length);
                foreach (int i in openedIndex)
                {
                    if (nowLetter == i)
                    {
                        Console.WriteLine("Seçilen index seçildi");
                        isSelected = true;
                        

                    }

                }

                if (!isSelected)
                {
                 break;  
                 return;
                }
            }

            Label label;
            
            label = letters.ElementAt(nowLetter);
            
            totalPoint -= 10;
            
            point.Text = totalPoint.ToString();
            
            openedIndex.Add(nowLetter);
            
            label.Visible = true;
            openedLetterLabel.Add(label);
            Console.WriteLine("Harf alındı.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tahmin et
            if (answerTxt.Text.Equals(currentaskQuestion.word))
            {
                //todo
                totalPoint = (currentaskQuestion.word.Length - openedIndex.Count) * 10;
                point.Text = totalPoint.ToString();
            }
        }

        private AskQuestion currentaskQuestion = null;
        private List<Label> letters = new List<Label>();
        private void setAsk()
        {
            
            currentaskQuestion = askQuestions.ElementAt(randomNumber);
            question.Text = currentaskQuestion.ask;
            randomLetterNumber = currentaskQuestion.word.Length;
            letterNote.Text = "Not: Kelime " + randomLetterNumber + " harflidir";
            for (int i = 0; i < currentaskQuestion.word.Length; i++)
            {
                Label label = new Label();
                label.Font = new Font("Arial", 25, FontStyle.Bold);
                label.AutoSize = true;
                label.Location = new Point(i * 40, 0);
                label.Visible = false;
                if (i  == currentaskQuestion.word.Length)
                {
                    label.Text = currentaskQuestion.word.Substring(i+1);
                }
                else
                {
                    label.Text = currentaskQuestion.word.Substring(i, 1);
                    Console.WriteLine(label.Text);
                }
                letters.Add(label);

                panel.Controls.Add(label);

                //listBox1.Items.Add(label);
                Console.WriteLine("label eklendi");
                
            }
            
            
        }
    }
}
