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
    // This class represents an RGB color (Red, Green, Blue)
    internal class ColorRGB
    {
        private Random random = new Random(); // Used to generate random numbers
        private int red;
        private int green;
        private int blue;

        // Property to get or set the red value
        public int red_
        {
            get { return red; }
            set { red = value; }
        }

        // Property to get or set the green value
        public int green_
        {
            get { return green; }
            set { green = value; }
        }

        // Property to get or set the blue value
        public int blue_
        {
            get { return blue; }
            set { blue = value; }
        }

        // Default constructor - sets color to black (0, 0, 0)
        public ColorRGB()
        {
            red = 0;
            green = 0;
            blue = 0;
        }

        // Constructor that generates random color values
        public ColorRGB(int red_, int green_, int blue_)
        {
            red_ = random.Next(0, 254);
            green_ = random.Next(0, 254);
            blue_ = random.Next(0, 254);
            red = red_;
            green = green_;
            blue = blue_;
        }

        // This method generates specialized color with choosen values.
        public Color ToColor()
        {
            return Color.FromArgb(red, green, blue);
        }
    }
}
