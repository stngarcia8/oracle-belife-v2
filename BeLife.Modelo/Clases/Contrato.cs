using System;

namespace BeLife.Modelo.Clases
{
    public class Contrato
    {

        // Propiedades.
        public string NumeroContrato { get; set; }
        public DateTime FechaInicioContrato { get; set; }
        public DateTime FechaTerminoContrato { get; set; }
        public string RutCliente { get; set; }
        public string IdPlan { get; set; }
        public DateTime FechaInicioDeVigencia { get; set; }
        public DateTime FechaTerminoDeVigencia { get; set; }
        public int VigenciaContrato { get; set; }
        public int DeclaracionDeSalud { get; set; }
        public double PrimaAnual { get; set; }
        public double PrimaMensual { get; set; }
        public string Observaciones { get; set; }


        // Constructor.
        private Contrato()
        {

        }


        // Metodo constructor del objeto.
        public static Contrato Crear()
        {
            return new Contrato();
        }






    }
}
