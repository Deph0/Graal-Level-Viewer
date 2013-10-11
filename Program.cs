using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace GraalLevelViewer
{
    class Program
    {
        static WindowMain windowmain;

        [STAThread]

        public static void Main()
        {
            Console.WriteLine("Graal Level Viewer, created by Emera");

            Application.EnableVisualStyles();

            windowmain = new WindowMain();
            windowmain.Show();
            windowmain.Setup();

            while (true)
            {
                Application.DoEvents();
                if (windowmain.IsDisposed) return;
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
