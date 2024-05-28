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

    public class EntregaDAO
    {
        private string connectionString = Constantes.connectionString;

        public EntregaDAO()
        {
            
        }

        public void AddEntrega(Entrega entrega)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Entregas (ActividadId, EstudianteId, FechaEntrega, ArchivoUrl, Calificacion) VALUES (@ActividadId, @EstudianteId, @FechaEntrega, @ArchivoUrl, @Calificacion)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActividadId", entrega.ActividadId);
                command.Parameters.AddWithValue("@EstudianteId", entrega.EstudianteId);
                command.Parameters.AddWithValue("@FechaEntrega", entrega.FechaEntrega);
                command.Parameters.AddWithValue("@ArchivoUrl", entrega.ArchivoUrl);
                command.Parameters.AddWithValue("@Calificacion", entrega.Calificacion);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Entrega GetEntrega(int id)
        {
            Entrega entrega = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Entregas WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    entrega = new Entrega
                    {
                        Id = (int)reader["Id"],
                        ActividadId = (int)reader["ActividadId"],
                        EstudianteId = (int)reader["EstudianteId"],
                        FechaEntrega = (DateTime)reader["FechaEntrega"],
                        ArchivoUrl = (string)reader["ArchivoUrl"],
                        Calificacion = (decimal)reader["Calificacion"]
                    };
                }
            }
            return entrega;
        }

        public void UpdateEntrega(Entrega entrega)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Entregas SET Actividad_Id = @ActividadId, Estudiante_Id = @EstudianteId, Fecha_Entrega = @FechaEntrega, Archivo_Url = @ArchivoUrl, Calificacion = @Calificacion WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActividadId", entrega.ActividadId);
                command.Parameters.AddWithValue("@EstudianteId", entrega.EstudianteId);
                command.Parameters.AddWithValue("@FechaEntrega", entrega.FechaEntrega);
                command.Parameters.AddWithValue("@ArchivoUrl", entrega.ArchivoUrl);
                command.Parameters.AddWithValue("@Calificacion", entrega.Calificacion);
                command.Parameters.AddWithValue("@Id", entrega.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEntrega(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Entregas WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Entrega> GetAllEntregas(int idCurso, int idEstudiante)
        {
            List<Entrega> entregas = new List<Entrega>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select e.Id, e.Actividad_Id,e.Estudiante_Id, e2.nombre as nom_est , c.nombre as nom_cur, a.titulo, "
                    +" e.fecha_entrega , e.archivo_url, e.calificacion    from entregas e " 
                    +" join actividades a " 
                    + " on a.id  = e.actividad_id "
                    + " join cursos c "
                    + " on c.id  = a.curso_id "
                    + " join estudiantes e2 "
                    + " on e2.id = e.estudiante_id " +
                    "  where 1 = 1 ";
                if (idEstudiante > 0)
                    query += " and e.Estudiante_Id = @EstudianteId";
                if(idCurso>0)
                    query += " and a.curso_id = @CursoId";
                MySqlCommand command = new MySqlCommand(query, connection);
                if (idEstudiante > 0) 
                    command.Parameters.AddWithValue("@EstudianteId", idEstudiante);
                if (idCurso > 0)
                    command.Parameters.AddWithValue("@CursoId", idCurso);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Entrega entrega = new Entrega
                    {
                        Id = (int)reader["Id"],
                        ActividadId = (int)reader["Actividad_Id"],
                        EstudianteId = (int)reader["Estudiante_Id"],
                        FechaEntrega = (DateTime)reader["Fecha_Entrega"],
                        ArchivoUrl = (string)reader["archivo_url"],
                        Calificacion = (decimal)reader["Calificacion"],
                        Titulo = (String)reader["titulo"],
                        Estudiante = (String)reader["nom_est"],
                        Curso = (String)reader["nom_cur"]
                    };
                    entregas.Add(entrega);
                }
            }
            return entregas;
        }
    }

}
