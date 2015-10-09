using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DisconnectDB
{
    public partial class DisconnectForm : Form
    {
        public DisconnectForm()
        {
            InitializeComponent();
        }

        int CounterTimer = 10;
        Thread thCopy;
        private void DisconnectForm_Load(object sender, EventArgs e)
        {
            timerWait.Enabled = true;
            foreach (System.Diagnostics.Process clsProcess in System.Diagnostics.Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes by using the StartsWith Method,
                //this prevents us from including the .EXE for the process we're looking for.
                //. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running

                try
                {
                    if (clsProcess.ProcessName.StartsWith("MakeClassSchedule"))
                    {
                        //since we found the process we now need to use the
                        //Kill Method to kill the process. Remember, if you have
                        //the process running more than once, say IE open 4
                        //times the loop three way it is now will close all 4,
                        //if you want it to just close the first one it finds
                        //then add a return; after the Kill
                        clsProcess.Kill();
                        //process killed, return true
                    }
                }
                catch { }

            }
            thCopy = new Thread(new ThreadStart(StartCopy));
            thCopy.Start();
        }

        private void StartCopy()
        {
            thCopy.Join(1000);
            try
            {
                string FileName = System.IO.File.ReadAllText("Copy.Log");
                System.IO.File.Copy("ClassSchedule.mdf", FileName, true);
                System.IO.File.Delete("Copy.Log");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            finally
            {
                thCopy.Join(2000);
                System.Diagnostics.Process.Start("MakeClassSchedule.exe");
                Application.Exit();
            }
        }

        private void timerWait_Tick(object sender, EventArgs e)
        {
            switch (CounterTimer)
            {
                case 10: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_02;
                    lblWait.Text = "Please Wait ";
                    CounterTimer = 20;
                    break;
                case 20: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_03;
                    lblWait.Text = "Please Wait .";
                    CounterTimer = 30;
                    break;
                case 30: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_04;
                    lblWait.Text = "Please Wait . .";
                    CounterTimer = 40;
                    break;
                case 40: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_05;
                    lblWait.Text = "Please Wait . . .";
                    CounterTimer = 50;
                    break;
                case 50: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_06;
                    lblWait.Text = "Please Wait . . . .";
                    CounterTimer = 60;
                    break;
                case 60: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_07;
                    lblWait.Text = "Please Wait . . . . .";
                    CounterTimer = 70;
                    break;
                case 70: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_08;
                    lblWait.Text = "Please Wait ";
                    CounterTimer = 80;
                    break;
                case 80: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_09;
                    lblWait.Text = "Please Wait .";
                    CounterTimer = 90;
                    break;
                case 90: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_10;
                    lblWait.Text = "Please Wait . .";
                    CounterTimer = 100;
                    break;
                case 100: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_11;
                    lblWait.Text = "Please Wait . . .";
                    CounterTimer = 110;
                    break;
                case 110: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_01;
                    lblWait.Text = "Please Wait . . . .";
                    CounterTimer = 10;
                    break;
                default: 
                    this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_01;
                    lblWait.Text = "Please Wait . . . . .";
                    CounterTimer = 10;
                    break;
            }
        }
    }
} 
