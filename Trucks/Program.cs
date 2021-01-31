using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Trucks
{
    static class Program
    {


        public static volatile bool _shouldStop = false;
        
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (clsSetting.VerificaLicenza())
            {
                
                //Thread newThread = new Thread(InzializzaReport);
                //newThread.Start();
                
                Application.Run(new frmLogin());
                //Application.Run(new frmShowReport());
                //RequestStop();
                //newThread.Abort();
            }
        }

        static void RequestStop()
        {
            _shouldStop = true;
        }

        static void InzializzaReport()
        {
            Application.Run(new frmShowReport());

            while (!_shouldStop)
            {
                System.Threading.Thread.Sleep(1000);
            }            
        }
    }
}
