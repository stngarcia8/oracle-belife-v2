using Oracle.DataAccess.Client;

namespace BeLife.Datos.Persistencia
{
    public interface IConectarOracle
    {


        OracleConnection ObtenerConeccion();

        OracleTransaction ObtenerTransaccion();

        void Commit();

        void RollBack();

        IConsultasDeSeleccion CrearConsultasDeSeleccion(string consultaSelect);

        IConsultasDeAccion CrearConsultasDeAccion(string consultaAccion);

        void cerrarConeccion();


    }
}
