using System.Data;

namespace BeLife.Datos.ConsultarDatos
{
    public interface IEjecutarConsultas
    {


        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro);
        int Ejecutar();
        void CerrarConsulta();
    }

}
