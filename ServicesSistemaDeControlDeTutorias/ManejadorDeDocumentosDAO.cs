using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using ServicesSistemaDeControlDeTutorias.Modelo;

namespace DataAccess
{
    public static class ManejadorDeDocumentosDAO
    {
        private const int INDICE_COLUMNA_MATRICULA = 0;
        private const int INDICE_COLUMNA_NOMBRE_COMPLETO = 1;
        private const int INDICE_COLUMNA_CORREO_INSTITUCIONAL = 2;
        private const int INDICE_COLUMNA_CORREO_PERSONAL = 3;
        private const int INDICE_FILA_NOMBRES_COLUMNAS = 0;
        public static List<Estudiante> ExtraerEstudiantesDesdeDocumentoExcel(string rutaDocumento)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            Workbook libroDeTrabajo = new Workbook(rutaDocumento);
            WorksheetCollection coleccionDeHojas = libroDeTrabajo.Worksheets;
            int numeroDeHojas = coleccionDeHojas.Count();
            for (int indiceHojaActual = 0; indiceHojaActual < numeroDeHojas; indiceHojaActual++)
            {
                Worksheet hojaActual = coleccionDeHojas[indiceHojaActual];
                int filaMaxima = hojaActual.Cells.MaxDataRow;
                for (int indiceFilaActual = INDICE_FILA_NOMBRES_COLUMNAS + 1; indiceFilaActual < filaMaxima; indiceFilaActual++)
                {
                    string matricula = hojaActual.Cells[indiceFilaActual, INDICE_COLUMNA_MATRICULA].Value.ToString();
                    string nombreCompleto = hojaActual.Cells[indiceFilaActual, INDICE_COLUMNA_NOMBRE_COMPLETO].Value.ToString();
                    string correoInstitucional = hojaActual.Cells[indiceFilaActual, INDICE_COLUMNA_CORREO_INSTITUCIONAL].Value.ToString();
                    string correoPersonal = hojaActual.Cells[indiceFilaActual, INDICE_COLUMNA_CORREO_PERSONAL].Value.ToString();

                    string[] partesDeNombreCompleto = nombreCompleto.Split(' ');
                    string[] apellido = partesDeNombreCompleto[0].Split('-');

                    string nombres = partesDeNombreCompleto[1];
                    string apellidoPaterno = apellido[0];
                    string apellidoMaterno = apellido[1];

                    Estudiante estudianteImportado = new Estudiante();
                    if (!string.IsNullOrEmpty(matricula) &&
                         !string.IsNullOrEmpty(nombres) &&
                         !string.IsNullOrEmpty(correoInstitucional)
                        )
                    {
                        estudianteImportado.Matricula = matricula;
                        estudianteImportado.Nombres = nombres;
                        estudianteImportado.ApellidoPaterno = apellidoPaterno;
                        estudianteImportado.ApellidoMaterno = apellidoMaterno;
                        estudianteImportado.CorreoInstitucional = correoInstitucional;
                        estudianteImportado.CorreoPersonal = correoPersonal;

                        estudiantes.Add(estudianteImportado);
                    }
                }
            }
            return estudiantes;
        }
    }
}
