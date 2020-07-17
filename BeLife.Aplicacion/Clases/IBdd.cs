namespace BeLife.Aplicacion.Clases
{
    public interface IBdd
    {

        string DataSource { get; set; }
        string User { get; set; }
        string Pwd { get; set; }

    }
}
