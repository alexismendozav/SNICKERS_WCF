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
    public partial class Metodo_pago : Form
    {
        string cliente;
        string modelo;
        public Metodo_pago(string cliente,string modelo)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.modelo = modelo;
        }

        private void Metodo_pago_Load(object sender, EventArgs e)
        {
            rbtnCredito.Checked = true;
            this.TopMost = true;
        }

        private void btnPresentación_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verificarDatos())
            {
                Compra compra = new Compra(cliente, modelo);
                compra.Show();
                this.Hide();
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool verificarDatos()
        {
            bool correo = false, nombre = false, numero_tarjeta = false, mm = false, csc = false;
            //Correo
            if (txtCorreo.Text == "")
            {
                error.SetError(txtCorreo, "Favor de digitar su correo");
                correo = false;
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, "[a_zA_Z]*@[a_zA_Z]*"))
                {
                    error.SetError(txtCorreo, "");
                    correo = true;
                }
                else
                {
                    error.SetError(txtCorreo, "Favor de dijitar un correo valido");
                }
             
            }
            //Nombre
            if (txtNombre.Text.Equals(""))
            {
                error.SetError(txtNombre, "Favor de digitar su nombre");
                nombre = false;
            }
            else
            {
                error.SetError(txtNombre, "");
                nombre = true;
            }
            // Numero tarjeta
            if (txtTarjeta.Text.Equals(""))
            {
                error.SetError(txtTarjeta, "Favor de digitar un numero de tarjeta");
                numero_tarjeta = false;
            }
            else
            {
                error.SetError(txtTarjeta, "");
                numero_tarjeta = true;
            }
            //CSC
            if (txtCsc .Text.Equals(""))
            {
                error.SetError(txtCsc, "Favor de digitar su CSC");
                csc = false;
            }
            else
            {
                error.SetError(txtCsc, "");
                csc = true;
            }
            //MM
            if (txtMM.Text.Equals(""))
            {
                error.SetError(txtMM, "Favor de digitar su MM");
                mm = false;
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtMM.Text, "[0-9]{2}/[0-9]{2}"))
                {
                    error.SetError(txtMM, "");
                    mm = true;
                }
                else
                {
                    error.SetError(txtMM, "Favor de dijitar la fecha correcta ejemplo: 01/24");
                }              
            }

            //RETORNAR 
            if (nombre && correo && numero_tarjeta && csc &&  mm)
                return true;
            else
                return false;
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) 
            {
                e.Handled = false;
            }
            else
            {                     
                e.Handled = true;
            }
        }

        private void txtMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCsc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
