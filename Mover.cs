using System.Numerics;
using System.Data.Common;
using System;
using System.Drawing;

namespace GraphicsProgrammingTask4_.Net_Framework_
{
    public class Mover
    {
        static Random rnd = new Random();
        static Random startRandLocation = new Random();
        Vector2 location;
        Vector2 velocity;
        int formWidth, formHeight;

        public Mover(int width, int height)
        {
            formWidth = width;
            formHeight = height;
            location = new Vector2(startRandLocation.Next(width),startRandLocation.Next(height)); //locates it in the middle of the screen
            velocity = new Vector2(3, 2);  //ratio of horizontal to verticle movement
        }

        public void Update()
        {
            if (location.X < 0 || location.X > formWidth - 140)
            {
                velocity.X = velocity.X * -1;
            }
            if (location.Y < 0 || location.Y > formHeight - 140)
            {
                velocity.Y = velocity.Y * -1;
            }
            location = Vector2.Add(location, velocity);
        }

        public void Display(Graphics e)
        {
            e.FillEllipse(Brushes.BlueViolet, location.X, location.Y, 100, 100);
        }


    }

}