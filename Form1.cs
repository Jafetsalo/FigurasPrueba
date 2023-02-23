using System.Drawing;
using System.Windows.Forms;
using static Test2.Form1;

namespace Test2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Circle");
            comboBox1.Items.Add("Polygon");

        }

        private Point[] createCirclePoints(double radio)
        {
            Point[] points = new Point[360];
            int setX = (int)numericUpDownX.Value;
            int setY = (int)numericUpDownY.Value;

            for (int p = 0; p < 360; p++)
            {
                int Xvalue = Convert.ToInt32(Math.Cos(p) * radio);
                int Yvalue = Convert.ToInt32(Math.Sin(p) * radio);
                points[p] = new Point(Xvalue + setX, Yvalue + setY);
            }

            return points;

        }

        private Point[] createRegularPolygonPoints(int numberOfSides, double radius)
        {
            Point[] points = new Point[numberOfSides + 1];

            double reference = 2 * Math.PI / numberOfSides;

            int setX = (int)numericUpDownX.Value;
            int setY = (int)numericUpDownY.Value;

            for (int p = 0; p < numberOfSides; p++)
            {
                int Xvalue = Convert.ToInt32(Math.Cos((p + 1) * reference) * radius);
                int Yvalue = Convert.ToInt32(Math.Sin((p + 1) * reference) * radius);
                //int Xnextvalue = Convert.ToInt32(Math.Cos((p + 2) * reference));
                //int Ynextvalue = Convert.ToInt32(Math.Sin((p + 2) * reference));
                points[p] = new Point(Xvalue + setX, Yvalue + setY);


                /*for (int x = 0; x < resolution; x++) 
                {
                    int Yside = (Ynextvalue - Yvalue) / resolution;
                    int Xside = (Xnextvalue - Xvalue) / resolution;
                    points[]=
                }*/


            }
            points[points.Length - 1] = new Point(points[0].X, points[0].Y);

            return points;
        }



        public class Figure
        {
            internal double Radius;
            internal Point[] points;

            internal double Apothem;

            //central point coordinates 
            internal int x;
            internal int y;
        }

        public class Circle : Figure
        {


            internal Circle(Point[] Points, double radius, int x, int y)
            {
                Radius = radius;

                this.points = Points;

                this.x = x;
                this.y = y;
            }

            internal double calculatePerimeter_Circle()
            {
                double perimeter = this.Radius * Math.PI * 2;

                return perimeter;

            }

            internal double calculateArea_Circle()
            {

                double area = Math.PI * Math.Pow(Radius, 2);

                return area;
            }
        }

        public class Polygon : Figure
        {
            internal int sides;
            internal Polygon(Point[] Points, double radius, int x, int y)
            {
                double Apothem;
                Radius = radius;

                points = Points;

                this.x = x;
                this.y = y;
            }

            internal double calculatePerimeter_Polygon()
            {
                double side = Math.Sin(Math.PI / sides) * Radius * 2;

                return side * sides;

            }

            internal double calculateArea_Polygon()
            {
                double side = Math.Sin(Math.PI / sides) * Radius * 2;
                Apothem = Math.Cos(Math.PI / sides) * Radius;
                return side * Apothem * sides / 2;

            }
        }


        /* List<Point> points = new List<Point>()
             {
             new Point(10,  10),
             new Point(10, 100),
             new Point(200,  50),
             new Point(250, 300)
             };
        */




        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            Pen pen = new Pen(Color.Black, 3);

            // Create array of points that define lines to draw.

            //Draw lines to screen.

            if (comboBox1.Text == "Circle")
            {
                double radius = (double)numericUpDownRadio.Value;
                int setX = (int)numericUpDownX.Value;
                int setY = (int)numericUpDownY.Value;
                Circle mycircle = new Circle(createCirclePoints(radius), radius, setX, setY);
                e.Graphics.DrawLines(pen, mycircle.points);

                labelPerimeter.Text = "Perimeter:" + mycircle.calculatePerimeter_Circle().ToString();
                labelArea.Text = "Area:" + mycircle.calculateArea_Circle().ToString();

            }
            else if (comboBox1.Text == "Polygon")
            {
                double radius = (double)numericUpDownRadio.Value;
                int setX = (int)numericUpDownX.Value;
                int setY = (int)numericUpDownY.Value;
                int sides = (int)numericUpDownSides.Value;
                Polygon mypolygon = new Polygon(createRegularPolygonPoints(sides, radius), radius, setX, setY);
                mypolygon.sides = sides;

                e.Graphics.DrawLines(pen, mypolygon.points);

                labelPerimeter.Text = "Perimeter:" + mypolygon.calculatePerimeter_Polygon().ToString();
                labelArea.Text = "Area:" + mypolygon.calculateArea_Polygon().ToString();

            }



        }


        private void button1_Click(object sender, EventArgs e)
        {


            // numberofpoints = int.Parse(numericUpDownX.Value.ToString());
            // int y = int.Parse(numericUpDownY.Value.ToString());


            this.Refresh();

        }


        private void comboBox1_Change(object sender, EventArgs e)
        {


            /*if (comboBox1.Text.ToString() == "Circle")
            {

                numericUpDownSides.Enabled= false;

            }
            
            if (comboBox1.Text.ToString() == "Polygon")
            {
                numericUpDownSides.Enabled = true;
            }
            */

            this.Refresh();

        }

        /*
        private void createPointArray(Point p, int numberOfSides) 
        {
            numberOfSides = int.Parse(numericUpDown3.Value.ToString());
            Point[] points = new Point[numberOfSides];

            //We have created the empty array, let's populate it

            int x = int.Parse(numericUpDown1.Value.ToString());
            int y = int.Parse(numericUpDown2.Value.ToString());
            points[0] = ;

            //I need to figure out how to call the paint method


        }

        */

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}