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
        bool esNuevo = true;
        Estudiante estudianteSeleccionado;
        public FRMEstudiantes()
        {
            InitializeComponent();
            listarEstudiantes();
        }

        private void listarEstudiantes()
        {
            dgvEstudiantes.DataSource= estudianteDAO.GetAllEstudiantes();
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
                    Sexo = cmbSexo.SelectedItem.ToString(),
                    UsuarioId = (int)cmbUsuario.SelectedValue
                };
                txtNombre.Text = estudianteSeleccionado.Nombre;
                txtDireccion.Text = estudianteSeleccionado.Direccion;
                cmbSexo.SelectedValue= estudianteSeleccionado.Sexo;
                cmbUsuario.SelectedValue = estudianteSeleccionado.UsuarioId;
                esNuevo = false;
            }
        }
    }

}
