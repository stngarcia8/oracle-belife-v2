using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Oracle.DataAccess.Client;

namespace BeLife.Datos.Persistencia
{
    public class ConsultasDeSeleccion : IConsultasDeSeleccion
    {

        OracleCommand Comando { get; set; }

        public ConsultasDeSeleccion(OracleCommand comando)
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


        //  Metodo que ejecuta una consulta y devuelbe el resultado de esta.
        public TResultado ConsultaSimple<TResultado>()
        {
            return (TResultado)Convert.ChangeType(Comando.ExecuteScalar(), typeof(TResultado));
        }


        //  Metodo que ejecuta una consulta y devuelbe los registros resultantes.
        public IEnumerable<TResultado> ConsultaConDatos<TResultado>()
        {
            Type resultType = typeof(TResultado);
            IList<TResultado> resultado = new List<TResultado>();
            if (resultType.FullName.StartsWith("System."))
            {
                using (var reader = Comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var valor = reader.GetValue(0);
                        resultado.Add((TResultado)(valor != DBNull.Value ? valor : null));
                    }
                }
            }
            else
            {
                var propiedades = typeof(TResultado).GetProperties();
                using (var reader = Comando.ExecuteReader())
                {
                    List<string> columnas = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                    while (reader.Read())
                    {
                        var entidad = Activator.CreateInstance<TResultado>();
                        foreach (var propiedad in propiedades)
                        {
                            if (columnas.Contains(propiedad.Name.ToUpper()))
                            {
                                var valor = reader[propiedad.Name];
                                propiedad.SetValue(entidad, valor != DBNull.Value ? Convert.ChangeType(valor, propiedad.PropertyType) : null, null);
                            }
                        }
                        resultado.Add(entidad);
                    }
                }
            }
            return resultado;
        }









    }
}
