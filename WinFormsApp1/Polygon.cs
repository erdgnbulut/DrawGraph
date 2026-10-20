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

namespace WinFormsApp1
{
    // Represents a polygon with a center point, length, and number of edges
    internal class Polygon
    {
        private Random random = new Random(); // This line is for generating random numbers from C#'s random class
        private Point2D center;  // This is the center of the polygon
        private int length; // It's a distance between the center of the polygon and one of the edge points
        private ColorRGB color;
        private int numberOfEdges;
        public Point[] edges; // This is an array of points which represents the edges of the polygon

        // It's a property to access length measurement
        public int length_
        {
            get { return length; }
            set { length = value; }
        }

        // It's a property to access number of edges
        public int numberOfEdges_
        {
            get { return numberOfEdges; }
            set { numberOfEdges = value; }
        }

        // It's a default constructor which initial the center and edges
        public Polygon()
        {
            center = new Point2D();
            color = new ColorRGB();
            edges = new Point[numberOfEdges];
        }

        // It's a constructor with parameters which initialize the polygon with center, length, and number of edges
        public Polygon(Point2D center_, int length_,ColorRGB color_, int numberOfEdges_)
        {
            center = center_;
            length = length_;
            color = color_;
            numberOfEdges = numberOfEdges_;
            edges = new Point[numberOfEdges];
        }

        // It's a function which calculate coordinates of edges based on center, length, and number of edges
        public void calculateEdgeCoordinates()
        {
            int i = random.Next(numberOfEdges_); // This line selects a random edge index
            float angle = (float)(2 * Math.PI / numberOfEdges); // It's a calculation between edges in radian form
            edges[i].X = Convert.ToInt32(center.x_ + length * 10 * Math.Cos(i * angle));
            edges[i].Y = Convert.ToInt32(center.y_ + length * 10 * Math.Sin(i * angle));

            // It's a loop which calculate all edges coordinates
            for (int j = 0; j < numberOfEdges_; j++)
            {
                if (j == i) // We calculate one of edges in randomly so, there is no need to calculate that point again.
                {
                    continue;
                }
                // There is a multiplication with 10 because the drawing is too small
                else
                {
                    edges[j].X = Convert.ToInt32(center.x_ + length * 10 * Math.Cos(j * angle));
                    edges[j].Y = Convert.ToInt32(center.y_ + length * 10 * Math.Sin(j * angle));
                }
            }
        }

        // It's a funciton which rotate the polygon by a given angle
        public void rotatePolygon(int rotationAngle)
        {
            float angle = (float)(rotationAngle * Math.PI / 180.0); // It's a convertion of the angle to radian

            // It's a loop which calculate new coordinates of edges after rotation
            for (int i = 0; i < numberOfEdges_; i++)
            {
                float newX = (float)((edges[i].X - center.x_) * Math.Cos(angle) - (edges[i].Y - center.y_) * Math.Sin(angle) + center.x_);
                float newY = (float)((edges[i].X - center.x_) * Math.Sin(angle) + (edges[i].Y - center.y_) * Math.Cos(angle) + center.y_);
                edges[i] = new Point((int)newX, (int)newY);
            }
        }
    }
}
