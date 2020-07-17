using System.Data;

namespace BeLife.Datos.ConsultarDatos
{
    public interface IConsultarDatosEscalar
    {

        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro);
        object ObtenerResultadosDeConsulta();
    }

}
