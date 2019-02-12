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
    public partial class Presentacion : Form
    {
        int contador = 0;
        public Presentacion()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador += 1;
            if(contador < 5)
            {
                pbPrincipal.Image = Properties.Resources.banerP1;
                pbSub2.Image = Properties.Resources.baner2_1;
            }
            if(contador < 7)
            {
                pbSub1.Image = Properties.Resources.baner1;
                pbSub3.Image = Properties.Resources.baner3_1;
            }
            if (contador == 5)
            {
                pbPrincipal.Image = Properties.Resources.banerP;
                pbSub2.Image = Properties.Resources.baner2_2;
            }
            if (contador == 7)
            {
                pbSub1.Image = Properties.Resources.baner1_2;
                pbSub3.Image = Properties.Resources.baner3_2;
            }
               
            if (contador == 9)
            {
                pbPrincipal.Image = Properties.Resources.banerP3;
                pbSub2.Image = Properties.Resources.baner2_3;
            }
            if (contador == 11)
            {
                pbSub1.Image = Properties.Resources.baner1_3;
                pbSub3.Image = Properties.Resources.baner3_3;
            }        
            if (contador == 13)
                pbPrincipal.Image = Properties.Resources.banerP2;
            if (contador == 17)
            {
                timer1.Stop();
                contador = 0;
                timer1.Start();
            }
        }
    }
}
