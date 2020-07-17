using System.Data;
using BeLife.Datos.Persistencia;

namespace BeLife.Datos.ConsultarDatos
{
    public class EjecutarConsultas : IEjecutarConsultas
    {

        readonly IConectarOracle coneccion;
        readonly IConsultasDeAccion consulta;


        //Constructor.
        private EjecutarConsultas(string cadenaDeConsulta)
        {
            coneccion = ConectarOracle.crear();
            consulta = coneccion.CrearConsultasDeAccion(cadenaDeConsulta);
        }


        //Metodo de creacion de objeto.
        public static EjecutarConsultas Crear(string cadenaDeConsulta)
        {
            return new EjecutarConsultas(cadenaDeConsulta);
        }


        public void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro)
        {
            consulta.AgregarParametro(nombreParametro, valorParametro, tipoParametro);
        }


        public int Ejecutar()
        {
            int filasAfectadas = consulta.EjecutarAccion();
            return filasAfectadas;
        }


        public void CerrarConsulta()
        {
            coneccion.Commit();
            coneccion.cerrarConeccion();
        }


    }
}
