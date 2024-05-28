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

    public class CursoDAO
    {
        private string connectionString = Constantes.connectionString;

        public CursoDAO()
        {
        }

        public void AddCurso(Curso curso)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Cursos (Nombre, Descripcion, FechaInicio, FechaFin) VALUES (@Nombre, @Descripcion, @FechaInicio, @FechaFin)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", curso.Nombre);
                command.Parameters.AddWithValue("@Descripcion", curso.Descripcion);
                command.Parameters.AddWithValue("@FechaInicio", curso.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", curso.FechaFin);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Curso GetCurso(int id)
        {
            Curso curso = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cursos WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    curso = new Curso
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Descripcion = (string)reader["Descripcion"],
                        FechaInicio = (DateTime)reader["FechaInicio"],
                        FechaFin = (DateTime)reader["FechaFin"]
                    };
                }
            }
            return curso;
        }

        public void UpdateCurso(Curso curso)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Cursos SET Nombre = @Nombre, Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", curso.Nombre);
                command.Parameters.AddWithValue("@Descripcion", curso.Descripcion);
                command.Parameters.AddWithValue("@FechaInicio", curso.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", curso.FechaFin);
                command.Parameters.AddWithValue("@Id", curso.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCurso(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Cursos WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Curso> GetAllCursos()
        {
            List<Curso> cursos = new List<Curso>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cursos";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Curso curso = new Curso
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Descripcion = (string)reader["Descripcion"],
                        FechaInicio = (DateTime)reader["Fecha_Inicio"],
                        FechaFin = (DateTime)reader["Fecha_Fin"]
                    };
                    cursos.Add(curso);
                }
            }
            return cursos;
        }
    }

}
