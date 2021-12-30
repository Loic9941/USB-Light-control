using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Light_control
{
   
    public partial class Form1 : Form
    {
        private const string Value = "cd\\";
        string[,] myArray = new string[,]
{
            {"129","193","128"},
            {"130","194","128"},
            {"131","195","128"}
        };
        int Line;
        int Colonne;
        private Process proc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Colonne = 0;
            }
            else if (radioButton2.Checked==true)
            {
                Colonne = 1;
            }
            else if (radioButton3.Checked==true)
            {
                Colonne = 2;
            }
            else
            {

            }
            if (radioButton4.Checked == true)
            {
                Line = 0;
            }
            else if (radioButton5.Checked == true)
            {
                Line = 1;
            }
            else if (radioButton6.Checked == true)
            {
                Line = 2;
            }
            else
            {

            }
            StreamWriter sw = new StreamWriter("USB Color.bat");
            sw.WriteLine("@echo off");
            sw.WriteLine(Value);
            sw.WriteLine("cd /d C:\\Program Files\\RW-Everything");
            sw.WriteLine("rw.exe /command=ScriptName.rw");
            
            sw.WriteLine("Start /b rw.exe /Command=\"WEC 0xF7 " + myArray[Line,Colonne]+"\"");
            sw.WriteLine("ECHO Applying... ");
            sw.WriteLine("timeout /t 2");
            sw.WriteLine("taskkill /im rw.exe /f");
            sw.WriteLine("timeout /t 3");
            sw.Close();
            proc = new Process();
            proc.StartInfo.FileName = "USB Color.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            File.Delete("USB color.bat");





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
