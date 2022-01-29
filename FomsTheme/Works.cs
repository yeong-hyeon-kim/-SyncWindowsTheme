using Microsoft.Win32;
using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace FomsTheme
{
    public partial class Works : Form
    {
        private RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);

        public Works()
        {
            InitializeComponent();
            SetTheme();
        }

        private void Works_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1500;
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Check Registry Value
            SetTheme();
        }

        private void SetTheme()
        {
            if (RegKey.GetValue("AppsUseLightTheme").ToString() == "0")
            {
                BackColor = ColorTranslator.FromHtml("#323232");
                ForeColor = ColorTranslator.FromHtml("#ffffff");
            }
            else
            {
                BackColor = ColorTranslator.FromHtml("#ffffff");
                ForeColor = ColorTranslator.FromHtml("#323232");
            }
        }
    }
}
