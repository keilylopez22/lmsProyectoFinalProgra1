﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProyectoFinal
{
    // Usuario.cs
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }
    }

    // Estudiante.cs
    public class Estudiante
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }

    // Profesor.cs
    public class Profesor
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaContratacion { get; set; }
    }

    // Curso.cs
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    // MaterialCurso.cs
    public class MaterialCurso
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
    }

    // AsignacionCursoProfesor.cs
    public class AsignacionCursoProfesor
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int ProfesorId { get; set; }

        public string Curso { get; set; }
        public string Profesor { get; set; }
    }

    // AsignacionEstudianteCurso.cs
    public class AsignacionEstudianteCurso
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int EstudianteId { get; set; }
        public string Curso { get; set; }
        public string Estudiante { get; set; }
    }

    // Actividad.cs
    public class Actividad
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }

        public string Curso { get; set; }
    }

    // Entrega.cs
    public class Entrega
    {
        public int Id { get; set; }
        public int ActividadId { get; set; }
        public int EstudianteId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string ArchivoUrl { get; set; }
        public decimal Calificacion { get; set; }

        public string Estudiante { get; set; }
        public string Titulo { get; set;}
        public string Curso { get; set; }
    }

}