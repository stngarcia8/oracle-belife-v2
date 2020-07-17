    using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Text;

namespace BeLife.Modelo.Clases
{
    public class Prima
    {

        // Miembros privados.
        private readonly double valor;
        private readonly DateTime fecha;
        private readonly string sexo;
        private readonly string estadoCivil;


        // Propiedades.
        public double Recargo { get; set; }
        public double ValorTotal { get; set; }
        public string DetalleValores { get; set; }


        // Constructor.
        private Prima(double valor, DateTime fecha, string sexo, string estadoCivil)
        {
            this.valor = valor;
            this.fecha = fecha;
            this.sexo = sexo.ToString().ToLower().Trim();
            this.estadoCivil = estadoCivil.ToString().ToLower().Trim();
            this.CalcularSeguro();
        }


        // Metodo para crear el objeto.
        public static Prima Crear(double valor, DateTime fecha, string sexo, string estadoCivil)
        {
            return new Prima(valor, fecha, sexo, estadoCivil);
        }


        // Calcular total del seguro.
        private void CalcularSeguro()
        {
            double recargoEdad = this.calculaRecargoEdad();
            double recargoSexo = this.calculaRecargoSexo();
            double recargoEstadoCivil = this.calculaRecargoEstadoCivil();
            this.Recargo = (recargoEdad + recargoSexo + recargoEstadoCivil);
            this.ValorTotal = (this.valor + this.Recargo);
        }


        // Calcular recargo por fecha de nacimiento.
        private double calculaRecargoEdad()
        {
            int year = DateTime.Now.Year - this.fecha.Year;
            if (year >= 18 && year <= 25) return 3.6;
            if (year >= 26 && year <= 45) return 2.4;
            if (year > 45) return 6;
            return 0;
        }


        // Calcular el recargo por sexo.
        private double calculaRecargoSexo()
        {
            if (string.IsNullOrEmpty(this.sexo)) return 0;
            return (this.sexo.Equals("hombre") ? 2.4 : 1.2);
        }


        // Calcular recargo por estado civil.
        private double calculaRecargoEstadoCivil()
        {
            if (string.IsNullOrEmpty(this.estadoCivil)) return 0;
            if (this.estadoCivil.Equals("soltero")) return 4.8;
            if (this.estadoCivil.Equals("casado")) return 2.4;
            return 3.6;
        }


        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.Append(StringResources.TextoPrima_Recargo);
            myBuilder.Append(StringResources.TextoPrima_Edad + this.calculaRecargoEdad().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_Sexo + this.calculaRecargoSexo().ToString() + " UF |");
            myBuilder.Append(StringResources.TextoPrima_EstadoCivil + this.calculaRecargoEstadoCivil().ToString() + " UF");
            return myBuilder.ToString();
        }

    }
}
