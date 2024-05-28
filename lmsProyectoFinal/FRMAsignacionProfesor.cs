using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmsProyectoFinal.daos
{
    public partial class FRMAsignacionProfesor : Form
    {
        ProfesorDAO profesorDAO = new ProfesorDAO();
        public FRMAsignacionProfesor()
        {
            InitializeComponent();
            listarAsignaciones();
        }

        private void listarAsignaciones()
        {
            dgvAsignacion.DataSource= profesorDAO.getAllAsignaciones();
            dgvAsignacion.Columns["id"].Visible= false;
            dgvAsignacion.Columns["CursoId"].Visible = false;
            dgvAsignacion.Columns["ProfesorId"].Visible = false;

        }
    }
}
