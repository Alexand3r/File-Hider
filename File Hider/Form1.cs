using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Hider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            textBox2.Text = openFileDialog2.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
                        //Archive file
            string the_rar;
            RegistryKey the_Reg;
            object the_Obj;
            string the_Info;
            ProcessStartInfo the_StartInfo;
            Process the_Process;
            try
            {
                the_Reg = Registry.ClassesRoot.OpenSubKey(@"Applications\WinRAR.exe\Shell\Open\Command");
                the_Obj = the_Reg.GetValue("");
                the_rar = the_Obj.ToString();
                the_Reg.Close();
                the_rar = the_rar.Substring(1, the_rar.Length - 7);
                the_Info = string.Format(" a " +" "+ "\""+textBox1.Text+".rar\" " + " " + "\""+@textBox1.Text+"\"");
                label1.Text = the_Info;
                the_StartInfo = new ProcessStartInfo();
                
                the_StartInfo.FileName = the_rar;
                the_StartInfo.Arguments = the_Info;
                the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                the_StartInfo.CreateNoWindow = true;
               // the_StartInfo.WorkingDirectory = @"C:\test\";
                the_Process = new Process();
                the_Process.StartInfo = the_StartInfo;
                the_Process.Start();
                MessageBox.Show("success");
            }
            catch
            {
              
            }

                        //Merge Files
            string cmd = string.Format(@"/c copy /b " + "\"" + textBox2.Text.ToString() + "\"" + " + " + "\"" + textBox1.Text + ".rar\" " + textBox3.Text + "hidden.jpg");
                        
                        ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                        psi.Arguments = cmd;
                        
                        psi.RedirectStandardOutput = true;
                        psi.UseShellExecute = false;
                        psi.CreateNoWindow = true;
                        Process p = Process.Start(psi);
                        
                        string result = p.StandardOutput.ReadToEnd();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

       
    }
}
