using System.Data;

namespace BeLife.Datos.Persistencia
{
    public interface IConsultasDeAccion
    {

        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoValorParametro);

        int EjecutarAccion();

    }
}
