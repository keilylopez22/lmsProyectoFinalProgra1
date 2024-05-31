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
    public partial class FRMProfesores : Form
    {
        ProfesorDAO profesorDAO = new ProfesorDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        bool esNuevo = true;
        Profesor profesorSeleccionado;
        public FRMProfesores()
        {
            InitializeComponent();
            listarUsuarios();
            listarProfesores();
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

        private void listarProfesores()
        {
            dgvProfesores.DataSource = profesorDAO.GetAllProfesores();
            dgvProfesores.Columns["Id"].Visible= false;
            dgvProfesores.Columns["usuarioId"].Visible = false;
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
            limpiarCampos();
            listarProfesores();
            esNuevo= true;
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
        }

        private void guardarNuevo()
        {
            Profesor profesor = new Profesor
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Sexo = cmbSexo.SelectedItem.ToString(),
                UsuarioId = cmbUsuario.SelectedValue != null ? (int)cmbUsuario.SelectedValue : 0,
                FechaContratacion = dtPckInscripcion.Value
            };
            profesorDAO.AddProfesor(profesor);
            listarProfesores();
        }

        private void actualizar()
        {
            profesorSeleccionado.Nombre = txtNombre.Text;
            profesorSeleccionado.Direccion = txtDireccion.Text;
            profesorSeleccionado.Sexo = cmbSexo.SelectedItem.ToString();
            profesorSeleccionado.UsuarioId = cmbUsuario.SelectedValue != null ? (int)cmbUsuario.SelectedValue : 0;
            profesorSeleccionado.FechaContratacion = dtPckInscripcion.Value;
            profesorDAO.UpdateProfesor(profesorSeleccionado);
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (profesorSeleccionado != null)
            {
                profesorDAO.DeleteProfesor(profesorSeleccionado.Id);
            }
            limpiarCampos();
            listarProfesores();
        }

        private void dgvProfesores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfesores.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProfesores.SelectedRows[0];
                profesorSeleccionado = new Profesor
                {
                    Id = (int)row.Cells["Id"].Value,
                    Nombre = (string)row.Cells["Nombre"].Value,
                    Direccion = (string)row.Cells["Direccion"].Value,
                    Sexo = (string)row.Cells["Sexo"].Value,
                    UsuarioId = (int)row.Cells["UsuarioId"].Value,
                    FechaContratacion = (DateTime)row.Cells["FechaContratacion"].Value,
                };
                txtNombre.Text = profesorSeleccionado.Nombre;
                txtDireccion.Text = profesorSeleccionado.Direccion;
                cmbSexo.SelectedItem = profesorSeleccionado.Sexo;
                cmbUsuario.SelectedValue = profesorSeleccionado.UsuarioId;
                dtPckInscripcion.Value = profesorSeleccionado.FechaContratacion;
                esNuevo = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
