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
    public partial class Form1 : Form
    {
        
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;
            Usuario usuario = usuarioDAO.GetUsuarioByNombreAndContrasenia(nombre, contrasenia);
            
            if (null != usuario)
            {
                if (usuario.Rol == "administrador")
                {
                    FRMMenuAdmin form = new FRMMenuAdmin();
                    form.usuario = usuario;
                    form.Owner = this;
                    form.Show();
                }
                else
                {
                    FRMMenuUsuarios form = new FRMMenuUsuarios();
                    form.usuario = usuario;
                    form.Owner = this;  
                    form.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y Contraseña invalidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtContrasenia.Clear();
            txtUsuario.Clear();
        }
    }
}
