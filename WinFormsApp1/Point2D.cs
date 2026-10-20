//**********************************************************************************************************
//**                                                                                                      **
//**        STUDENT NAME: Erdoğan BULUT                                                                   **
//**        STUDENT NUMBER: B221202021                                                                    **
//**********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    // There is a 2D point with its Cartesian and Polar coordinates
    internal class Point2D
    {
        private Random random = new Random(); // This line is for generating random numbers from C#'s random class
        private float x; // It's a X coordinate of that 2D point in Cartesian coordinate system
        private float y; // It's a Y coordinate of that 2D point in Cartesian coordinate system
       
        // It's a property to access X coordinate
        public float x_
        {
            get { return x; }
            set { x = value; }
        }

        // It's a property to access Y coordinate
        public float y_
        {
            get { return y; }
            set { y = value; }
        }

        public double r; // It's a radius of that 2D point in Polar coordinate system
        public double tetha; // It's an angle of that 2D point in Polar coordinate system

        //It's a default constructor which initialize point at origin
        public Point2D()
        {
            x = 0;
            y = 0;
        }

        // It's a constructor with parameters to initialize point at given coordinates 
        public Point2D(float x_, float y_)
        {
            x = x_;
            y = y_;
        }

        // It's a function which print Cartesian coordinates in listbox
        public void printCoordinates(ListBox listBox, string pointLabel = "")
        {
            string coordinates = pointLabel + ": " + x + "  " + y;
            listBox.Items.Add(coordinates);
        }

        // It's a method which calculate Polar coordinates from Cartesian coordinates
        public void calculatePolarCoordinates(float centerX, float centerY)
        {
            r = Math.Sqrt(centerX * centerX + centerY * centerY);
            tetha = Math.Atan2(centerY, centerX) * 180 / Math.PI;
            if (tetha < 0) // I don't want to see negative degrees so, this line converts them to positive
                tetha += 360;
            if (centerX != 0 && centerY != 0)
                tetha = 360 - tetha;
            // When the center of the polygon is moved on y axis tetha shows 0 but expected value is 90. It's shows 0 because x axis 0 when edges on the y axis.
            // This is an if statement which solves that problem
            if (centerX == 0 && centerY == 0 && tetha == 0)
                tetha = 90;
            if (tetha == 360) // It's the same thing but I want to convert 360 to 0
                tetha = 0;

            r = Math.Round(r, 2);
            tetha = Math.Round(tetha, 2);
        }

        // It's a method which calculate Cartesian coordinates from Polar coordinates
        public void calculateCartesianCoordinates()
        {
            float tethaRad = (float)(tetha * Math.PI / 180.0);
            x = (float)(r * Math.Cos(tethaRad));
            y = (float)(r * Math.Sin(tethaRad));
        }

        // It's a function which print Polar coordinates in listbox
        public void printPolarCoordinates(ListBox listBox, string pointLabel = "")
        {
            calculatePolarCoordinates(x, y);
            string coordinates = pointLabel + ": " + r + "  " + tetha;
            listBox.Items.Add(coordinates);
        }


    }
}
