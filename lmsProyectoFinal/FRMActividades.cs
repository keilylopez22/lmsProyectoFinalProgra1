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
    public partial class FRMActividades : Form
    {

        bool esNuevo = true;
        ActividadDAO actividadDAO = new ActividadDAO();
        CursoDAO cursoDAO = new CursoDAO();
        Actividad actividadSeleccionada;
        public FRMActividades()
        {
            InitializeComponent();

            listarCursos();
            ListarActividades();
        }

        public void ListarActividades()
        {
            int cursoId = -1;
            if (cmbCursos.SelectedValue!=null)
                cursoId = (int)cmbCursos.SelectedValue;
            dgvActividades.DataSource= actividadDAO.GetAllActividades(cursoId);
            dgvActividades.Columns["Id"].Visible= false;
            dgvActividades.Columns["cursoId"].Visible = false;
        }

        public void listarCursos()
        {
            List<Curso> lista = new List<Curso>();
            lista.Add(new Curso { 
            Id = -1,
            Nombre = "--Seleccionar--"
            });
            lista.AddRange(cursoDAO.GetAllCursos());
            cmbCursos.DataSource= lista;
            cmbCursos.DisplayMember= "Nombre";
            cmbCursos.ValueMember = "Id";
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
            esNuevo = true;
            ListarActividades();
        }

        private void guardarNuevo()
        {
            Actividad actividad = new Actividad
            {
                CursoId = (int)cmbCursos.SelectedValue,
                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                FechaEntrega = datePickFechaEntrega.Value
            };
            actividadDAO.AddActividad(actividad);

        }

        private void actualizar()
        {
            actividadSeleccionada.Titulo = txtTitulo.Text;
            actividadSeleccionada.Descripcion = txtDescripcion.Text;
            actividadSeleccionada.FechaEntrega=datePickFechaEntrega.Value;
            actividadSeleccionada.CursoId = (int)cmbCursos.SelectedValue;
            actividadDAO.UpdateActividad(actividadSeleccionada);
        }

        private void limpiarCampos()
        {
            txtDescripcion.Clear();
            txtTitulo.Clear();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            esNuevo= true;
        }

        private void dgvActividades_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActividades.SelectedRows.Count > 0) {
                DataGridViewRow row = dgvActividades.SelectedRows[0];
                actividadSeleccionada = new Actividad
                {
                    Id = (int)row.Cells["id"].Value,
                    CursoId = (int)row.Cells["CursoId"].Value,
                    Titulo = (string)row.Cells["Titulo"].Value,
                    Descripcion = (string)row.Cells["Descripcion"].Value,
                    FechaEntrega = (DateTime)row.Cells["FechaEntrega"].Value,
                    Curso = (String)row.Cells["Curso"].Value,
                };
                txtTitulo.Text = actividadSeleccionada.Titulo;
                cmbCursos.SelectedValue = actividadSeleccionada.CursoId;
                txtDescripcion.Text = actividadSeleccionada.Descripcion;
                datePickFechaEntrega.Value = actividadSeleccionada.FechaEntrega;
                esNuevo = false;
            }
        }
    }
}
