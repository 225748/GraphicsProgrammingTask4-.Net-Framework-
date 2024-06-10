using System.Numerics;
using System.Data.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsProgrammingTask4_.Net_Framework_
{
    public class Mover
    {
        static Random rnd = new Random();
        static Random startRandLocation = new Random();
        Vector2 location;
        Vector2 velocity;
        int formWidth, formHeight;
        Vector2 acceleration;
        Vector2 mouse = new Vector2();
        float topSpeed;
        Form frm;

        public Mover(int width, int height, Form theForm)
        {
            formWidth = width;
            formHeight = height;
            location = new Vector2(startRandLocation.Next(width), startRandLocation.Next(height)); //locates it in the middle of the screen
            velocity = new Vector2(0, 0);  //ratio of horizontal to verticle movement
            acceleration = new Vector2((float)-0.001, (float)0.001); //x is -ve, y is +ve    float is here to ensure the number is not interpreted as a double
            frm = theForm;
            topSpeed = 7; // used to cap speed or else acceleration will continue indefinitly
        }

        float Mag(Vector2 theVector) // returns length of a given vector
        {
            return (float)Math.Sqrt(theVector.X * theVector.X + theVector.Y * theVector.Y); // square root of x^" + y^2 - using pythag to find mag of vector
        }

        public Vector2 Limit(float theLimit, Vector2 theVector)
        {
            if (Mag(theVector) > theLimit)
            {
                // this is off stack overflow the 10 is the limit
                theVector.X = theVector.X * theLimit / Mag(theVector);
                theVector.Y = theVector.Y * theLimit / Mag(theVector);
            }
            return theVector;
        }

        public void Update()
        {
            //deleted 'negative velocity code' that bounces it from the walls
            
            Point cp = frm.PointToClient(Cursor.Position); //gets x and y of mouse
            mouse.X = cp.X;
            mouse.Y = cp.Y;
            Vector2 direction = Vector2.Subtract(mouse, location); //provides a vector for balls to move to the mouse
            //direction = Vector2.Normalize(direction); //softens the acceleration a bit
            direction = Vector2.Multiply(0.2f,direction); // the number is affecting the acceleration and sort of by extension how strong the attraction is
            // f signifies its a floating point num
            acceleration = direction;
            velocity = Vector2.Add(velocity, acceleration);
            velocity = Limit(topSpeed, velocity);
            location = Vector2.Add(location, velocity);
        }

        public void Display(Graphics e)
        {
            e.FillEllipse(Brushes.BlueViolet, location.X, location.Y, 20, 20);
        }


    }

}