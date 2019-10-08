using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1 {
    public partial class AutoClicker : Form {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public AutoClicker() {
            InitializeComponent();
        }
        private void AutoClicker_Load(object sender, EventArgs e) {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
           
        }
        private void button1_Click(object sender, EventArgs e) {
            Console.WriteLine("Auto Mouse starting..");
            //timer1.Enabled = true;

            for (int i = 0; i < 1000; i++) {
                System.Threading.Thread.Sleep(100);
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                Console.WriteLine(X);
                Console.WriteLine(Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Console.WriteLine("Training Mouse..");
            //timer1.Enabled = false;

        }
        //private void timer1_Tick(object sender, EventArgs e) {
        //    uint X = (uint)Cursor.Position.X;
        //    uint Y = (uint)Cursor.Position.Y;
        //    Console.WriteLine(X);
        //    Console.WriteLine(Y);
        //    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        //}
  

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void button3_Click_1(object sender, EventArgs e) {
            textBox1.Text = textBox1.Text + "1";
        }
    }
}
