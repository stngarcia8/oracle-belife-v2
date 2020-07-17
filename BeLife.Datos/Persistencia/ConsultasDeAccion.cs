using System.Data;
using Oracle.DataAccess.Client;

namespace BeLife.Datos.Persistencia
{
    public class ConsultasDeAccion : IConsultasDeAccion
    {

        OracleCommand Comando { get; set; }


        public ConsultasDeAccion(OracleCommand comando)
        {
            Comando = comando;
        }


        //  Metodo que agrega un parametro al comando de consulta.
        public void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoValorParametro)
        {
            OracleParameter parametro = new OracleParameter();
            parametro.ParameterName = nombreParametro;
            parametro.Value = valorParametro;
            parametro.DbType = tipoValorParametro;
            Comando.Parameters.Add(parametro);
        }


        //  Metodo que ejecuta la consulta de acción.
        public int EjecutarAccion()
        {
            int registrosAfectados = Comando.ExecuteNonQuery();
            return registrosAfectados;
        }


    }
}
