using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProyectoFinal.daos
{
    public class RespuestaDao
    {
        private string connectionString = Constantes.connectionString;

        public RespuestaDao() { }


        public void AddRespuesta(Respuesta respuesta)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Respuestas (Foro_ID, Contenido, Autor) " +
                    "VALUES (@ForoId, @Contenido, @Autor)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ForoId", respuesta.ForoId);
                command.Parameters.AddWithValue("@Contenido", respuesta.Contenido);
                command.Parameters.AddWithValue("@Autor", respuesta.Autor);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Respuesta GetEstudiante(int id)
        {
            Respuesta respuesta = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM respuesta WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    respuesta = new Respuesta
                    {
                        Id = (int)reader["Id"],
                        ForoId = (int)reader["Foro_Id"],
                        Contenido = (string)reader["Contenido"],
                        Autor = (string)reader["Autor"],
                        FechaCreacion = (DateTime)reader["Fecha_Creacion"]
                    };
                }
            }
            return respuesta;
        }

        public void UpdateRespuesta(Respuesta respuesta)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE respuesta SET Contenido = @Contenido WHERE id=@Id;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Contenido", respuesta.Contenido);
                command.Parameters.AddWithValue("@Id", respuesta.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRespuesta(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM respuesta WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Respuesta> GetAllForos(int foroId)
        {
            List<Respuesta> respuestas = new List<Respuesta>();
            if (foroId > 0)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM respuesta where foro_id = @ForoId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ForoId", foroId);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Respuesta respuesta = new Respuesta
                        {
                            Id = (int)reader["Id"],
                            ForoId = (int)reader["Foro_Id"],
                            Contenido = (string)reader["Contenido"],
                            Autor = (string)reader["Autor"],
                            FechaCreacion = (DateTime)reader["Fecha_Creacion"]
                        };
                        respuestas.Add(respuesta);
                    }
                }
            }
            return respuestas;
        }
    }
}
