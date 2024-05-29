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
    public partial class FRMMenuUsuarios : Form
    {
        public Usuario usuario { get; set; }
        public FRMMenuUsuarios()
        {
            InitializeComponent();

        }

        private void OcultarSubMenu()
        {
            PNLSubMenuUsuarios.Visible = false;
            pnlSubMenuEstudiantes.Visible = false;
            pnlSubMenuProfesores.Visible = false;
            pnlSubMenuCursos.Visible = false;
            pnlSubMenuIformes.Visible=false;
            
        }
        private void mostarSubMenu(Panel subMenu)
        {
            OcultarSubMenu();
            subMenu.Visible = true;
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            mostarSubMenu(PNLSubMenuUsuarios);

        }
        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            mostarSubMenu(pnlSubMenuEstudiantes);
        }
        private void btnProfesores_Click(object sender, EventArgs e)
        {
            mostarSubMenu(pnlSubMenuProfesores);
        }
        private void btnCursos_Click(object sender, EventArgs e)
        {
            mostarSubMenu(pnlSubMenuCursos);
        }
        private void btnCalificaciones_Click(object sender, EventArgs e)
        {

        }

        Form activo = null;
        private void mostrarForm(Form form)
        {
            if (null != activo)
            {
                activo.Close();

            }
            activo = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            pnlContenedor.Controls.Add(form);
            pnlContenedor.Tag = activo;
            form.BringToFront();
            form.Show();

        }
        private void bntListarUsuarios_Click(object sender, EventArgs e)
        {
            FRMUsuarios form = new FRMUsuarios();
            mostrarForm(form);

        }
        private void btnListarEstudiantes_Click(object sender, EventArgs e)
        {
            FRMEstudiantes form = new FRMEstudiantes();
            mostrarForm(form);
        }
        private void btnListarProfesores_Click(object sender, EventArgs e)
        {
            FRMProfesores form = new FRMProfesores();
            mostrarForm(form);
        }
        private void btnListarCursos_Click(object sender, EventArgs e)
        {
            FRMCursos form = new FRMCursos();
            mostrarForm(form);

        }
        private void btnCalificaciones_Click_1(object sender, EventArgs e)
        {
            FRMCalificaciones form = new FRMCalificaciones();
            mostrarForm(form);

        }
        private void btnAsignacionProfesores_Click(object sender, EventArgs e)
        {
            FRMAsignacionProfesor form = new FRMAsignacionProfesor();
            mostrarForm(form);
        }
        private void btnAsignacionEstudiantes_Click(object sender, EventArgs e)
        {
            FRMAsignacionEstudiante form = new FRMAsignacionEstudiante();
            mostrarForm(form);
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            mostarSubMenu(pnlSubMenuIformes);
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            FRMActividades form = new FRMActividades();
            mostrarForm(form);
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnForos_Click(object sender, EventArgs e)
        {
            FRMForos form = new FRMForos();
            mostrarForm(form);
        }
    }
}
