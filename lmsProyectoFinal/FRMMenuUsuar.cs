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
    public partial class FRMMenuUsuar : Form
    { 
        public Profesor profesor { get; set; }
        public FRMMenuUsuar()
        {
            InitializeComponent();
            ocultarSubMenu();
        }
        private void ocultarSubMenu()
        {
            pnlSubMenuUsuarios.Visible = false;
            pnlSubMenuEstudiantes.Visible = false;
            pnlSubMenuProfesores.Visible = false;   
            pnlSubMenuCursos.Visible = false;
            pnlSubMenuInformes.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            ocultarSubMenu();
            subMenu.Visible= true;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuUsuarios);
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuEstudiantes);

        }

        private void btnProfresores_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuProfesores);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuCursos);
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

        private void btnInformes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnlSubMenuInformes);
        }

        private void btnListarUsuarios_Click(object sender, EventArgs e)
        {
            FRMUsuarios form = new FRMUsuarios();
            mostrarForm(form);
        }

        private void btnListarEstudent_Click(object sender, EventArgs e)
        {
            FRMEstudiantes form = new FRMEstudiantes();
            mostrarForm(form);

        }

        private void btnListarProfesores_Click(object sender, EventArgs e)
        {
            
        }

        private void btnListarCursos_Click(object sender, EventArgs e)
        {
            FRMCursos form = new FRMCursos();
            mostrarForm(form);
        }

        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            FRMCalificaciones form = new FRMCalificaciones();
            mostrarForm(form);
        }

        private void btnAsignarProfesores_Click(object sender, EventArgs e)
        {
            FRMAsignacionProfesor form = new FRMAsignacionProfesor();
            mostrarForm(form);

        }

        private void btnAsignarEstudiantes_Click(object sender, EventArgs e)
        {
            FRMAsignacionEstudiante form = new FRMAsignacionEstudiante();
            mostrarForm(form);
        }

        private void btnActividaes_Click(object sender, EventArgs e)
        {
            FRMActividades form = new FRMActividades();
            mostrarForm(form);
        }

        private void btnForos_Click(object sender, EventArgs e)
        {
            FRMForos form = new FRMForos();
            mostrarForm(form);
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
