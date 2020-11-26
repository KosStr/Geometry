using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Graphics2
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Thread thread;
        Random random = new Random();
        Planet Star;

        public static string planetsInfo = "";

        public Form1()
        {
            this.BackgroundImage = Properties.Resources.solar1;
            InitializeComponent();
        }

        public Planet[] InitPlanets(ref Planet Star)
        {
            Star = new Planet { X = (pictureBox1.Width / 2) - 300 / 2, Y = (pictureBox1.Height / 2) - 300 / 2, Radius = 300 };

            int arraySize = Convert.ToInt32(numericUpDown1.Value);
            Planet[] planets = new Planet[arraySize];
            for (int i = 0; i < planets.Length; ++i)
            {
                planets[i] = new Planet();
            }

            planets[0].Speed = 1;
            planets[0].DistanceToSun = Convert.ToInt32(planetsInfo.Split()[0]);
            planets[0].Radius = Convert.ToInt32(planetsInfo.Split()[1]);
            planets[0].X = Star.X + planets[0].DistanceToSun;
            planets[0].Y = Star.Y;

            for (int i = 1; i < arraySize; ++i)
            {
                planets[i].DistanceToSun = Convert.ToInt32(planetsInfo.Split()[i * 2]);
                planets[i].Radius = Convert.ToInt32(planetsInfo.Split()[i * 2 + 1]);
                planets[i].Y = Star.Y;
                planets[i].X = planets[0].DistanceToSun;
                planets[i].Speed = Math.Sqrt(planets[0].DistanceToSun / planets[i].DistanceToSun) * (planets[0].DistanceToSun / planets[i].DistanceToSun);
            }
            return planets;
        }

        Color GetRandomColor()
        {
            return Color.FromArgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
        }

        public void CreatePlanet(Color color, Planet planet)
        {
            Pen pen = new Pen(color);
            SolidBrush brush = new SolidBrush(color);
            graphics.DrawEllipse(pen, (float)planet.X, (float)planet.Y, (float)planet.Radius, (float)planet.Radius);
            graphics.FillEllipse(brush, (float)planet.X, (float)planet.Y, (float)planet.Radius, (float)planet.Radius);
        }

        public void SolarSystemAnimation()
        {
            graphics = pictureBox1.CreateGraphics();

            SolidBrush fon = new SolidBrush(Color.Black);

            int arraySize = Convert.ToInt32(numericUpDown1.Value);

            Planet[] planets = InitPlanets(ref Star);

            Color[] colorArray = new Color[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                colorArray[i] = GetRandomColor();
            }

            double time = 0;

            while (true)
            {
                graphics.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);

                time += 0.03;

                for (int i = 0; i < arraySize; ++i)
                {
                    if (planets[i].Y < Star.Y) 
                    {
                        CreatePlanet(colorArray[i], planets[i]);
                        planets[i].X = Star.X + Star.Radius / 2 - planets[i].Radius / 2 + Math.Sin(time * planets[i].Speed) * planets[i].DistanceToSun;
                        planets[i].Y = Star.Y + Star.Radius / 2 - planets[i].Radius / 2 + Math.Cos(time * planets[i].Speed) * planets[i].DistanceToSun * 0.6;
                    }
                }

                CreatePlanet(Color.Yellow, Star);

                for (int i = 0; i < arraySize; ++i)
                {
                    if (planets[i].Y >= Star.Y)
                    {
                        CreatePlanet(colorArray[i], planets[i]);
                        planets[i].X = Star.X + Star.Radius / 2 - planets[i].Radius / 2 + Math.Sin(time * planets[i].Speed) * planets[i].DistanceToSun;
                        planets[i].Y = Star.Y + Star.Radius / 2 - planets[i].Radius / 2 + Math.Cos(time * planets[i].Speed) * planets[i].DistanceToSun * 0.6;
                    }
                }

                Thread.Sleep(1000);
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            thread.Suspend();
        }

        private void resume_Click(object sender, EventArgs e)
        {
            thread.Resume();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var planetInput = new PlanetInput();
            planetInput.Show();
        }

        private void start_Click_1(object sender, EventArgs e)
        {
            thread = new Thread(SolarSystemAnimation);
            thread.Start();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Aqua;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
