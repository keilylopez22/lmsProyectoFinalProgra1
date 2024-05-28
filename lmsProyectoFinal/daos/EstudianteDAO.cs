using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProyectoFinal
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class EstudianteDAO
    {
        private string connectionString = Constantes.connectionString;

        public EstudianteDAO() { }
        

        public void AddEstudiante(Estudiante estudiante)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Estudiantes (UsuarioId, Nombre, Direccion, Sexo, FechaInscripcion) VALUES (@UsuarioId, @Nombre, @Direccion, @Sexo, @FechaInscripcion)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioId", estudiante.UsuarioId);
                command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                command.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                command.Parameters.AddWithValue("@Sexo", estudiante.Sexo);
                command.Parameters.AddWithValue("@FechaInscripcion", estudiante.FechaInscripcion);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Estudiante GetEstudiante(int id)
        {
            Estudiante estudiante = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Estudiantes WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    estudiante = new Estudiante
                    {
                        Id = (int)reader["Id"],
                        UsuarioId = (int)reader["UsuarioId"],
                        Nombre = (string)reader["Nombre"],
                        Direccion = (string)reader["Direccion"],
                        Sexo = (string)reader["Sexo"],
                        FechaInscripcion = (DateTime)reader["FechaInscripcion"]
                    };
                }
            }
            return estudiante;
        }

        public void UpdateEstudiante(Estudiante estudiante)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Estudiantes SET UsuarioId = @UsuarioId, Nombre = @Nombre, Direccion = @Direccion, Sexo = @Sexo, FechaInscripcion = @FechaInscripcion WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioId", estudiante.UsuarioId);
                command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                command.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                command.Parameters.AddWithValue("@Sexo", estudiante.Sexo);
                command.Parameters.AddWithValue("@FechaInscripcion", estudiante.FechaInscripcion);
                command.Parameters.AddWithValue("@Id", estudiante.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEstudiante(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Estudiantes WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Estudiante> GetAllEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Estudiantes";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        Id = (int)reader["Id"],
                        UsuarioId = (int)reader["usuario_id"],
                        Nombre = (string)reader["Nombre"],
                        Direccion = (string)reader["Direccion"],
                        Sexo = (string)reader["Sexo"],
                        FechaInscripcion = (DateTime)reader["Fecha_Inscripcion"]
                    };
                    estudiantes.Add(estudiante);
                }
            }
            return estudiantes;
        }

        public List<AsignacionEstudianteCurso> GetAllAsignaciones()
        {
            List<AsignacionEstudianteCurso> asignaciones = new List<AsignacionEstudianteCurso>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select p.nombre as estudiante, c.nombre as curso, a.id, a.curso_id , a.estudiante_id  " +
                    "from asignacionestudiantescursos  a join estudiantes p on p.id = a.estudiante_id " +
                    " join cursos c ON c.id  = a.curso_id ";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AsignacionEstudianteCurso asignacion = new AsignacionEstudianteCurso
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["curso_id"],
                        EstudianteId = (int)reader["estudiante_id"],
                        Curso = (string)reader["curso"],
                        Estudiante = (string)reader["estudiante"]
                    };
                    asignaciones.Add(asignacion);
                }
            }
            return asignaciones;
        }
    }

}
