using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProyectoFinal.daos
{
    // Data Access Object para 'Grupo'
    public class GrupoDAO
    {
        private readonly string _connectionString = Constantes.connectionString;

        public GrupoDAO()
        {
        }

        public List<Grupo> GetAll()
        {
            List<Grupo> grupos = new List<Grupo>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM grupos";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Grupo grupo = new Grupo
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Descripcion = (string)reader["Descripcion"],
                        
                    };
                    grupos.Add(grupo);
                }
            }
            return grupos;
        }

        public Grupo GetById(int id)
        {
            Grupo grupo = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM grupos WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    grupo = new Grupo
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Descripcion = (string)reader["Descripcion"]
                    };
                }
            }
            return grupo;
        
        }

        public void AddGrupo(Grupo grupo)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO grupos (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", grupo.Nombre);
                command.Parameters.AddWithValue("@Descripcion", grupo.Descripcion);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateGrupo(Grupo grupo)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE grupos set Nombre = @Nombre, Descripcion = @Descripcion WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", grupo.Nombre);
                command.Parameters.AddWithValue("@Descripcion", grupo.Descripcion);
                command.Parameters.AddWithValue("@Id", grupo.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGrupo(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM grupos WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    // Data Access Object para 'GrupoEstudiantes'
    public class GrupoEstudiantesDAO
    {
        private readonly string connectionString = Constantes.connectionString;

        public GrupoEstudiantesDAO()
        {
        }

        public List<GrupoEstudiantes> GetAll(int grupoId)
        {
            List<GrupoEstudiantes> grupos = new List<GrupoEstudiantes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select ge.id, ge.grupo_id, ge.estudiante_id, e.nombre estudiante, g.nombre grupo from grupo_estudiantes ge " +
                    "join estudiantes e on e.id = ge.estudiante_id join grupos g on g.id = ge.grupo_id where g.id = @GrupoId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@GrupoId", grupoId);
                connection.Open();
                
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GrupoEstudiantes grupo = new GrupoEstudiantes
                    {
                        Id = (int)reader["Id"],
                        Estudiante = (string)reader["estudiante"],
                        Grupo = (string)reader["grupo"],
                        GrupoId = (int)reader["grupo_id"],
                        EstudianteId = (int)reader["estudiante_id"],

                    };
                    grupos.Add(grupo);
                }
            }
            return grupos;
        }



        public void AddGrupoEstudiante(GrupoEstudiantes grupo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO grupo_estudiantes (grupo_id, estudiante_id) VALUES (@GrupoId, @EstudianteId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@GrupoId", grupo.GrupoId);
                command.Parameters.AddWithValue("@EstudianteId", grupo.EstudianteId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        

        public void DeleteGrupoEstudiante(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM grupo_estudiantes WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}
