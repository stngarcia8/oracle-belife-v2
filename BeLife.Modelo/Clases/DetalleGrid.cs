namespace BeLife.Modelo.Clases
{
    public class DetalleGrid
    {

        // propiedades.
        public string Campo { get; set; }
        public string Valor { get; set; }



        // Constructor.
        private DetalleGrid(string campo, string valor)
        {
            this.Campo = campo;
            this.Valor = valor;
        }


        // Metodo creador del objeto.
        public static DetalleGrid Crear(string campo, string valor)
        {
            return new DetalleGrid(campo, valor);
        }


    }
}
