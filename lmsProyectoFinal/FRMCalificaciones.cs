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
    public partial class FRMCalificaciones : Form
    {
        EntregaDAO entregaDao = new EntregaDAO();
        CursoDAO cursoDAO = new CursoDAO();
        EstudianteDAO estudianteDAO = new EstudianteDAO();

        private Entrega entregaSeleccionada;
        public FRMCalificaciones()
        {
            InitializeComponent();
            listarCursos();
            listarEstudiantes();
            listarCalificaciones();
        }

        private void listarCalificaciones()
        {
            int idEstudiante = (int)cmbEstudiante.SelectedValue;
            int idCurso = (int)cmbCursos.SelectedValue;
            dgvCalificaciones.DataSource = entregaDao.GetAllEntregas(idCurso, idEstudiante);
            dgvCalificaciones.Columns["Id"].Visible = false;
            dgvCalificaciones.Columns["ActividadId"].Visible = false;
            dgvCalificaciones.Columns["EstudianteId"].Visible = false;
            dgvCalificaciones.Columns["Estudiante"].DisplayIndex = 0;
            dgvCalificaciones.Columns["Titulo"].DisplayIndex = 1;
            dgvCalificaciones.Columns["Curso"].DisplayIndex = 2;
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
            lista.AddRange(estudianteDAO.GetAllEstudiantes());
            cmbEstudiante.DataSource = lista;
            cmbEstudiante.DisplayMember = "Nombre";
            cmbEstudiante.ValueMember = "Id";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarCalificaciones();
        }

        private void HabDeshabCampos(bool habilitar)
        {
            txtTitulo.ReadOnly = habilitar;
            txtEstudiante.ReadOnly = habilitar;
            numNota.ReadOnly = habilitar;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            numNota.ReadOnly = false;
        }

        private void inicializarCampos()
        {
            txtTitulo.Clear();
            txtEstudiante.Clear();
            numNota.Text= "0";
            HabDeshabCampos(true);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicializarCampos();
        }

        private void dgvCalificaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCalificaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCalificaciones.SelectedRows[0];
                entregaSeleccionada = new Entrega
                {
                    Id = (int)row.Cells["Id"].Value,
                    ActividadId = (int)row.Cells["ActividadId"].Value,
                    EstudianteId = (int)row.Cells["EstudianteId"].Value,
                    Calificacion = (decimal)row.Cells["Calificacion"].Value,
                    ArchivoUrl = (string)row.Cells["ArchivoUrl"].Value,
                    FechaEntrega = (DateTime)row.Cells["FechaEntrega"].Value
                };
                txtEstudiante.Text = (string)row.Cells["Estudiante"].Value;
                txtTitulo.Text = (string)row.Cells["Titulo"].Value;
                txtArchivo.Text = (string)row.Cells["ArchivoUrl"].Value;
                numNota.Text = ((decimal)row.Cells["Calificacion"].Value).ToString();
            }            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (null != entregaSeleccionada)
            {
                entregaSeleccionada.Calificacion = Convert.ToDecimal(numNota.Text);
                entregaDao.UpdateEntrega(entregaSeleccionada);
            }
        }
    }


}
