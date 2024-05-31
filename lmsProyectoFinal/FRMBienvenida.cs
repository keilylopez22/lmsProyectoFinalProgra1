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
    public partial class FRMBienvenida : Form
    {
        public FRMBienvenida()
        {
            InitializeComponent();
        }
        // para controlar el tiempo
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            {
                //para que el formulario es gradualmente
                //si la opacidad del formulario es menor a uno la unmentamos auno
                if (this.Opacity < 1) this.Opacity += 0.05;
                //aunmentamos el valor del contador
                circularProgressBar1.Value += 1;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString();
                if(circularProgressBar1.Value == 100) { 
                    
                    timer1.Stop();
                    timer2.Start();
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            {
                //para que el formlario se desvanezca 
                //que la opcacidad se reste a  0.1 
                this.Opacity -= 0.1;
                if (this.Opacity == 0)
                {
                    timer2.Stop();
                    this.Close();
                }

            }
        }

        private void FRMBienvenida_Load(object sender, EventArgs e)
        {
            Usuario usuarioactual = Sesion.getInstance().Usuario;

            lblUsuario.Text = usuarioactual.Nombre;
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
           

        }
    }
}
