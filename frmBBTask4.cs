using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgrammingTask4_.Net_Framework_
{
    public partial class frmBBTask4 : Form
    {
        Mover mover; //sigle mover //declared outside for global access
        List<Mover> movers = new List<Mover>(); // multiple movers


        public frmBBTask4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            Timer timer1 = new Timer();
            timer1.Interval = 10;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            this.Paint += Form1_Paint;

            //this is a very clever way to do it, list dynamically grows with demand for movers
            for (int i = 0; i < 5; i++) // change i number for more/less movers
            {
                mover = new Mover(this.Width, this.Height);
                movers.Add(mover);

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //mover.Update();
            //mover.Display(e.Graphics);
            foreach (var item in movers)
            {
                item.Update();
                item.Display(e.Graphics);
            }

        }
    }
}