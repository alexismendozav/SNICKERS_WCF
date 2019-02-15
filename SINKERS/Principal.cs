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

        public Principal()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            
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
            Form catalogo = objetivo as Form;
            catalogo.TopLevel = false;
            catalogo.Dock = DockStyle.Fill;
            this.pnlPrincipal.Controls.Add(catalogo);
            this.pnlPrincipal.Tag = catalogo;
            catalogo.Show();
        }

        private void linkMan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mostrarForm(new CHombres());
        }

        private void btnPresentación_Click(object sender, EventArgs e)
        {
            mostrarForm(new Presentacion());
        }
    }
}
