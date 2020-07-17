using System;

namespace BeLife.Modelo.Dto
{
    public class DtoCliente
    {

        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
        public string EstadoCivil { get; set; }
        public int IdSexo { get; set; }
        public string Sexo { get; set; }

    }
}
