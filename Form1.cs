using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        konus_class conus = new konus_class(2, 2);
        private bool flag = false;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// A class for calculating the diameter and volume of a straight cone.
        /// </summary>
        public class konus_class
        {
            public double radius;
            public double height;

            public konus_class(double radius, double height)
            {
                this.radius = radius;
                this.height = height;
            }
            public konus_class(double radius)
            {
                this.radius = radius;
            }
            public double Calcul_Diameter()
            {
                return 2 * radius;
            }

            public double Calcul_Volume()
            {
                return (Math.PI * Math.Pow(radius, 2) * height) / 3;
            }
            public double Radius()
            {
                return radius;
            }
            public double Height()
            {
                return height;
            }
        }


        private void buttonDiam_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                textBox3.Text = conus.Calcul_Diameter().ToString();
                return;
            }

            double radius;
            if (double.TryParse(textBox1.Text, out radius))
            {
                if (radius > 0)
                {
                    konus_class cone = new konus_class(radius);
                    textBox3.Text = cone.Calcul_Diameter().ToString();
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение радиуса");
                }
            }
            else
            {
                MessageBox.Show("Не введено значение радиуса");
            }
        }

        private void buttonVolume_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                textBox4.Text = conus.Calcul_Volume().ToString();
                return;
            }

            double radius, height;
            if (double.TryParse(textBox1.Text, out radius) && double.TryParse(textBox2.Text, out height))
            {
                if (radius > 0 && height > 0)
                {
                    konus_class cone = new konus_class(radius, height);
                    textBox4.Text = cone.Calcul_Volume().ToString();
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение");
                }
            }
            else
            {
                MessageBox.Show("Не все значения введены");
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            flag = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            double radius;
            double height;
            if (double.TryParse(textBox1.Text, out radius) && double.TryParse(textBox2.Text, out height))
            {
                conus = new konus_class(radius, height);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            textBox1.Text = conus.Radius().ToString();
            textBox2.Text = conus.Height().ToString();
            double radius;
            double height;
            if (double.TryParse(textBox1.Text, out radius) && double.TryParse(textBox2.Text, out height))
            {
                if (radius > 0 && height > 0)
                {
                    textBox3.Text = conus.Calcul_Diameter().ToString();
                    textBox4.Text = conus.Calcul_Volume().ToString();
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение");
                }
            }
         
            
        }
    }
}
