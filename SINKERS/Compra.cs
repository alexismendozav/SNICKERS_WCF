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
    public partial class Compra : Form
    {
        private string modelo="";
            private string correo="";
        public Compra()
        {
            InitializeComponent();
        }
        public Compra(string correo,string modelo)
        {
            InitializeComponent();
            this.modelo = modelo;
            this.correo = correo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Compra_Load(object sender, EventArgs e)
        {

            this.TopMost = true;
            using (WCFSnickers.Service1Client conexion = new WCFSnickers.Service1Client())
            {         
                dataGridView1.DataSource = conexion.GetBusquedaClave(modelo);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lblImporte.Text = ("" + row.Cells["precio"].Value.ToString());
                    lblImporte1.Text = ("$ " + row.Cells["precio"].Value.ToString());
                    lblDescripcion.Text = (row.Cells["nombre"].Value.ToString()) + (" " + row.Cells["marca"].Value.ToString());
                }
                dataGridView1.DataSource = conexion.GetClientes(correo);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    lblCliente .Text = ("" + row.Cells["nombre"].Value.ToString() +" "+row.Cells["apellidos"].Value.ToString());
                    lblDireccion.Text = row.Cells["calle"].Value.ToString() +" "+ row.Cells["colonia"].Value.ToString() + " " + row.Cells["ciudad"].Value.ToString() + " " + row.Cells["estado"].Value.ToString();
                    lblCP.Text = "CP: "+ row.Cells["codigo_postal"].Value.ToString();

                }
                DateTime fecha = DateTime.Now;
                lblFecha.Text = fecha.ToString();
            }
        }
    }
}
