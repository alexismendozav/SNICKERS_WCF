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
    public partial class InicioSesion : Form
    {
        string claveTenis = "";
        string claveCliente = "";
        public InicioSesion()
        {
            InitializeComponent();
        }
        public InicioSesion(string claveTenis)
        {
            InitializeComponent();
            this.claveTenis = claveTenis;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            int inicioSesion = 0;
            if (verificarCampos())
            {
                using (WCFSnickers.Service1Client conexion = new WCFSnickers.Service1Client())
                {
                    inicioSesion = conexion.VerificarLogin(txtUsuario.Text, txtContraseña.Text);
                    if (inicioSesion > 0)
                    {
                        claveCliente = txtUsuario.Text;                       
                        Metodo_pago pago = new Metodo_pago(claveCliente,claveTenis);
                        pago.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
            }           
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro registrarse = new Registro();
            registrarse.Show();
        }
        private bool verificarCampos()
        {
            bool usuario = false, contraseña = false;
            if (txtUsuario.Text == "")
            {
                error1.SetError(txtUsuario, "Favor de digitar su correo");
                usuario = false;
            }
            else
            {
                error1.SetError(txtUsuario, "");
                usuario = true;
            }
            if (txtContraseña.Text.Equals(""))
            {
                error1.SetError(txtContraseña, "Favor de digitar una contraseña");
                contraseña = false;
            }
            else
            {
                error1.SetError(txtContraseña, "");
                contraseña = true;
            }
            if (usuario && contraseña)
                return true;
            else
                return false;
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
