using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{

    public partial class Form1 : Form
    {
        Queue<Process> ReadyProcess=new Queue<Process>();
        Queue<Process> BlockedProcess = new Queue<Process>();
        Queue<Process> AuxilaryProcess = new Queue<Process>();
        Bitmap perform;
        int AllMemory = 100;
        int Allticks;
        int tick=0;

        Process RuningProcess=new Process();
        public Form1()
        {

            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Process process1 = new Process(1,Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox6.Text));
            Process process2 = new Process(2,Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox7.Text));
            Process process3 = new Process(3,Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox8.Text));
            Process process4 = new Process(4,Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox9.Text));
            Process process5 = new Process(5,Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox10.Text));
            ReadyProcess.Enqueue(process1);
            ReadyProcess.Enqueue(process2);
            ReadyProcess.Enqueue(process3);
            ReadyProcess.Enqueue(process4);
            ReadyProcess.Enqueue(process5);
            Allticks = Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox4.Text) + Convert.ToInt32(textBox5.Text);
         
            tick=0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            start();
            
        }
        public void start()
        {
            printAuxilaryProcess();
            printReadyProcess();
            printBlockedProcess();
            
            if (Allticks + 4 >= tick)
            {
                if (ReadyProcess.Count > 0 || AuxilaryProcess.Count>0)
                {
                    if (AuxilaryProcess.Count > 0)
                    {
                        RuningProcess = AuxilaryProcess.Dequeue();
                    }
                    else
                    {
                        RuningProcess = ReadyProcess.Dequeue();
                    }
                    
                    if (RuningProcess.Time <= RuningProcess.RunTimes)
                    {
                        Console.WriteLine(RuningProcess.Time + " " + RuningProcess.PID + " " + tick + " " + Allticks);

                        if (RuningProcess.BlockLine == RuningProcess.Time)
                        {
                            BlockedProcess.Enqueue(RuningProcess);
                            Console.WriteLine("k");
                            return;
                        }

                        if (RuningProcess.PID == 1)
                        {

                            progressBar1.Value = RuningProcess.Time * 100 / RuningProcess.RunTimes;
                            //chart1.Series["Series1"].Points.AddXY(tick, 0);
                            chart1.Series["Series1"].Points.AddXY(tick, 50);
                            //chart1.Series["Series1"].Points.AddXY(tick+1, 50);
                            //chart1.Series["Series1"].Points.AddXY(tick+1, 0);
                            ReadyProcess.Enqueue(RuningProcess);
                        }
                        else if (RuningProcess.PID == 2)
                        {
                            progressBar2.Value = RuningProcess.Time * 100 / RuningProcess.RunTimes;
                            //chart1.Series["Series2"].Points.AddXY(tick, 0);
                            chart1.Series["Series2"].Points.AddXY(tick, 50);
                            //chart1.Series["Series2"].Points.AddXY(tick + 1, 50);
                            //chart1.Series["Series2"].Points.AddXY(tick + 1, 0);
                            ReadyProcess.Enqueue(RuningProcess);
                        }
                        else if (RuningProcess.PID == 3)
                        {
                            progressBar3.Value = RuningProcess.Time * 100 / RuningProcess.RunTimes;
                            //chart1.Series["Series3"].Points.AddXY(tick, 0);
                            chart1.Series["Series3"].Points.AddXY(tick, 50);
                            //chart1.Series["Series3"].Points.AddXY(tick + 1, 50);
                            //chart1.Series["Series3"].Points.AddXY(tick + 1, 0);
                            ReadyProcess.Enqueue(RuningProcess);
                        }
                        else if (RuningProcess.PID == 4)
                        {
                            progressBar4.Value = RuningProcess.Time * 100 / RuningProcess.RunTimes;
                            //chart1.Series["Series4"].Points.AddXY(tick, 0);
                            chart1.Series["Series4"].Points.AddXY(tick, 50);
                            //chart1.Series["Series4"].Points.AddXY(tick + 1, 50);
                            //chart1.Series["Series4"].Points.AddXY(tick + 1, 0);
                            ReadyProcess.Enqueue(RuningProcess);
                        }
                        else if (RuningProcess.PID == 5)
                        {
                            progressBar5.Value = RuningProcess.Time * 100 / RuningProcess.RunTimes;
                            //chart1.Series["Series5"].Points.AddXY(tick, 0);
                            chart1.Series["Series5"].Points.AddXY(tick, 50);
                            //chart1.Series["Series5"].Points.AddXY(tick + 1, 50);
                            //chart1.Series["Series5"].Points.AddXY(tick + 1, 0);
                            ReadyProcess.Enqueue(RuningProcess);
                        }

                        RuningProcess.Time++;
                        tick++;
                    }

                    //timer.Interval = Allticks/tick * 100+10;
                    //Console.Write(timer.Interval);
                    
                }
            }
            else
            {
                timer.Enabled = false;
            }
            
            //printAuxilaryProcess();
        }
        void printReadyProcess()
        {
            int count = 0;
            String text = ""; ;
            while (count < ReadyProcess.Count)
            {
                count++;

                Process p = ReadyProcess.Dequeue();
                text = text + "\n" + "Process" + p.PID;
                ReadyProcess.Enqueue(p);
            }
            label6.Text = text;
        }
        void printBlockedProcess()
        {
            int count = 0;
            String text = ""; ;
            while (count < BlockedProcess.Count)
            {
                count++;

                Process p = BlockedProcess.Dequeue();
                text = text + "\n" + "Process" + p.PID;
                BlockedProcess.Enqueue(p);
            }
            label7.Text = text;
        }
        void printAuxilaryProcess()
        {
            int count = 0;
            String text = ""; ;
            while (count < AuxilaryProcess.Count)
            {
                count++;

                Process p = AuxilaryProcess.Dequeue();
                text = text + "\n" + "Process" + p.PID;
                AuxilaryProcess.Enqueue(p);
            }
            label8.Text = text;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Interrupt(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Interrupt(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Interrupt(3);
        }
        public void Interrupt(int pid)
        {
            if (BlockedProcess.Count > 0)
            {
                Process pro = BlockedProcess.Dequeue();
                while (true)
                {
                    if (pro.PID == pid)
                    {
                        break;
                    }
                    else
                    {
                        BlockedProcess.Enqueue(pro);
                        pro = BlockedProcess.Dequeue();
                    }
                }

                pro.BlockLine = 100;
                AuxilaryProcess.Enqueue(pro);
                //timer.Enabled = true;
                start();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Interrupt(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Interrupt(5);
        }

        private void pic_Click(object sender, EventArgs e)
        {
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            
          
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
    }
    public class Process{
        public int PID;
        public int RunTimes;
        public int Time;
        public int BlockLine;
        //public int RunMemory;
        public Process()
        {

        }
        public Process(int PID,int RunTimes,int BlockLine)
        {
            this.PID = PID;
            this.RunTimes = RunTimes;
            this.BlockLine = BlockLine;
            //this.RunMemory = 0;
        }
    }
}
