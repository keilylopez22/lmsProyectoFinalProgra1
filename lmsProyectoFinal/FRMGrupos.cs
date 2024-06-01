using lmsProyectoFinal.daos;
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
    public partial class FRMGrupos : Form
    {
        GrupoDAO grupoDAO=new GrupoDAO();
        Grupo grupoSeleccionado;
        EstudianteDAO estudianteDao = new EstudianteDAO();
        GrupoEstudiantesDAO grupoEstudiantesDAO = new GrupoEstudiantesDAO();
        bool esNuevo=true;
        public FRMGrupos()
        {
            InitializeComponent();
            listarGrupos();
            listarEstudiantes();
        }

        private void listarGrupos()
        {
            dgvGrupos.DataSource = grupoDAO.GetAll();
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

        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count > 0) {
                DataGridViewRow row = dgvGrupos.SelectedRows[0];
                grupoSeleccionado = new Grupo
                {
                    Id = (int)row.Cells["Id"].Value,
                    Nombre = (string)row.Cells["Nombre"].Value,
                    Descripcion = (string)row.Cells["Descripcion"].Value,
                };
                txtNombre.Text = grupoSeleccionado.Nombre;
                txtDescripcion.Text = grupoSeleccionado.Descripcion;
                listarEstudiantesGrupo(grupoSeleccionado.Id);
                esNuevo = false;
            }
            
        }

        private void listarEstudiantesGrupo(int grupoId)
        {
            if (grupoId > 0)
            {
                dgvEstudiantes.DataSource = grupoEstudiantesDAO.GetAll(grupoId);
                dgvEstudiantes.Columns["EstudianteId"].Visible = false;
                dgvEstudiantes.Columns["Id"].Visible = false;
                dgvEstudiantes.Columns["GrupoId"].Visible=false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (esNuevo)
            {
                guardar();
            }
            else
            {
                actualizar();
            }
            esNuevo = true;
            listarGrupos();
            txtDescripcion.Clear();
            txtNombre.Clear();
            MessageBox.Show("Grupo guardado exitosamente");
        }
        private void guardar()
        {
            Grupo grupo = new Grupo
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
            };
            grupoDAO.AddGrupo(grupo);
        }
        private void actualizar()
        {
            grupoSeleccionado.Nombre = txtNombre.Text;
            grupoSeleccionado.Descripcion = txtDescripcion.Text;
            grupoDAO.UpdateGrupo(grupoSeleccionado);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado != null)
            {
                int estudianteId = (int)cmbEstudiantes.SelectedValue;
                GrupoEstudiantes estGrupo = new GrupoEstudiantes
                {
                    GrupoId = grupoSeleccionado.Id,
                    EstudianteId = estudianteId
                };
                grupoEstudiantesDAO.AddGrupoEstudiante(estGrupo);
                MessageBox.Show("Estudiante agregado al grupo");
                listarEstudiantesGrupo(grupoSeleccionado.Id);
            }
            
        }
    }
}
