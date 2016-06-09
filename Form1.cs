//
//Name: Russell Anderson
//Course: C# programming
//Assignment: Lab 4 - create a driver liscense exam using arrays.  Prompt user to answer one question at 
//      a time.  Display results including how many and which questions were answered corrct/incorrect..

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndersonLab4
{
    public partial class Form1 : Form
    {  //correct answer array
        private static char[] answerKey = {'B', 'D', 'A', 'A', 'C', 'A', 'B', 'A', 'C', 'D',
                                           'B', 'C', 'D', 'A', 'D', 'C', 'C', 'B', 'D', 'A'};
        //correct answer key array
        private static char[] userAnswers = new char[answerKey.Length];
        //variables 
        private static int questionNumber = 1;
        private static int numAnsCorrect = 0;
        private static int numAnsIncorrect = 0;
        private static string incorrectText = "", status = "";

        public Form1()
        {
            InitializeComponent();
            rbNull.Checked = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //determine which answers user chooses
            if (rbA.Checked == true)
            {
                userAnswers[questionNumber - 1] = 'A';
            }
            else if (rbB.Checked == true)
            {
                userAnswers[questionNumber - 1] = 'B';
            }
            else if (rbC.Checked == true)
            {
                userAnswers[questionNumber - 1] = 'C';
            }
            else if(rbD.Checked == true)
            {
                userAnswers[questionNumber - 1] = 'D';
            }
            else {
                userAnswers[questionNumber - 1] = ' ';
                MessageBox.Show("\t" + MessageBoxIcon.Warning + "\n\n\tYou did not choose an answer \n"
                              + "\tYou will not recieve credit for this question");
            }
            //if user answer matches answer key...
            if (userAnswers[questionNumber - 1] == answerKey[questionNumber - 1])
            {
                numAnsCorrect++; //increment number correct answers
            }
            else
            {
                numAnsIncorrect++;
                incorrectText +="\nQuestion Number: " + questionNumber + "  " +
                                " Your Answer: " + userAnswers[questionNumber - 1]+ "  " +
                                " Correct Answer: " + answerKey[questionNumber - 1];
            }

            //determine if student passed/failed
            if (questionNumber == (answerKey.Length))
            {
                if (numAnsCorrect >= 15) //if user answered 15 or more correct...
                    status += "PASS";  //they pass

                else if (numAnsCorrect <= 14)
                {
                    status += "FAIL";
                }

                else if(numAnsCorrect == answerKey.Length)
                {
                    incorrectText += "None";
                }
                //display results
                MessageBox.Show("\t*************Exam Results*************" +
                                "\n\t    Number of correct answers: " + numAnsCorrect +
                                "\n\t    Number of incorrect answers: " + numAnsIncorrect +
                                "\n\t    Exam Pass/Fail status: " + status +
                                "\n\t****************************************" + 
                                "\n\t" + incorrectText);
                this.Close();
            }
            else
            {
                questionNumber++; //increment question number
                rbNull.Checked = true;
                lblQuestion.Text = "Question " + questionNumber.ToString(); //display question number
                if (questionNumber == answerKey.Length)
                {
                    btnNext.Text = "Submit Exam";
                }

            }
        }
       
            
        }
    }

