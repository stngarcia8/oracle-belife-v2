namespace BeLife.Modelo.Dto
{
    public class DtoContratoCliente
    {

        public string Numero { get; set; }
        public string Inicio_contrato { get; set; }
        public string Termino_contrato { get; set; }
        public string IdPlan { get; set; }
        public string Nombre_plan { get; set; }
        public string Inicio_vigencia { get; set; }
        public string Termino_vigencia { get; set; }
        public string Vigente { get; set; }
        public string Declaracion_salud { get; set; }
        public double Prima_base { get; set; }
        public double Prima_mensual { get; set; }
        public double Prima_Anual { get; set; }

    }
}
