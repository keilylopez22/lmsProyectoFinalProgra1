using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProyectoFinal
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class MaterialCursoDAO
    {
        private string connectionString;

        public MaterialCursoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddMaterialCurso(MaterialCurso materialCurso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO MaterialesCurso (CursoId, Titulo, Descripcion, Url) VALUES (@CursoId, @Titulo, @Descripcion, @Url)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", materialCurso.CursoId);
                command.Parameters.AddWithValue("@Titulo", materialCurso.Titulo);
                command.Parameters.AddWithValue("@Descripcion", materialCurso.Descripcion);
                command.Parameters.AddWithValue("@Url", materialCurso.Url);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public MaterialCurso GetMaterialCurso(int id)
        {
            MaterialCurso materialCurso = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MaterialesCurso WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    materialCurso = new MaterialCurso
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["CursoId"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        Url = (string)reader["Url"]
                    };
                }
            }
            return materialCurso;
        }

        public void UpdateMaterialCurso(MaterialCurso materialCurso)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE MaterialesCurso SET CursoId = @CursoId, Titulo = @Titulo, Descripcion = @Descripcion, Url = @Url WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", materialCurso.CursoId);
                command.Parameters.AddWithValue("@Titulo", materialCurso.Titulo);
                command.Parameters.AddWithValue("@Descripcion", materialCurso.Descripcion);
                command.Parameters.AddWithValue("@Url", materialCurso.Url);
                command.Parameters.AddWithValue("@Id", materialCurso.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteMaterialCurso(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MaterialesCurso WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<MaterialCurso> GetAllMaterialesCurso()
        {
            List<MaterialCurso> materialesCurso = new List<MaterialCurso>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MaterialesCurso";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MaterialCurso materialCurso = new MaterialCurso
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["CursoId"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        Url = (string)reader["Url"]
                    };
                    materialesCurso.Add(materialCurso);
                }
            }
            return materialesCurso;
        }
    }

}
