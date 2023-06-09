using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ServicesSistemaDeControlDeTutorias.Modelo;

namespace ServicesSistemaDeControlDeTutorias.Modelo
{
    public class EstudianteDAO
    {
        // Agregar un nuevo estudiante a la base de datos   
        public static async Task<RespuestaConsulta<Estudiante>> AgregarEstudianteAsync(Estudiante estudiante)
        {
            RespuestaConsulta<Estudiante> respuestaConsulta = new RespuestaConsulta<Estudiante>();
            using (var context = getConnection())
            {
                try
                {

                    int idProgramaEducativo = 1;
                    Profesor profesor = await ProfesorDAO.BuscarProfesorPorNumeroDePersonalAsync("0000");
                    int idTutor = profesor.Id;
                    estudiante.ProgramaEducativo = context.ProgramaEducativo.Find(idProgramaEducativo);
                    estudiante.Tutor_Id = context.Profesor.Find(idTutor);
                    context.Estudiante.Add(estudiante);
                    await context.SaveChangesAsync();
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
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
                return respuestaConsulta;
            }
        }

        // Modificar un estudiante existente en la base de datos
        public static async Task ModificarEstudianteAsync(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string correoPersonal, string correoInstitucional)
        {
            using (var context = getConnection())
            {

                var estudiante = await context.Estudiante
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();
                estudiante.Nombres = nombre;
                estudiante.ApellidoPaterno = apellidoPaterno;
                estudiante.ApellidoMaterno = apellidoMaterno;
                estudiante.CorreoPersonal = correoPersonal;
                estudiante.CorreoInstitucional = correoInstitucional;
                await context.SaveChangesAsync();
            }
        }

        // Eliminar un estudiante existente de la base de datos
        public static async Task<RespuestaConsulta<Estudiante>> EliminarEstudianteAsync(string matricula)
        {
            RespuestaConsulta<Estudiante> respuestaConsulta = new RespuestaConsulta<Estudiante>();
            using (var context = getConnection())
            {

                try
                {
                    var estudiante = await context.Estudiante
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();

                    if (estudiante != null)
                    {
                        context.Estudiante.Remove(estudiante);
                        await context.SaveChangesAsync();
                    }
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
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
                return respuestaConsulta;
            }
        }

        // Buscar un estudiante por matrícula
        public static async Task<Estudiante> BuscarEstudiantePorMatriculaAsync(string matricula)
        {
            using (var context = getConnection())
            {
                Estudiante estudiante = null;
                estudiante = await context.Estudiante
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();
                return estudiante;
            }

        }

        // Buscar todos los estudiantes
        public static async Task<List<Estudiante>> BuscarTodosLosEstudiantesAsync()
        {
            using (var context = getConnection())
            {
                return await context.Estudiante.ToListAsync();
            }
        }

        // Buscar estudiantes por programa educativo
        public static async Task<List<Estudiante>> BuscarEstudiantesPorProgramaEducativoAsync(string programaEducativo)
        {
            using (var context = getConnection())
            {
                return await context.Estudiante.Where(e => e.ProgramaEducativo.Nombre == programaEducativo).ToListAsync();
            }
        }

        // Buscar estudiantes por tutor
        public static async Task<List<Estudiante>> BuscarEstudiantesPorTutorAsync(Profesor tutor)
        {
            using (var context = getConnection())
            {
                return await context.Estudiante.Where(e => e. == tutor.Id).ToListAsync();
            }
        }

        // Modificar un tutor de un estudiante existente en la base de datos
        public static async Task ModificarTutorEstudianteAsync(string matricula, string numero)
        {
            using (var context = getConnection())
            {

                var estudiante = await context.Estudiante
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();
                Profesor profesor = await ProfesorDAO.BuscarProfesorPorNumeroDePersonalAsync(numero);
                int idTutor = profesor.Id;
                estudiante.Tutor = context.Profesor.Find(idTutor);
                await context.SaveChangesAsync();
            }
        }

        public static DataClassesSistemaDeControlDeTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaDeControlDeTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDSCT"].ConnectionString);
        }
    }
}