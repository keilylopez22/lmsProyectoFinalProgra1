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
    public partial class FRMForos : Form
    {
        CursoDAO cursoDAO = new CursoDAO();
        ForoDao foroDao = new ForoDao();
        Foro foroSeleccionado;
        bool esNuevo = true;
        public FRMForos()
        {
            InitializeComponent();
            listarCursos();
            ListarForos();
        }

        public void ListarForos()
        {
            int cursoId = -1;
            if (cmbCursos.SelectedValue != null)
                cursoId = (int)cmbCursos.SelectedValue;
            dgvForos.DataSource = foroDao.GetAllForos(cursoId);
            dgvForos.Columns["Id"].Visible = false;
            dgvForos.Columns["CursoId"].Visible = false;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarForos();
        }

        private void dgvForos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvForos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvForos.SelectedRows[0];
                foroSeleccionado = new Foro
                {
                    Id = (int)row.Cells["id"].Value,
                    CursoId = (int)row.Cells["CursoId"].Value,
                    Titulo = (string)row.Cells["Titulo"].Value,
                    Descripcion = (string)row.Cells["Descripcion"].Value,
                    FechaCreacion = (DateTime)row.Cells["FechaCreacion"].Value,
                };
                txtTitulo.Text = foroSeleccionado.Titulo;
                cmbCursos.SelectedValue = foroSeleccionado.CursoId;
                txtDescripcion.Text = foroSeleccionado.Descripcion;
                dtpckFechaCreacion.Value = foroSeleccionado.FechaCreacion;
                esNuevo = false;
            }
        }

        private void limpiarCampos()
        {
            txtDescripcion.Clear();
            txtTitulo.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esNuevo)
            {
                guardarNuevo();
            }
            else
            {
                Actualizar();
            }
            limpiarCampos();
            esNuevo = true;
            ListarForos();
        }

        private void guardarNuevo()
        {
            Foro foro = new Foro
            {
                CursoId = (int)cmbCursos.SelectedValue,
                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                FechaCreacion = dtpckFechaCreacion.Value
            };
            foroDao.AddForo(foro);
        }

        private void Actualizar()
        {
            foroSeleccionado.Titulo= txtTitulo.Text;
            foroSeleccionado.Descripcion= txtDescripcion.Text;

            foroDao.UpdateForo(foroSeleccionado);
            foroSeleccionado = null;
        }

        private void btnRespuestas_Click(object sender, EventArgs e)
        {
            FRMRespuestas form = new FRMRespuestas(foroSeleccionado);
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            this.Parent.Controls.Add(form);
            this.Parent.Tag = form;
            form.Show();
            form.BringToFront();
        }
    }
}
