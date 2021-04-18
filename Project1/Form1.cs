using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ctrl+shift+esc (Task Manager)
         [DllImport("User32.dll")] static extern int SetForegroundWindow(IntPtr point);
        private void button1_Click_1(object sender, EventArgs e)
        {            

            Process p = Process.GetProcessesByName("taskmanager").FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                //SendKeys.SendWait("");
            }
            else
            {
                Process islem = Process.Start("taskmgr.exe");
                islem.WaitForInputIdle();
                IntPtr h = islem.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("^(%({DEL}))");

                MessageBox.Show("ctrl+alt+del not available");
            }
        }
    }
}
