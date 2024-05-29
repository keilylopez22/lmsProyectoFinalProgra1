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
    public partial class FRMMenuAdmin : Form
    {

        public Usuario usuario { get; set; }
        public FRMMenuAdmin()
        {
            InitializeComponent();
            ocultarSubmenu();
        }

        private void ocultarSubmenu()
        {
            pnlSubMenuUsuarios.Visible= false;
            pnlSubMenuProfesores.Visible= false;
            pnlSubMenuEstudiantes.Visible= false;   
            pnlSubMenuCursos.Visible= false;
            pnlInformes.Visible= false;
        }

        private void mostrarSubMenu(Panel subMenu)
        {
            ocultarSubmenu();
            subMenu.Visible = true;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlSubMenuUsuarios);

        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlSubMenuEstudiantes);
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlSubMenuProfesores);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlSubMenuCursos);
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
            form.Dock= DockStyle.Fill;
            form.FormBorderStyle= FormBorderStyle.None;

            pnlContenedor.Controls.Add(form); 
            pnlContenedor.Tag = activo;
            form.BringToFront();
            form.Show();
            

        }

        private void btnListarUsuarios_Click(object sender, EventArgs e)
        {
            FRMUsuarios form = new FRMUsuarios();
            mostrarForm(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRMEstudiantes form = new FRMEstudiantes();
            mostrarForm(form);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FRMCursos form = new FRMCursos();
            mostrarForm(form);
        }

        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            FRMCalificaciones form = new FRMCalificaciones();
            mostrarForm(form);
        }

        private void btnAsigProfesor_Click(object sender, EventArgs e)
        {
            FRMAsignacionProfesor form = new FRMAsignacionProfesor();
            mostrarForm(form);
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            FRMAsignacionEstudiante form = new FRMAsignacionEstudiante();
            mostrarForm(form);
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pnlInformes);
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            FRMActividades form = new FRMActividades();
            mostrarForm(form);
        }

        private void btnForos_Click(object sender, EventArgs e)
        {
            FRMForos form = new FRMForos();
            mostrarForm(form);
        }

        

        private void FRMMenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            FRMPerfil form = new FRMPerfil();
            mostrarForm(form);
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            FRMGrupos form = new FRMGrupos();
            mostrarForm(form);
        }
    }
}
