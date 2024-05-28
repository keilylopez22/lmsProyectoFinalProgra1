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

    public partial class FRMCursos : Form
    {

        CursoDAO cursoDAO = new CursoDAO();
        Curso cursoSeleccionado;
        bool esNuevo = true;
        public FRMCursos()
        {
            InitializeComponent();
            listarCursos();
        }

        private void listarCursos()
        {
            dgvCursos.DataSource= cursoDAO.GetAllCursos();
        }


        private void guardarNuevo()
        {
            Curso curso = new Curso
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                FechaInicio = dtpkFechaIni.Value,
                FechaFin = dtpkFechaFin.Value
            };
            cursoDAO.AddCurso(curso);

        }

        private void actualizar()
        {
            if (cursoSeleccionado != null)
            {
                cursoSeleccionado.Nombre= txtNombre.Text;
                cursoSeleccionado.Descripcion = txtDescripcion.Text;
                cursoSeleccionado.FechaInicio= dtpkFechaIni.Value;
                cursoSeleccionado.FechaFin= dtpkFechaFin.Value;
                cursoDAO.UpdateCurso(cursoSeleccionado);
                cursoSeleccionado= null;
            }
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
            listarCursos();
            reiniciarCampos();
            esNuevo = true;
        }

        private void reiniciarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            reiniciarCampos();
            cursoSeleccionado = null;
            esNuevo= true;
        }

        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCursos.SelectedRows[0];
                cursoSeleccionado = new Curso
                {
                    Id = (int)row.Cells["id"].Value,
                    Nombre = (string)row.Cells["Nombre"].Value,
                    Descripcion = (string)row.Cells["Descripcion"].Value,
                    FechaInicio = (DateTime)row.Cells["FechaInicio"].Value,
                    FechaFin = (DateTime)row.Cells["FechaFin"].Value
                };
                txtNombre.Text= cursoSeleccionado.Nombre;
                txtDescripcion.Text= cursoSeleccionado.Descripcion;
                dtpkFechaFin.Value = cursoSeleccionado.FechaFin;
                dtpkFechaIni.Value = cursoSeleccionado.FechaInicio;
                esNuevo = false;
            }
        }
    }
}
