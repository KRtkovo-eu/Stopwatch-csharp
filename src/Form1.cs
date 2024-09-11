using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch; // Instance stopek
        private Timer timer; // Timer pro aktualizaci GUI

        public Form1()
        {
            InitializeComponent();

            // Inicializace stopek
            stopwatch = new Stopwatch();

            // Inicializace timeru
            timer = new Timer();
            timer.Interval = 100; // Aktualizace GUI každých 100 ms
            timer.Tick += Timer_Tick;

            // Nastavíme výchozí hodnotu labelu
            lblTime.Text = "00:00:00.0";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                // Zastavíme stopky
                stopwatch.Stop();
                timer.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                // Spustíme stopky
                stopwatch.Start();
                timer.Start();
                btnStart.Text = "Stop";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Zastavení a resetování stopek
            stopwatch.Reset();
            timer.Stop();
            lblTime.Text = "00:00:00.0";
            btnStart.Text = "Start";
        }

        // Aktualizace labelu s časem
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Formátování času do hh:mm:ss.0
            TimeSpan ts = stopwatch.Elapsed;
            lblTime.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:0}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 100);
        }
    }
}
