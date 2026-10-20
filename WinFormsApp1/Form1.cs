//**********************************************************************************************************
//**                                                                                                      **
//**        STUDENT NAME: Erdoðan BULUT                                                                   **
//**        STUDENT NUMBER: B221202021                                                                    **
//**********************************************************************************************************

namespace WinFormsApp1
{
    // It's a partial class which represents a form with UI elements and event handlers
    public partial class Form1 : Form
    {
        private Polygon polygon;  // It's a polygon instance
        private ColorRGB color;  // It's a color instance

        // It's a constructor which initialize the form and polygon
        public Form1()
        {
            InitializeComponent();
            polygon = new Polygon();
            color = new ColorRGB();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // This is an event handler when clicked on button1 for calculating edge coordinates and drawing the polygon in pictureBox1
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();

            // These are calculations to find center coordinates of pictureBox1 
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            Point2D center = new Point2D(int.Parse(textBox1.Text) + centerX, -int.Parse(textBox2.Text) + centerY);

            color.red_ = trackBar1.Value;
            color.green_ = trackBar2.Value;
            color.blue_ = trackBar3.Value;


            polygon = new Polygon(center, int.Parse(textBox3.Text), color, int.Parse(textBox4.Text));

            polygon.calculateEdgeCoordinates();

            listBox1.Items.Clear();
            listBox1.Items.Add("Point: Cartesian Coordinates");
            // There is a division with 10 because in Polygon class I multiply with 10.
            // I do this division because I don't want to change coordinates.
            for (int i = 0; i < polygon.numberOfEdges_; i++)
            {
                Point2D edgePoint = new Point2D((polygon.edges[i].X - centerX) / 10, -(polygon.edges[i].Y - centerY) / 10);

                edgePoint.printCoordinates(listBox1, "Point" + (i + 1));
            }
            listBox1.Items.Add("Point: Polar Coordinates");
            for (int i = 0; i < polygon.numberOfEdges_; i++)
            {
                Point2D edgePoint = new Point2D((polygon.edges[i].X - centerX) / 10, (polygon.edges[i].Y - centerY) / 10);
                center.calculatePolarCoordinates((polygon.edges[i].X - centerX) / 10, (polygon.edges[i].Y - centerY) / 10);

                edgePoint.printPolarCoordinates(listBox1, "Point" + (i + 1));
            }

            graphics.Clear(Color.White);

            graphics.DrawPolygon(new Pen(color.ToColor(), 2), polygon.edges);
        }

        // This is an event handler when clicked on button2  for rotating the polygon and updating the display
        private void button2_Click(object sender, EventArgs e)
        {
            int rotationAngle;
            if (checkBox1.Checked)
            {
                rotationAngle = -int.Parse(textBox5.Text);
            }
            else
            {
                rotationAngle = int.Parse(textBox5.Text);
            }

            polygon.rotatePolygon(rotationAngle);

            Graphics graphics = pictureBox1.CreateGraphics();

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            listBox1.Items.Clear();
            listBox1.Items.Add("Point: Cartesian Coordinates");
            // There is a division with 10 because in Polygon class I multiply with 10.
            // I do this division because I don't want to change coordinates.
            for (int i = 0; i < polygon.numberOfEdges_; i++)
            {
                Point2D edgePoint = new Point2D((polygon.edges[i].X - centerX) / 10, (polygon.edges[i].Y - centerY) / 10);
                edgePoint.printCoordinates(listBox1, "Point" + (i + 1));
            }
            listBox1.Items.Add("Point: Polar Coordinates");
            for (int i = 0; i < polygon.numberOfEdges_; i++)
            {
                Point2D edgePoint = new Point2D((polygon.edges[i].X - centerX) / 10, (polygon.edges[i].Y - centerY) / 10);
                edgePoint.printPolarCoordinates(listBox1, "Point" + (i + 1));
            }

            graphics.Clear(Color.White);

            color.red_ = trackBar1.Value;
            color.green_ = trackBar2.Value;
            color.blue_ = trackBar3.Value;

            graphics.DrawPolygon(new Pen(color.ToColor(), 2), polygon.edges);
        }

        // This is an event handler when clicked on button3 for generating random values and updating text boxes
        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            textBox1.Text = random.Next(0, 2).ToString();
            textBox2.Text = random.Next(0, 2).ToString();
            textBox3.Text = random.Next(3, 8).ToString();
            textBox4.Text = random.Next(3, 9).ToString();
            textBox5.Text = random.Next(0, 359).ToString();
            trackBar1.Value = random.Next(0, 254);
            trackBar2.Value = random.Next(0, 254);
            trackBar3.Value = random.Next(0, 254);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
