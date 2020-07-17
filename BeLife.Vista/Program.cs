using System;
using System.Windows.Forms;
using BeLife.Aplicacion.Idiomas;
using BeLife.Vista.MetroForms;

namespace BeLife.Vista
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var myAsignadorIdiomas = AsignarIdioma.Crear();
            myAsignadorIdiomas.Fijaridioma();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(myAsignadorIdiomas.NomenclaturaDeIdioma);
            Application.CurrentCulture = cultureInfo;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MetroBeLifeForm());
        }
    }
}
