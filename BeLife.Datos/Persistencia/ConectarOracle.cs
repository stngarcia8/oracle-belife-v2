using System;
using BeLife.Aplicacion.Configuracion;
using Oracle.DataAccess.Client;

namespace BeLife.Datos.Persistencia
{
    public class ConectarOracle : IConectarOracle, IDisposable
    {

        private bool disposed = false;
        OracleConnection coneccion;
        OracleTransaction transaccion;
        readonly string cadenaDeConeccion;


        private ConectarOracle()
        {
            cadenaDeConeccion = generarCadenaDeConeccion();
        }


        // Metodo de creacion del objeto.
        public static ConectarOracle crear()
        {
            return new ConectarOracle();
        }


        private string generarCadenaDeConeccion()
        {
            Configurador myConfigurador = Configurador.Crear();
            return string.Format("Data Source={0};User Id={1};Password={2};", myConfigurador.Bdd.DataSource, myConfigurador.Bdd.User, myConfigurador.Bdd.Pwd);
        }


        //  Metodo que obtiene el objeto de conección.
        public OracleConnection ObtenerConeccion()
        {
            if (coneccion == null)
            {
                InicializarObjetos();
            }
            return coneccion;
        }


        //  Metodo que obtiene el objeto de transaccion.
        public OracleTransaction ObtenerTransaccion()
        {
            if (transaccion == null)
            {
                InicializarObjetos();
            }
            return transaccion;
        }


        //  Metodo que inicializa los objetos de conección.
        private void InicializarObjetos()
        {
            try
            {
                coneccion = new OracleConnection(cadenaDeConeccion);
                coneccion.Open();
                transaccion = coneccion.BeginTransaction();
            }
            catch
            {
                throw;
            }
        }



        // Metodo para hacer commit a la bdd.
        public void Commit()
        {
            if (transaccion != null)
            {
                transaccion.Commit();
            }
        }


        // Metodo para hacer rollback a la bdd.
        public void RollBack()
        {
            if (transaccion != null)
            {
                transaccion.Rollback();
            }
        }


        // metodo para realizar consultas de seleccion a la bdd.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Revisar consultas SQL para comprobar si tienen vulnerabilidades de seguridad")]
        public IConsultasDeSeleccion CrearConsultasDeSeleccion(string consultaSelect)
        {
            var command = ObtenerConeccion().CreateCommand();
            command.CommandText = string.Format("{0}", consultaSelect);
            command.Transaction = transaccion;
            return new ConsultasDeSeleccion(command);
        }


        // Metodo para crear consultas de accion a la bdd (insert, update, delete, etc)
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Revisar consultas SQL para comprobar si tienen vulnerabilidades de seguridad")]
        public IConsultasDeAccion CrearConsultasDeAccion(string consultaAccion)
        {
            var command = ObtenerConeccion().CreateCommand();
            command.CommandText = string.Format("{0}", consultaAccion);
            command.Transaction = transaccion;
            return new ConsultasDeAccion(command);
        }


        // Metodo para cerrar los objetos de la bdd.
        public void cerrarConeccion()
        {
            if (transaccion != null)
            {
                transaccion.Dispose();
                transaccion = null;
            }
            if (coneccion != null)
            {
                coneccion.Dispose();
                coneccion = null;
            }
        }


        // Destructor.
        #region "Destructor."

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                if (transaccion != null)
                {
                    transaccion.Dispose();
                    transaccion = null;
                }
                if (coneccion != null)
                {
                    coneccion.Dispose();
                    coneccion = null;
                }
            }
            disposed = true;
        }

        ~ConectarOracle()
        {
            Dispose(false);
        }

        #endregion









    }
}
