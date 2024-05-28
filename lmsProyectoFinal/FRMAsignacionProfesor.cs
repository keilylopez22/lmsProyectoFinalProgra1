using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmsProyectoFinal.daos
{
    public partial class FRMAsignacionProfesor : Form
    {
        ProfesorDAO profesorDAO = new ProfesorDAO();
        CursoDAO cursoDAO = new CursoDAO();
        AsignacionCursoProfesor asignacionSeleccionada;
        public FRMAsignacionProfesor()
        {
            InitializeComponent();
            listarCursos();
            listarProfesores();
            listarAsignaciones();
        }

        private void listarAsignaciones()
        {
            int profesorId =(int) cmbProfesor.SelectedValue;
            int cursoId = (int) cmbCursos.SelectedValue;
            dgvAsignacion.DataSource= profesorDAO.getAllAsignaciones(cursoId, profesorId);
            dgvAsignacion.Columns["id"].Visible= false;
            dgvAsignacion.Columns["CursoId"].Visible = false;
            dgvAsignacion.Columns["ProfesorId"].Visible = false;

        }

        public void listarCursos()
        {
            List<Curso> lista = new List<Curso>();
            lista.Add(new Curso
            {
                Id = -1,
                Nombre = "--Seleccionar--"
            });
            lista.AddRange(cursoDAO.GetAllCursos());
            cmbCursos.DataSource = lista;
            cmbCursos.DisplayMember = "Nombre";
            cmbCursos.ValueMember = "Id";
        }

        public void listarProfesores()
        {
            List<Profesor> lista = new List<Profesor>();
            lista.Add(new Profesor
            {
                Id = -1,
                Nombre = "--Seleccionar--"
            });
            lista.AddRange(profesorDAO.GetAllProfesores());
            cmbProfesor.DataSource = lista;
            cmbProfesor.DisplayMember = "Nombre";
            cmbProfesor.ValueMember = "Id";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarAsignaciones();
        }

        private void dgvAsignacion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsignacion.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAsignacion.SelectedRows[0];
                asignacionSeleccionada = new AsignacionCursoProfesor
                {
                    Id = (int)row.Cells["id"].Value,
                    CursoId = (int)row.Cells["CursoId"].Value,
                    ProfesorId = (int)row.Cells["ProfesorID"].Value
                };
                cmbCursos.SelectedValue = asignacionSeleccionada.CursoId;
                cmbProfesor.SelectedValue = asignacionSeleccionada.ProfesorId;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (asignacionSeleccionada != null)
            {
                profesorDAO.DeleteAsignacion(asignacionSeleccionada.Id);
                listarAsignaciones();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cursoId = (int)cmbCursos.SelectedValue;
            int profesorId = (int)cmbProfesor.SelectedValue;
            if (profesorId > 0 && cursoId > 0)
            {
                AsignacionCursoProfesor asignacion = new AsignacionCursoProfesor
                {
                    CursoId = (int)cmbCursos.SelectedValue,
                    ProfesorId = (int)cmbProfesor.SelectedValue
                };
                profesorDAO.AsignarCurso(asignacion);
                listarAsignaciones();
            }
            else
            {
                MessageBox.Show("Seleccione un curso y un profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
