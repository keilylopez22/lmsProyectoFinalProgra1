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
                UsuarioId =(int) cmbSexo.SelectedValue
            };
            estudianteDAO.UpdateEstudiante(estudiante);
            listarEstudiantes();
        }

        private void actualizar()
        {

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
                    UsuarioId = (int)row.Cells["UsuarioId"].Value
                };
                txtNombre.Text = estudianteSeleccionado.Nombre;
                txtDireccion.Text = estudianteSeleccionado.Direccion;
                cmbSexo.SelectedItem= estudianteSeleccionado.Sexo;
                cmbUsuario.SelectedValue = estudianteSeleccionado.UsuarioId;
                esNuevo = false;
            }
        }
    }

}
