using System.Data;
using BeLife.Datos.Persistencia;

namespace BeLife.Datos.ConsultarDatos
{
    public class ConsultarDatosEscalar
    {

        readonly IConectarOracle coneccion;
        readonly IConsultasDeSeleccion consulta;


        public ConsultarDatosEscalar(string cadenaDeConsulta)
        {
            coneccion = ConectarOracle.crear();
            consulta = coneccion.CrearConsultasDeSeleccion(cadenaDeConsulta);
        }


        public void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro)
        {
            consulta.AgregarParametro(nombreParametro, valorParametro, tipoParametro);
        }


        public object ObtenerResultadosDeConsulta()
        {
            object resultado = consulta.ConsultaSimple<object>();
            coneccion.cerrarConeccion();
            return resultado;
        }


    }
}
