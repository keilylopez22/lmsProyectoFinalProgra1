using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmsProyectoFinal
{
    public partial class FRMPerfil : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        Usuario usuario;
        public FRMPerfil()
        {
            InitializeComponent();
        }

        private void FRMPerfil_Load(object sender, EventArgs e)
        {
            try
            {
                usuario = Sesion.getInstance().Usuario;
                txtnombre.Text = usuario.Nombre;
                txtEmail.Text = usuario.Email;
                txtRol.Text = usuario.Rol;
                txtContrasena.Text = usuario.Contrasenia;

                if (usuario.Imagen != null && usuario.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(usuario.Imagen))
                    {
                        Bitmap bm = new Bitmap(ms);
                        pcbImagen.Image = bm;
                    }
                }
                else
                {
                    // Set a default image if user image is null or empty
                    pcbImagen.Image = null; // or set a default image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user image: " + ex.Message);
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            OpenFileDialog oldSeleccionar = new OpenFileDialog();
            oldSeleccionar.Filter = "Imagenes|*.jpg;*.png";
            oldSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            oldSeleccionar.Title = "Seleccionar imagen";

            if (oldSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pcbImagen.Image = Image.FromFile(oldSeleccionar.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pcbImagen.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] abyte = ms.ToArray();
                    usuario.Imagen = abyte;
                }
                usuarioDAO.UpdateUsuario(usuario);
                MessageBox.Show("Usuario guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user data: " + ex.Message);
            }

        }

        private void pcbImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
