using System.Collections.Generic;
using System.Data;
using System.Linq;
using BeLife.Datos.Persistencia;

namespace BeLife.Datos.ConsultarDatos
{
    public class ConsultarDatos
    {

        readonly IConectarOracle coneccion;
        readonly IConsultasDeSeleccion consulta;


        //Constructor.
        private ConsultarDatos(string cadenaDeConsulta)
        {
            coneccion = ConectarOracle.crear();
            consulta = coneccion.CrearConsultasDeSeleccion(cadenaDeConsulta);
        }


        // Metodo de creacion.
        public static ConsultarDatos Crear(string cadenaDeConsulta)
        {
            return new ConsultarDatos(cadenaDeConsulta);
        }


        public void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro)
        {
            consulta.AgregarParametro(nombreParametro, valorParametro, tipoParametro);
        }


        public List<Entidad> ObtenerResultadosDeConsulta<Entidad>() where Entidad : class
        {
            try
            {
                List<Entidad> resultado = (from registros in consulta.ConsultaConDatos<Entidad>()
                                           select registros).ToList();
                coneccion.cerrarConeccion();
                return resultado;
            }
            catch
            {
                throw;
            }
        }

    }
}
