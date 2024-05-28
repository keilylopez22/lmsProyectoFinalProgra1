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
    public partial class FRMProfesores : Form
    {
        ProfesorDAO profesorDAO = new ProfesorDAO();
        public FRMProfesores()
        {
            InitializeComponent();
            listarProfesores();
        }

        private void listarProfesores()
        {
            dgvProfesores.DataSource = profesorDAO.GetAllProfesores();
        }
    }
}
