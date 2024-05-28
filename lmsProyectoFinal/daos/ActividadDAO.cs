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

    public class ActividadDAO
    {
        private string connectionString = Constantes.connectionString;

        public ActividadDAO()
        {

        }

        public void AddActividad(Actividad actividad)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Actividades (Curso_Id, Titulo, Descripcion, Fecha_Entrega) VALUES (@CursoId, @Titulo, @Descripcion, @FechaEntrega)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", actividad.CursoId);
                command.Parameters.AddWithValue("@Titulo", actividad.Titulo);
                command.Parameters.AddWithValue("@Descripcion", actividad.Descripcion);
                command.Parameters.AddWithValue("@FechaEntrega", actividad.FechaEntrega);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Actividad GetActividad(int id)
        {
            Actividad actividad = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Actividades WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    actividad = new Actividad
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["CursoId"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        FechaEntrega = (DateTime)reader["FechaEntrega"]
                    };
                }
            }
            return actividad;
        }

        public void UpdateActividad(Actividad actividad)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Actividades SET Curso_Id = @CursoId, Titulo = @Titulo, Descripcion = @Descripcion, Fecha_Entrega = @FechaEntrega WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", actividad.CursoId);
                command.Parameters.AddWithValue("@Titulo", actividad.Titulo);
                command.Parameters.AddWithValue("@Descripcion", actividad.Descripcion);
                command.Parameters.AddWithValue("@FechaEntrega", actividad.FechaEntrega);
                command.Parameters.AddWithValue("@Id", actividad.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteActividad(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Actividades WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Actividad> GetAllActividades(int cursoId)
        {
            List<Actividad> actividades = new List<Actividad>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select a.*, c.nombre as curso from actividades a join cursos c on c.id = a.curso_id where 1=1 ";
                if (cursoId > 0)
                {
                    query += " and c.id = @CursoId";
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                if (cursoId > 0)
                {
                    command.Parameters.AddWithValue("@CursoId", cursoId);
                }
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Actividad actividad = new Actividad
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["Curso_Id"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        Curso = (string)reader["Curso"],
                        FechaEntrega = (DateTime)reader["Fecha_Entrega"]
                    };
                    actividades.Add(actividad);
                }
            }
            return actividades;
        }
    }

}
