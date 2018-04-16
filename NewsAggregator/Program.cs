using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsAggregator
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            try
            {
                LoginManager loginManager = LoginManager.Instance;
                loginManager.InitializeSession();
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. Authentication was not successful.\n Try to start app one more time.");
                Application.Exit();
            }
            
        }
    }
}
