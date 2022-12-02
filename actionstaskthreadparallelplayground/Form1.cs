using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace actionstaskthreadparallelplayground
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int mod = 0;
       
        public  delegate string fx(string g);
        fx strOp;
        
         static string RemoveSpaces(string s) 
         {
            string temp = "";
            int i;
            Console.WriteLine("Removing spaces.");
            for(i=0; i < s.Length; i++)
                if(s[i] != ' ') temp += s[i];
            return temp;
          }
        
        private void button5_Click(object sender, EventArgs e)
        {
           

            // use an Action delegate and a named method
            Task task1 = new Task(new Action(printMessage));
            // use a anonymous delegate
            Task task2 = new Task(delegate
            {
                printMessage();
            });
            // use a lambda expression and a named method
            Task task3 = new Task(() => printMessage());
            // use a lambda expression and an anonymous method
            Task task4 = new Task(() =>
            {
                printMessage();
            });
            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            // wait for input before exiting

            strOp = new fx(RemoveSpaces);
            
        }

        public void printMessage()
        {
            
            // create the task
            Task<int> task1 = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                    
                }
                return sum;
            });
            // start the task
            task1.Start();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mod = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mod = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mod = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mod = 4;
        }
    }
}
