using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using EntityException = System.Data.EntityException;
using ServicesSistemaDeControlDeTutorias.Modelo;

namespace ServicesSistemaDeControlDeTutorias.Modelo
{
    public class LoginDAO
    {
        public static async Task<RespuestaConsulta<Administrador>> BuscarAministradorPorUsuarioAsync(string _usuario)
        {
            RespuestaConsulta<Administrador> respuestaConsulta = new RespuestaConsulta<Administrador>();
            Administrador administrador = null;
            using (var context = getConnection())
            {
                try
                {
                    administrador = await context.Administrador
                        .Where(r => r.Usuario.Equals(_usuario))
                        .FirstOrDefaultAsync();
                    if (administrador == null)
                    {
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.EntidadNoEncontrada;
                    }
                    else
                    {
                        respuestaConsulta.Respuesta = administrador;
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
                    }
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
                    // Error al actualizar la entidad en la base de datos
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.ErrorDeEscrituraLectura;
                }
                catch (EntityException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.ErrorConexion;
                }
                catch (Exception ex)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.ErrorDesconocido;
                    respuestaConsulta.MensajeExcepcion = ex.Message;
                }
            }
            return respuestaConsulta;
        }

        public static DataClassesSistemaDeControlDeTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaDeControlDeTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDSCT"].ConnectionString);
        }
    }
}
