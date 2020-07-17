using System.Collections.Generic;
using System.Data;

namespace BeLife.Datos.Persistencia
{
    public interface IConsultasDeSeleccion
    {

        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoValorParametro);

        TResultado ConsultaSimple<TResultado>();

        IEnumerable<TResultado> ConsultaConDatos<TResultado>();

    }
}
