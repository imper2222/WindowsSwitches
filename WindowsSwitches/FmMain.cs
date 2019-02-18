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
        private bool uruchomionoZadanie = false;

        public FmMain()
        {
            InitializeComponent();
            UstawDostepnoscKontrolek();
            //dtpTime.Value = DateTime.Now;
            nudLeftTime.Value = 45;
            cbZadanie.Text = "zamknij";
            timer.Start();          
        }

        private void UruchomKomende()
        {            
            string parametrZadania;
            string zadanie = cbZadanie.Text;
            switch (zadanie)
            {
                case "zamknij": parametrZadania = "/s"; break;
                case "uruchom ponownie": parametrZadania = "/r"; break;
                case "wyloguj": parametrZadania = "/l"; break;
                case "uśpij": parametrZadania = "/h"; break;
                default: parametrZadania = "/s"; break;
            }

            string komenda = "shutdown";
            string parametry = String.Format("{0} /t 0", parametrZadania);
            //MessageBox.Show(komenda + " " + parametry);
            Process.Start(komenda, parametry);
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
            btStart.Enabled = !uruchomionoZadanie;
            btStop.Enabled = uruchomionoZadanie;
            dtpTime.Enabled = !uruchomionoZadanie;
            nudLeftTime.Enabled = !uruchomionoZadanie;
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
            uruchomionoZadanie = true;
            UstawDostepnoscKontrolek();
        }

        private void btStop_Click(object sender, EventArgs e)
        {           
            uruchomionoZadanie = false;
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
            if (uruchomionoZadanie)
            {
                UstawCzasWOparciuOGodzine();
                if ((int)DateTime.Now.TimeOfDay.TotalMinutes == (int)dtpTime.Value.TimeOfDay.TotalMinutes)
                {
                    uruchomionoZadanie = false;
                    UruchomKomende();
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
                notifyIcon.Text = "Windows Switches. " + (uruchomionoZadanie ? "Zaplanowano wyłączenie komputera o " + dtpTime.Text : "Nie zaplanowano wyłączenia komputera");
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
