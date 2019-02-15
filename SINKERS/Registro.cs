using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SINKERS
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            int exito;
            if (verificarTextBox())
            {
                using (WCFSnickers.Service1Client conexion = new WCFSnickers.Service1Client())
                {
                    WCFSnickers.Cliente client = new WCFSnickers.Cliente()
                    {
                        Id_cliente = txtNombre.Text.Length,
                        Nombre = txtNombre.Text,
                        Apellidos = txtApellidos.Text,
                        Correo = txtCorreo.Text,
                        Telefono = txtTel.Text,
                        Codigo_postal = txtCp.Text,
                        Estado = txtEstado.Text,
                        Ciudad = txtCiudad.Text,
                        Colonia = txtColonia.Text,
                        Calle = txtCalle.Text,
                        Contrasena = txtContrasena.Text

                    };
                    exito = conexion.SetCliente(client);
                    if (exito == 0)
                        MessageBox.Show("ALGO SALIO MAL , VUELVA A INTENTARLO");
                }
                this.Close();
            }           
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        public bool verificarTextBox()
        {
            bool nombre = false, apellidos = false, celular = false, calle = false
            , colonia = false, ciudad = false, estado = false, correo = false, contraseña = false, verificar = false,cp=false;
            //NOMBRE
            if (txtNombre.Text == "")
            {
                error.SetError(txtNombre, "Favor de digitar su nombre");
                nombre = false;
            }
            else
            {
                error.SetError(txtNombre, "");
                nombre = true;
            }
            //APELLIDOS
            if (txtApellidos.Text.Equals(""))
            {
                error.SetError(txtApellidos, "Favor de digitar su apellido");
                apellidos = false;
            }
            else
            {
                error.SetError(txtApellidos, "");
                apellidos = true;
            }
            //CP
            if (txtCp.Text.Equals(""))
            {
                error.SetError(txtCp, "Favor de digitar su codigo postal");
                cp = false;
            }
            else
            {
                error.SetError(txtCp, "");
                cp = true;
            }
            //CELULAR 

            if (txtTel.Text.Equals(""))
            {
                error.SetError(txtTel, "Favor de ingresar su numero");
                celular = false;
            }
            else
            {
                error.SetError(txtTel, "");
                celular = true;
            }

            //CALLE
            if (txtCalle.Text.Equals(""))
            {
                error.SetError(txtCalle, "Digite su calle");
                calle = false;
            }
            else
            {
                error.SetError(txtCalle, "");
                calle = true;
            }

            
            //COLONIA
            if (txtColonia.Text.Equals(""))
            {
                error.SetError(txtColonia, "Digite el nombre de su colonia");
                colonia = false;
            }
            else
            {
                error.SetError(txtColonia, "");
                colonia = true;
            }
            //CIUDAD
            if (txtCiudad.Text.Equals(""))
            {
                error.SetError(txtCiudad, "Digite el nombre de su ciudad");
                ciudad = false;
            }
            else
            {
                error.SetError(txtCiudad, "");
                ciudad = true;
            }
            //ESTADO
            if (txtEstado.Text.Equals(""))
            {
                error.SetError(txtEstado, "Digite el nombre de su estado");
                estado = false;
            }
            else
            {
                error.SetError(txtEstado, "");
                estado = true;
            }
            //CORREO
            if (txtCorreo.Text.Equals(""))
            {
                error.SetError(txtCorreo, "Este campo es importante favor de llenarlo");
                correo = false;
            }
            else
            {
                error.SetError(txtCorreo, "");
                correo = true;
            }
            //CONTRASEÑA
            if (txtContrasena.Text.Equals(""))
            {
                error.SetError(txtContrasena, "Este campo es importante favor de llenarlo");
                contraseña = false;
            }
            else
            {
                error.SetError(txtContrasena, "");
                contraseña = true;
            }
            //VERIFICAR CONTRASEÑA
            if (txtVCotra.Text.Equals(""))
            {
                error.SetError(txtVCotra, "Este campo es importante favor de llenarlo");
                verificar = false;
            }
            else
            {
                if (txtVCotra.Text.Equals(txtContrasena.Text))
                {
                    error.SetError(txtVCotra, "");
                    verificar = true;
                }
                else
                {
                    error.SetError(txtVCotra, "LAS CONTRASEÑAS NO COINCIDEN");
                    verificar = false;
                }


            }
            if (nombre && apellidos && celular &&  calle &&  colonia && ciudad && estado && correo && contraseña && verificar && cp)
                return true;
            else
                return false;
        }
    }
}
