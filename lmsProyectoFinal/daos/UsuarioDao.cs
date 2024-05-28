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

    public class UsuarioDAO
    {
        private string connectionString;

        public UsuarioDAO()
        {
            connectionString = Constantes.connectionString;
        }

        public void AddUsuario(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (Nombre, Email, Contrasenia, Rol) VALUES (@Nombre, @Email, @Contrasenia, @Rol)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                command.Parameters.AddWithValue("@Rol", usuario.Rol);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public Usuario GetUsuarioByNombreAndContrasenia(string nombre, string contrasenia)
        {
            Usuario usuario = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios WHERE Nombre = @Nombre and Contrasenia=@Contrasenia";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Contrasenia", contrasenia);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Email = (string)reader["Email"],
                        Contrasenia = (string)reader["Contrasenia"],
                        Rol = (string)reader["Rol"]
                    };
                }
            }
            return usuario;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Email = @Email, Contrasenia = @Contrasenia, Rol = @Rol WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                command.Parameters.AddWithValue("@Rol", usuario.Rol);
                command.Parameters.AddWithValue("@Id", usuario.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUsuario(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Usuario> GetAllUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Email = (string)reader["Email"],
                        Contrasenia = (string)reader["Contrasenia"],
                        Rol = (string)reader["Rol"]
                    };
                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }
    }

}
