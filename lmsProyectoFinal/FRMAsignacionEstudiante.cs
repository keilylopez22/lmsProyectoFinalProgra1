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
    public partial class FRMAsignacionEstudiante : Form
    {
        EstudianteDAO estudianteDAO = new EstudianteDAO();
        CursoDAO cursoDAO = new CursoDAO();
        EstudianteDAO estudianteDao = new EstudianteDAO();
        AsignacionEstudianteCurso asignacionSeleccionada;
        public FRMAsignacionEstudiante()
        {
            InitializeComponent();
            listarCursos();
            listarEstudiantes();
            listarAsignaciones();
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

        public void listarEstudiantes()
        {
            List<Estudiante> lista = new List<Estudiante>();
            lista.Add(new Estudiante
            {
                Id = -1,
                Nombre = "--Seleccionar--"
            });
            lista.AddRange(estudianteDao.GetAllEstudiantes());
            cmbEstudiantes.DataSource = lista;
            cmbEstudiantes.DisplayMember = "Nombre";
            cmbEstudiantes.ValueMember = "Id";
        }

        private void listarAsignaciones()
        {
            int cursoId = (int)cmbCursos.SelectedValue;
            int estudianteId = (int)cmbEstudiantes.SelectedValue;
            dgvAsignacion.DataSource = estudianteDAO.GetAllAsignaciones(cursoId, estudianteId);
            dgvAsignacion.Columns["id"].Visible= false;
            dgvAsignacion.Columns["CursoId"].Visible = false;
            dgvAsignacion.Columns["EstudianteId"].Visible = false;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarAsignaciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cursoId = (int)cmbCursos.SelectedValue;
            int estudianteId = (int)cmbEstudiantes.SelectedValue;
            if (estudianteId>0 && cursoId > 0)
            {
                AsignacionEstudianteCurso asignacion = new AsignacionEstudianteCurso
                {
                    CursoId = (int)cmbCursos.SelectedValue,
                    EstudianteId = (int)cmbEstudiantes.SelectedValue
                };
                estudianteDAO.AsignarCurso(asignacion);
                listarAsignaciones();
            }
            else
            {
                MessageBox.Show("Seleccione un curso y un estudiante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvAsignacion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsignacion.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAsignacion.SelectedRows[0];
                asignacionSeleccionada = new AsignacionEstudianteCurso
                {
                    Id = (int)row.Cells["id"].Value,
                    CursoId = (int)row.Cells["CursoId"].Value,
                    EstudianteId = (int)row.Cells["EstudianteId"].Value
                };
                cmbCursos.SelectedValue = asignacionSeleccionada.CursoId;
                cmbEstudiantes.SelectedValue = asignacionSeleccionada.EstudianteId;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (asignacionSeleccionada!= null)
            {
                estudianteDAO.EliminarAsignacion(asignacionSeleccionada.Id);
                listarAsignaciones();
            }
        }
    }
}
