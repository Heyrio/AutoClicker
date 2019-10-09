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
            string inputHexColorCode = textBox1.Text;
            MessageBox.Show("Color " + inputHexColorCode + " is locked on!", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            for (int i = 0; i < 200; i++) {
                SearchPixel(inputHexColorCode);
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                System.Threading.Thread.Sleep(300);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Console.WriteLine("Training Mouse..");
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            //For The troll Face
        }

        //Gets Hexadecimal color
   

        private bool SearchPixel(string hexcode) {
            //creates an empty bitmap with the size of the screen
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);

            for (int i = 0; i < SystemInformation.VirtualScreen.Width; i++) {

                for (int j = 0; j < SystemInformation.VirtualScreen.Height; j++) {
                    Color currentPixelColor = bitmap.GetPixel(i, j);

                    if (desiredPixelColor == currentPixelColor) {
                           this.Cursor = new Cursor(Cursor.Current.Handle);
                           Cursor.Position = new Point(i, j);
                        return true;
                    }

                }
            
            }
            return false;
        }
    }
}
