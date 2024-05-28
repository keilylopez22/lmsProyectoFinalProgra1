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

    public partial class FRMRespuestas : Form
    {
        private Foro foro;
        RespuestaDao respuestaDao = new RespuestaDao();
        public FRMRespuestas(Foro foro)
        {
            InitializeComponent();
            this.foro = foro;
            mostrarInfoForo();
            ListarRespuestas();
        }

        public void ListarRespuestas()
        {
            int foroId = foro.Id;
            dgvRespuestas.DataSource = respuestaDao.GetAllRespuestas(foroId);
            dgvRespuestas.Columns["Id"].Visible = false;
            dgvRespuestas.Columns["ForoId"].Visible = false;
        }
        private void mostrarInfoForo()
        {
            if (foro!=null)
            {
                txtTitulo.Text = foro.Titulo;
                txtDescripcion.Text = foro.Descripcion;
                dtpckFechaCreacion.Value = foro.FechaCreacion;
            }
        }
    }
}
