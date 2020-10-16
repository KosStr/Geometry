using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Geometry1
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Thread thread;

        public Form1()
        {
            InitializeComponent();
        }

        public void CreateRectangle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            SolidBrush brush1 = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.White);
            graphics.DrawLine(pen, x1, y1, x2, y2);
            graphics.DrawLine(pen, x2, y2, x3, y3);
            graphics.DrawLine(pen, x3, y3, x4, y4);
            graphics.DrawLine(pen, x4, y4, x1, y1);
        }

        public void CreateLine(float x1, float y1, float x2, float y2)
        {
            Pen pen = new Pen(Color.Red);
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }

        public void Animation()
        {
            graphics = pictureBox1.CreateGraphics();

            SolidBrush fon = new SolidBrush(Color.Black);

            float x1 = Convert.ToSingle(textBox1.Text); // 40
            float y1 = Convert.ToSingle(textBox2.Text); // 40

            float x2 = Convert.ToSingle(textBox3.Text); // 100
            float y2 = Convert.ToSingle(textBox4.Text); // 40

            float x3 = Convert.ToSingle(textBox5.Text); // 100
            float y3 = Convert.ToSingle(textBox6.Text); // 100

            float x4 = Convert.ToSingle(textBox7.Text); // 40
            float y4 = Convert.ToSingle(textBox8.Text); // 100

            float t = 0;

            float diagonal = (float)(((x2 - x1) / 2) * Math.Sqrt(2));

            float center = ((x1 + x2) / 2);

            while (x1 <= 700 && x2 <= 700 && x3 <= 700 && x4 <= 700)
            {
                float move = 30 * t;
                graphics.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);

                CreateLine(700, 0, 700, pictureBox1.Height);
                CreateLine(0, center, pictureBox1.Width, center);

                CreateRectangle(x1, y1, x2, y2, x3, y3, x4, y4);

                x1 = (float)(Math.Sin(t) * diagonal + center + move);
                y1 = (float)(Math.Cos(t) * diagonal + center);

                x2 = (float)(Math.Sin(t + Math.PI / 2) * diagonal + center + move);
                y2 = (float)(Math.Cos(t + Math.PI / 2) * diagonal + center);

                x3 = (float)(Math.Sin(t + Math.PI) * diagonal + center + move);
                y3 = (float)(Math.Cos(t + Math.PI) * diagonal + center);

                x4 = (float)(Math.Sin(t - Math.PI / 2) * diagonal + center + move);
                y4 = (float)(Math.Cos(t - Math.PI / 2) * diagonal + center);

                t += (float)(0.1);

                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(Animation);
            thread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread.Suspend();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread.Resume();
        }
    }
}
