using System;
using System.IO;
using System.ServiceProcess;


namespace WindowsServiceExample
{

    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DosyaYaz("Service is running. " + DateTime.Now);
        }

        protected override void OnStop()
        {
            DosyaYaz("Service has stopped. " + DateTime.Now);
        }

        public void DosyaYaz(string txt)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string text = AppDomain.CurrentDomain.BaseDirectory + "/Logs/services.txt";
            if (!File.Exists(text))
            {
                using (StreamWriter sw = File.CreateText(text))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(text))
                {
                    sw.WriteLine(text);
                }
            }

        }
    }
}
