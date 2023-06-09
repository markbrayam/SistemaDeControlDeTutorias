using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesSistemaDeControlDeTutorias.Modelo
{
    public enum ResultadoConsulta
    {
        Exitosa,
        EntidadNoEncontrada,
        ErrorDeEscrituraLectura,
        ErrorConexion,
        OperacionInvalida,
        ErrorDesconocido
    }
}