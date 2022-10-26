using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment7_MaksimTomilin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void resultsButton_Click(object sender, EventArgs e)
        {
            string[] correctAnswerArray = {"B","D","A","A","C",
                                           "A","B","A","C","D",
                                           "B","C","D","A","D",
                                           "C","C","B","D","A"};
            string[] myAnswerArray = new string[20];
            List<string> incorrectAnswerList = new List<string>();
            int count = 0, incorrectCount = 0, index = 0, questionNumber = 0;

            listBox1.Items.Clear();
            try
            {
                string filename = textBox1.Text;
                StreamReader inputFile = File.OpenText(filename);
                while (!inputFile.EndOfStream)
                {
                    myAnswerArray[index] = inputFile.ReadLine();

                    if (myAnswerArray[index] == correctAnswerArray[index])
                        count++;
                    else
                    {
                        questionNumber = index + 1;
                        incorrectAnswerList.Add(questionNumber.ToString());
                    }

                    index++;

                }
                inputFile.Close();

                if (count >= 15)
                {
                    textBox2.Text = "PASSED";
                }
                else
                {
                    textBox2.Text = "FAILED";
                }
                foreach (string str in incorrectAnswerList)
                {
                    listBox1.Items.Add(str);
                }
                textBox3.Text = count.ToString();
                incorrectCount = 20 - count;
                textBox4.Text = incorrectCount.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("FILE NOT FOUND");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            listBox1.Items.Clear();
        }
    }
}
