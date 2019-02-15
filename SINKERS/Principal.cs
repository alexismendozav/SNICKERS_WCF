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
    public partial class Principal : Form
    {
        private int posX;
        private int posY;
        private string tamaño;
        Form catalogo;


        public Principal()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
                tamaño = "grande";
                
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                tamaño = "chico";
            }
           
        }

        private void Presentacion_Load(object sender, EventArgs e)
        {
            mostrarForm(new Presentacion());
           
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mostrarForm(object objetivo)
        {
            if (this.pnlPrincipal.Controls.Count > 0)
                this.pnlPrincipal.Controls.RemoveAt(0);
            catalogo = objetivo as Form;
            catalogo.TopLevel = false;
            catalogo.Dock = DockStyle.Fill;
            this.pnlPrincipal.Controls.Add(catalogo);
            this.pnlPrincipal.Tag = catalogo;
            catalogo.Show();
        }
      

        private void linkMan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AccesoInternet())
                mostrarForm(new CHombres());
            else
                mostrarForm(new Internet());
        }

        private void btnPresentación_Click(object sender, EventArgs e)
        {
            if (AccesoInternet())
            {
                mostrarForm(new Presentacion());
             
            }
         
            else
            mostrarForm(new Internet());
        }

        private void linkWoman_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(AccesoInternet())
            mostrarForm(new CMujeres());
            else
            mostrarForm(new Internet());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {

            }
            else
            {
                if (AccesoInternet())
                {
                    if (WindowState.ToString() == "Normal")
                        tamaño = "chico";
                    else
                        tamaño = "grande";
                    mostrarForm(new Busquedas(txtSearch.Text, tamaño));
                }

                else
                    mostrarForm(new Internet());
            }          
        }
        private bool AccesoInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void linkBoys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AccesoInternet())
                mostrarForm(new CNiños());
            else
                mostrarForm(new Internet());
        }

        private void linkGirls_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AccesoInternet())
                mostrarForm(new CNiñas());
            else
                mostrarForm(new Internet());

        }
        
    }
}
