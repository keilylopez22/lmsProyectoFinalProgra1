using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProyectoFinal.daos
{
    internal class ForoDao
    {
        private string connectionString = Constantes.connectionString;

        public ForoDao() { }


        public void AddForo(Foro foro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Foro(Curso_ID, Titulo, Descripcion) VALUES" +
                    " (@CursoId, @Titulo, @Descripcion)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", foro.CursoId);
                command.Parameters.AddWithValue("@Titulo", foro.Titulo);
                command.Parameters.AddWithValue("@Descripcion", foro.Descripcion);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Foro GetEstudiante(int id)
        {
            Foro foro = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM foro WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    foro = new Foro
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["Curso_id"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        FechaCreacion = (DateTime)reader["Fecha_Creacion"]
                    };
                }
            }
            return foro;
        }

        public void UpdateForo(Foro foro)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE foro SET Curso_ID=@CursoId, Titulo=@Titulo, Descripcion=@Descripcion WHERE id=@Id;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", foro.CursoId);
                command.Parameters.AddWithValue("@Titulo", foro.Titulo);
                command.Parameters.AddWithValue("@Descripcion", foro.Descripcion);
                command.Parameters.AddWithValue("@Id", foro.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteForo(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM foro WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Foro> GetAllForos(int cursoId)
        {
            List<Foro> foros = new List<Foro>();
            if (cursoId > 0)
            {            
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM foro where curso_Id = @CursoId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CursoId", cursoId);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Foro foro = new Foro
                        {
                            Id = (int)reader["Id"],
                            CursoId = (int)reader["Curso_id"],
                            Titulo = (string)reader["Titulo"],
                            Descripcion = (string)reader["Descripcion"],
                            FechaCreacion = (DateTime)reader["Fecha_Creacion"]
                        };
                        foros.Add(foro);
                    }
                }
            }
            return foros;
        }
    }
}
