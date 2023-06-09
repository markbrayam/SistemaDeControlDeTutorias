using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesSistemaDeControlDeTutorias.Modelo
{

    public class RespuestaConsulta<T>
    {
        public ResultadoConsulta ResultadoConsulta { get; set; }
        public T Respuesta { get; set; }
        public string MensajeExcepcion { get; set; }
    }
}