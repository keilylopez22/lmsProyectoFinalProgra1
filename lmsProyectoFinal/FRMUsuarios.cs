using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmsProyectoFinal
{
    public partial class FRMUsuarios : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        bool esNuevo = true;
        Usuario usuarioSeleccionado;
        public FRMUsuarios()
        {
            InitializeComponent();
            limpiarCampos();
        }

        private void revisarPermisos()
        {
            bool permitido = Sesion.getInstance().Usuario.Rol == "administrador";
            txtContrasenia.Enabled= permitido;
            txtEmail.Enabled= permitido;
            txtNombre.Enabled= permitido;
            cmbRol.Enabled= permitido;
            btnGuardar.Enabled= permitido;
            btnEliminar.Enabled= permitido;
            btnCancelar.Enabled= permitido;
        }
        private void listarUsuarios()
        {
            
            dgvUsuarios.DataSource= usuarioDAO.GetAllUsuarios();
        }

        private void FRMUsuarios_Load(object sender, EventArgs e)
        {
            listarUsuarios();
        }

        private void limpiarCampos()
        {
            txtContrasenia.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            revisarPermisos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esNuevo)
            {
                guardarNuevo();
            }
            else
            {
                actualizar();
            }
            listarUsuarios();
            limpiarCampos();
        }

        private void guardarNuevo()
        {
            Usuario usuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Contrasenia = txtContrasenia.Text,
                Rol = (string)cmbRol.SelectedItem.ToString(),
            };
            usuarioDAO.AddUsuario(usuario);

        }
        private void actualizar()
        {
            usuarioSeleccionado.Nombre= txtNombre.Text;
            usuarioSeleccionado.Email= txtEmail.Text;
            usuarioSeleccionado.Contrasenia = txtContrasenia.Text;
            usuarioSeleccionado.Rol = (string)cmbRol.SelectedItem.ToString();
            usuarioDAO.UpdateUsuario(usuarioSeleccionado);
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                usuarioSeleccionado = new Usuario
                {
                    Id = (int)row.Cells["id"].Value,
                    Nombre =(string)row.Cells["Nombre"].Value,
                    Email = (string)row.Cells["Email"].Value,
                    Contrasenia = (string)row.Cells["Contrasenia"].Value,
                    Rol = (string)row.Cells["Rol"].Value,
                };
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtEmail.Text = usuarioSeleccionado.Email;
                txtContrasenia.Text = usuarioSeleccionado.Contrasenia;
                cmbRol.SelectedItem = usuarioSeleccionado.Rol.ToString();
                esNuevo = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado!= null)
            {
                DialogResult result = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este elemento?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    usuarioDAO.DeleteUsuario(usuarioSeleccionado.Id);
                    MessageBox.Show("Elemento eliminado.");
                    listarUsuarios();
                }
                
            }
            
        }
    }
}
