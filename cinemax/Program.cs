using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinemax
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login login = new Login();
            Application.Run(login);
            if (login.loginStatus)
            {
                Cinemax formularioPrincipal = new Cinemax() { clave_emp = login.clave_emp };
                Application.Run(formularioPrincipal);
            }
        }
    }
}
