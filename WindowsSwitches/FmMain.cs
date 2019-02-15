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
            if ((int)dtpTime.Value.TimeOfDay.TotalMinutes >= (int)DateTime.Now.TimeOfDay.TotalMinutes)
                nudLeftTime.Value = (int)dtpTime.Value.TimeOfDay.TotalMinutes - (int)DateTime.Now.TimeOfDay.TotalMinutes;
            else
                nudLeftTime.Value = 1440 + ((int)dtpTime.Value.TimeOfDay.TotalMinutes - (int)DateTime.Now.TimeOfDay.TotalMinutes);
            nudLeftTime.ValueChanged += nudLeftTime_ValueChanged;
        }

        private void UstawGodzineWOparciuOCzas()
        {
            dtpTime.ValueChanged -= dtpTime_ValueChanged;
            dtpTime.Value = new DateTime(new DateTime(1753, 01, 01).Ticks + (DateTime.Now.TimeOfDay + new TimeSpan(0, (int)nudLeftTime.Value, 0)).Ticks);
            dtpTime.ValueChanged += dtpTime_ValueChanged;
        }

        private void UstawDostepnoscKontrolek()
        {
            btStart.Enabled = !uruchomionoWylaczanie;
            btStop.Enabled = uruchomionoWylaczanie;
            dtpTime.Enabled = !uruchomionoWylaczanie;
            nudLeftTime.Enabled = !uruchomionoWylaczanie;
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
    }
}
