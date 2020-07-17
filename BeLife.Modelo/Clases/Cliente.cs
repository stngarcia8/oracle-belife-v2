using System;

namespace BeLife.Modelo.Clases
{
    public class Cliente
    {

        // Propiedades.
        public String Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }
        public int IdSexo { get; set; }
        public int IdEstadoCivil { get; set; }


        // Constructor.
        private Cliente()
        { }


        // Metodo creador del objeto.
        public static Cliente Crear()
        {
            return new Cliente();
        }




    }
}
