using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsSwitches
{
    public partial class FmMain : Form
    {
        private bool uruchomionoWylaczanie = false;

        public FmMain()
        {
            InitializeComponent();
            UstawDostepnoscKontrolek();
            //dtpTime.Value = DateTime.Now;
            nudLeftTime.Value = 45;
            timer.Start();          
        }

        private void WylaczKomputer()
        {
            //MessageBox.Show("Wyłączono komputer");
            Process.Start("shutdown", "/s /t 0");
        }

        private void UstawCzasWOparciuOGodzine()
        {
            nudLeftTime.ValueChanged -= nudLeftTime_ValueChanged;
            nudLeftTime.Value = (int)GetDifferencesBetweenHoures(DateTime.Now.TimeOfDay,dtpTime.Value.TimeOfDay).TotalMinutes + 1;
            nudLeftTime.ValueChanged += nudLeftTime_ValueChanged;
        }

        private void UstawGodzineWOparciuOCzas()
        {
            dtpTime.ValueChanged -= dtpTime_ValueChanged;
            dtpTime.Value = DateTime.Now.AddMinutes((int)nudLeftTime.Value);
            dtpTime.ValueChanged += dtpTime_ValueChanged;
        }

        private void UstawDostepnoscKontrolek()
        {
            btStart.Enabled = !uruchomionoWylaczanie;
            btStop.Enabled = uruchomionoWylaczanie;
            dtpTime.Enabled = !uruchomionoWylaczanie;
            nudLeftTime.Enabled = !uruchomionoWylaczanie;
        }

        private TimeSpan GetDifferencesBetweenHoures(TimeSpan time1, TimeSpan time2)
        {
            DateTime date1 = DateTime.MinValue.Add(time1);
            DateTime date2 = DateTime.MinValue.Add(time2);

            if (time1 > time2)
                date2 = date2.AddDays(1);

            TimeSpan difference = (date2 - date1);
            difference = new TimeSpan(0, difference.Hours, difference.Minutes, difference.Seconds, difference.Milliseconds);
            return difference;
        }

        private void btStart_Click(object sender, EventArgs e)
        {           
            uruchomionoWylaczanie = true;
            UstawDostepnoscKontrolek();
        }

        private void btStop_Click(object sender, EventArgs e)
        {           
            uruchomionoWylaczanie = false;
            UstawDostepnoscKontrolek();
        }

        private void teTime_EditValueChanged(object sender, EventArgs e)
        {
            UstawCzasWOparciuOGodzine();
        }

        private void teLeftTime_EditValueChanged(object sender, EventArgs e)
        {
            UstawGodzineWOparciuOCzas();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (uruchomionoWylaczanie)
            {
                UstawCzasWOparciuOGodzine();
                if ((int)DateTime.Now.TimeOfDay.TotalMinutes == (int)dtpTime.Value.TimeOfDay.TotalMinutes)
                {
                    uruchomionoWylaczanie = false;
                    WylaczKomputer();
                }
            }
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            UstawCzasWOparciuOGodzine();
        }

        private void nudLeftTime_ValueChanged(object sender, EventArgs e)
        {
            UstawGodzineWOparciuOCzas();
        }

        private void FmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = true;
                notifyIcon.Text = "Windows Switches. " + (uruchomionoWylaczanie ? "Zaplanowano wyłączenie komputera o " + dtpTime.Text : "Nie zaplanowano wyłączenia komputera");
                this.Hide();
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
