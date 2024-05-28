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

    public class ProfesorDAO
    {
        private string connectionString = Constantes.connectionString;

        public ProfesorDAO()
        {
        }

        public void AddProfesor(Profesor profesor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Profesores (Usuario_Id, Nombre, Direccion, Sexo, Fecha_Contratacion) VALUES (@UsuarioId, @Nombre, @Direccion, @Sexo, @FechaContratacion)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioId", profesor.UsuarioId);
                command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                command.Parameters.AddWithValue("@Direccion", profesor.Direccion);
                command.Parameters.AddWithValue("@Sexo", profesor.Sexo);
                command.Parameters.AddWithValue("@FechaContratacion", profesor.FechaContratacion);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Profesor GetProfesor(int id)
        {
            Profesor profesor = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Profesores WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    profesor = new Profesor
                    {
                        Id = (int)reader["Id"],
                        UsuarioId = (int)reader["UsuarioId"],
                        Nombre = (string)reader["Nombre"],
                        Direccion = (string)reader["Direccion"],
                        Sexo = (string)reader["Sexo"],
                        FechaContratacion = (DateTime)reader["FechaContratacion"]
                    };
                }
            }
            return profesor;
        }

        public void UpdateProfesor(Profesor profesor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Profesores SET Usuario_Id = @UsuarioId, Nombre = @Nombre, Direccion = @Direccion, Sexo = @Sexo, Fecha_Contratacion = @FechaContratacion WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioId", profesor.UsuarioId);
                command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                command.Parameters.AddWithValue("@Direccion", profesor.Direccion);
                command.Parameters.AddWithValue("@Sexo", profesor.Sexo);
                command.Parameters.AddWithValue("@FechaContratacion", profesor.FechaContratacion);
                command.Parameters.AddWithValue("@Id", profesor.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProfesor(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Profesores WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Profesor> GetAllProfesores()
        {
            List<Profesor> profesores = new List<Profesor>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Profesores";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Profesor profesor = new Profesor
                    {
                        Id = (int)reader["Id"],
                        UsuarioId = (int)reader["Usuario_Id"],
                        Nombre = (string)reader["Nombre"],
                        Direccion = (string)reader["Direccion"],
                        Sexo = (string)reader["Sexo"],
                        FechaContratacion = (DateTime)reader["Fecha_Contratacion"]
                    };
                    profesores.Add(profesor);
                }
            }
            return profesores;
        }

        public List<AsignacionCursoProfesor> getAllAsignaciones(int cursoId, int profesorId)
        {
            List<AsignacionCursoProfesor> asignaciones = new List<AsignacionCursoProfesor>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select p.nombre as profesor , c.nombre as curso, a.id, a.curso_id , a.profesor_id  "
                    +" from asignacioncursosprofesores a join profesores p on p.id = a.profesor_id " +
                    " join cursos c ON c.id  = a.curso_id WHERE 1=1 ";

                if (cursoId > 0)
                {
                    query += " and a.curso_id = @CursoId";
                }

                if (profesorId > 0)
                {
                    query += " and a.profesor_id = @ProfesorId";
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                if (cursoId > 0)
                {
                    command.Parameters.AddWithValue("@CursoId", cursoId);
                }

                if (profesorId > 0)
                {
                    command.Parameters.AddWithValue("@ProfesorId", profesorId);
                }
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AsignacionCursoProfesor asignacion = new AsignacionCursoProfesor
                    {
                        Id = (int)reader["Id"],
                        CursoId = (int)reader["curso_id"],
                        ProfesorId = (int)reader["profesor_id"],
                        Curso = (string)reader["curso"],
                        Profesor = (string)reader["profesor"]                        
                    };
                    asignaciones.Add(asignacion);
                }
            }
            return asignaciones;
        }

        public void AsignarCurso(AsignacionCursoProfesor asignacion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO asignacioncursosprofesores (curso_id, profesor_id) VALUES (@CursoId, @ProfesorId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoId", asignacion.CursoId);
                command.Parameters.AddWithValue("@ProfesorId", asignacion.ProfesorId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteAsignacion(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM asignacioncursosprofesores WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }

}
