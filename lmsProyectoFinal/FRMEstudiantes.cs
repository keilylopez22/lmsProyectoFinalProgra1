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
    public partial class FRMEstudiantes : Form
    {
        EstudianteDAO estudianteDAO = new EstudianteDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        bool esNuevo = true;
        Estudiante estudianteSeleccionado;
        public FRMEstudiantes()
        {
            InitializeComponent();
            listarUsuarios();
            listarEstudiantes();
            revisarPermisos();
        }

        private void revisarPermisos()
        {
            bool permitido = Sesion.isAdmin();
            pnlInputs.Enabled = permitido;
            foreach (Control c in pnlInputs.Controls)
            {
                c.Enabled = permitido;
            }
        }
        private void listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            lista.Add(new Usuario
            {
                Id = -1,
                Nombre = "--Seleccionar--"
            });

            lista.AddRange(usuarioDAO.GetAllUsuarios());
            cmbUsuario.DataSource = lista;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "Id";
        }

        private void listarEstudiantes()
        {
            dgvEstudiantes.DataSource= estudianteDAO.GetAllEstudiantes();
            dgvEstudiantes.Columns["UsuarioId"].Visible = false;
        }
        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
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
        }

        private void guardarNuevo()
        {
            Estudiante estudiante = new Estudiante
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Sexo = cmbSexo.SelectedItem.ToString(),
                UsuarioId = cmbUsuario.SelectedValue != null ? (int)cmbUsuario.SelectedValue : 0,
                FechaInscripcion = dtPckInscripcion.Value
            };
            estudianteDAO.AddEstudiante(estudiante);
            listarEstudiantes();
        }

        private void actualizar()
        {
            estudianteSeleccionado.Nombre = txtNombre.Text;
            estudianteSeleccionado.Direccion= txtDireccion.Text;
            estudianteSeleccionado.Sexo= cmbSexo.SelectedItem.ToString();
            estudianteSeleccionado.UsuarioId = cmbUsuario.SelectedValue != null ? (int)cmbUsuario.SelectedValue : 0;
            estudianteSeleccionado.FechaInscripcion = dtPckInscripcion.Value;
            estudianteDAO.UpdateEstudiante(estudianteSeleccionado);

        }

        private void dgvEstudiantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEstudiantes.SelectedRows[0];
                estudianteSeleccionado = new Estudiante
                {
                    Id = (int)row.Cells["Id"].Value,
                    Nombre = (string)row.Cells["Nombre"].Value,
                    Direccion = (string)row.Cells["Direccion"].Value,
                    Sexo = (string)row.Cells["Sexo"].Value,
                    UsuarioId = (int)row.Cells["UsuarioId"].Value,
                    FechaInscripcion = (DateTime)row.Cells["FechaInscripcion"].Value,
                };
                txtNombre.Text = estudianteSeleccionado.Nombre;
                txtDireccion.Text = estudianteSeleccionado.Direccion;
                cmbSexo.SelectedItem= estudianteSeleccionado.Sexo;
                cmbUsuario.SelectedValue = estudianteSeleccionado.UsuarioId;
                dtPckInscripcion.Value = estudianteSeleccionado.FechaInscripcion;
                esNuevo = false;
            }
        }
        private void inicializarCampos()
        {
            txtDireccion.Clear();
            txtNombre.Clear();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicializarCampos();
            estudianteSeleccionado = null;
            esNuevo= true;
        }

        private void FRMEstudiantes_Load(object sender, EventArgs e)
        {

        }
        private void CargaFoto()
        {
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            CargaFoto();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (estudianteSeleccionado != null)
            {
                estudianteDAO.DeleteEstudiante(estudianteSeleccionado.Id);
            }
            listarEstudiantes();
            limpiarCampos();
        }

        private void pnlInputs_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
