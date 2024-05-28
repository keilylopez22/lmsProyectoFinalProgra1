using lmsProyectoFinal.daos;
using Org.BouncyCastle.Crypto.Engines;
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

        private void btnResponder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Estás seguro de enviar la respuesta?",
                "Confirmación de respuesta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string autor = Sesion.getInstance().Usuario != null ? Sesion.getInstance().Usuario.Nombre : "Anonimo";
                Respuesta respuesta = new Respuesta
                {
                    ForoId = foro.Id,
                    Contenido = txtDescripcion.Text,
                    Autor = autor,
                };
                respuestaDao.AddRespuesta(respuesta);
                txtDescripcion.Clear();
                ListarRespuestas();
            }
                
        }
    }
}
