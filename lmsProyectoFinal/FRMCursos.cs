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

    public partial class FRMCursos : Form
    {

        CursoDAO cursoDAO = new CursoDAO();
        public FRMCursos()
        {
            InitializeComponent();
            listarCursos();
        }

        private void listarCursos()
        {
            dgvCursos.DataSource= cursoDAO.GetAllCursos();
        }
    }
}
