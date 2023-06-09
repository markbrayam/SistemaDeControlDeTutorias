using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesSistemaDeControlDeTutorias.Modelo;

namespace ServicesSistemaDeControlDeTutorias.Modelo
{
    public class JefesCarrreraDAO
    {
        public static async Task<RespuestaConsulta<Profesor>> ModificarJefeCarreraAsync(Profesor _profesor)
        {
            RespuestaConsulta<Profesor> respuestaConsulta = new RespuestaConsulta<Profesor>();
            Profesor profesor = null;
            using (var context = getConnection())
            {
                try
                {
                    Profesor result = context.Profesor.SingleOrDefault(b => b.Id == profesor.Id && b.EsJefeCarrera == true);
                    if (result != null)
                    {
                        ///  Tambien se puuede hacer con el siguiente codigo
                        ///  result.SomeValue = "Some new value";
                        ///  db.SaveChanges();
                        context.Profesor.Attach(_profesor);
                        context.Entry(_profesor).State = EntityState.Modified;
                        context.SaveChanges();

                        respuestaConsulta.Respuesta = _profesor;
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

        public static async Task<RespuestaConsulta<Profesor>> AgregarJefeCarreraAsync(Profesor _profesor)
        {
            RespuestaConsulta<Profesor> respuestaConsulta = new RespuestaConsulta<Profesor>();
            using (var context = getConnection())
            {
                try
                {
                    var result = context.Profesor.SingleOrDefault(p => p.NumeroDePersonal == _profesor.NumeroDePersonal);
                    if (result != null)
                    {
                        result.EsJefeCarrera = true;
                        context.SaveChanges();
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

        public static async Task<RespuestaConsulta<Profesor>> EliminarJefeCarreraAsync(Profesor _profesor)
        {
            RespuestaConsulta<Profesor> respuestaConsulta = new RespuestaConsulta<Profesor>();
            using (var context = getConnection())
            {
                try
                {
                    var result = context.Profesor.SingleOrDefault(p => p.NumeroDePersonal == _profesor.NumeroDePersonal);
                    if (result != null)
                    {
                        result.EsJefeCarrera = false;
                        context.SaveChanges();
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

        public static async Task<RespuestaConsulta<List<Profesor>>> RecuperarJefesDeCarreraAsync()
        {
            RespuestaConsulta<List<Profesor>> respuestaConsulta = new RespuestaConsulta<List<Profesor>>();
            using (var context = getConnection())
            {
                try
                {
                    List<Profesor> profesores = new List<Profesor>();
                    profesores = await context.Profesor.
                        Where(r => r.EsJefeCarrera.Equals(true)).ToListAsync<Profesor>();
                    respuestaConsulta.Respuesta = profesores;
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
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

        private Boolean ChecarJefeRegistradoPorId(String idJefeCarrera)
        {
            bool estaRegistrado = false;
            Profesor profesor = null;
            using (var context = getConnection())
            {
                profesor = context.Profesor
                    .Find(idJefeCarrera);
            }
            if (profesor != null)
            {
                if ((bool)profesor.EsJefeCarrera)
                {
                    estaRegistrado = true;
                }
            }
            return estaRegistrado;
        }

        public static DataClassesSistemaDeControlDeTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaDeControlDeTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDSCT"].ConnectionString);
        }
    }
}
