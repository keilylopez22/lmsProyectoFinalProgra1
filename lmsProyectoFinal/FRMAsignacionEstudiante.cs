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
        public FRMAsignacionEstudiante()
        {
            InitializeComponent();
            listarAsignaciones();
        }

        private void listarAsignaciones()
        {
            dgvAsignacion.DataSource = estudianteDAO.GetAllAsignaciones();
            dgvAsignacion.Columns["id"].Visible= false;
            dgvAsignacion.Columns["CursoId"].Visible = false;
            dgvAsignacion.Columns["EstudianteId"].Visible = false;

        }
    }
}
