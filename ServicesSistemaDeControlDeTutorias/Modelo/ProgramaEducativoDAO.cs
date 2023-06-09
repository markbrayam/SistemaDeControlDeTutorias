using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ServicesSistemaDeControlDeTutorias.Modelo
{
    public class ProgramaEducativoDAO
    {

        public static async Task<RespuestaConsulta<ProgramaEducativo>> ModificarProgramaEducativoAsync(ProgramaEducativo _programaEducativo)
        {
            RespuestaConsulta<ProgramaEducativo> respuestaConsulta = new RespuestaConsulta<ProgramaEducativo>();
            ProgramaEducativo profesor = null;
            using (var context = getConnection())
            {
                try
                {
                    //Falta agregar un atributo de NRC
                    ProgramaEducativo result = context.ProgramaEducativo.SingleOrDefault(b => b.Nombre == _programaEducativo.Nombre);
                    if (result != null)
                    {
                        result.Profesor = _programaEducativo.Profesor;
                        //Agregar los demas atributos si es que faltan
                        context.SaveChanges();

                        respuestaConsulta.Respuesta = _programaEducativo;
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
                    }
                    else
                    {
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.EntidadNoEncontrada;
                    }
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<ProgramaEducativo>> AgregarProgramaEducativoAsync(ProgramaEducativo _programaEducativo)
        {
            RespuestaConsulta<ProgramaEducativo> respuestaConsulta = new RespuestaConsulta<ProgramaEducativo>();
            using (var context = getConnection())
            {
                try
                {
                    context.ProgramaEducativo.
                        //.Add(_programaEducativo);
                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<ProgramaEducativo>> EliminarProgramaEducativoAsync(ProgramaEducativo _programaEducativo)
        {
            RespuestaConsulta<ProgramaEducativo> respuestaConsulta = new RespuestaConsulta<ProgramaEducativo>();
            using (var context = getConnection())
            {
                try
                {
                    context.Entry(_programaEducativo).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<List<ExperienciaEducativa>>> RecuperarExperienciasEducativasPorLicenciaturaAsync(String _licenciatura)
        {
            RespuestaConsulta<List<ExperienciaEducativa>> respuestaConsulta = new RespuestaConsulta<List<ExperienciaEducativa>>();
            using (var context = getConnection())
            {
                try
                {
                    List<ExperienciaEducativa> programasEducativos = new List<ExperienciaEducativa>();
                    programasEducativos = await context.ExperienciaEducativa.
                        Where(p => p.ProgramaEducativo.Equals(_licenciatura)).ToListAsync();

                    respuestaConsulta.Respuesta = programasEducativos;
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<List<ProgramaEducativo>>> RecuperarLicenciaturasAsync()
        {
            RespuestaConsulta<List<ProgramaEducativo>> respuestaConsulta = new RespuestaConsulta<List<ProgramaEducativo>>();
            using (var context = getConnection())
            {
                try
                {
                    List<ProgramaEducativo> programasEducativos = new List<ProgramaEducativo>();
                    programasEducativos = await context.ProgramaEducativo.
                        Distinct().
                        ToListAsync();

                    respuestaConsulta.Respuesta = programasEducativos;
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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