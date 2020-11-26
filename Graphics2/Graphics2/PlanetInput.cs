using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graphics2
{
    public partial class PlanetInput : Form
    {
        public PlanetInput()
        {
            this.BackgroundImage = Properties.Resources.solar1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.planetsInfo = (textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + " " +
                                 textBox5.Text + " " + textBox6.Text + " " + textBox7.Text + " " + textBox8.Text + " " +
                                 textBox9.Text + " " + textBox10.Text + " " + textBox11.Text + " " + textBox12.Text + " " +
                                 textBox13.Text + " " + textBox14.Text + " " + textBox15.Text + " " + textBox16.Text);

            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void PlanetInput_Load(object sender, EventArgs e)
        {
            TransparetBackground(label12);
        }

        void TransparetBackground(Control C)
        {
            C.Visible = false;

            C.Refresh();
            Application.DoEvents();

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int Right = screenRectangle.Left - this.Left;

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
            C.BackgroundImage = bmp;

            C.Visible = true;
        }
    }
}
