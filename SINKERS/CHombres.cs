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
    public partial class CHombres : Form
    {
        public CHombres()
        {
            InitializeComponent();
        }

        private void CHombres_Load(object sender, EventArgs e)
        {
            using (WCFSnikers.Service1Client conexion = new WCFSnikers.Service1Client())
            {
                int x = 10, xTxt=10,xBtn=10;
                int y = 10, yTxt=150, yBtn=210;
               
                dataGridView1.DataSource = conexion.GetBusqueda(1);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //CREAMOS NUEVA IMAGEN CADA QUE ENCUENTRE UN PRODUCTO
                    var imgPictureBox = new PictureBox();
                    imgPictureBox.Location = new System.Drawing.Point(x, y);
                    imgPictureBox.Size = new System.Drawing.Size(200, 130);
                    imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgPictureBox.Image = Image.FromFile(row.Cells["id_producto"].Value.ToString() + ".jpg");
                    Controls.Add(imgPictureBox);
                    imgPictureBox.Visible = true;
                    //CREAMOS LA DESCRIPCION DE DICHO PRODUCTO
                    TextBox txtDescripcion = new TextBox();
                    txtDescripcion.Location = new System.Drawing.Point(xTxt, yTxt);
                    txtDescripcion.Size = new System.Drawing.Size(200, 50);
                    txtDescripcion.Multiline = true;
                    txtDescripcion.BorderStyle = BorderStyle.None;
                    txtDescripcion.ReadOnly = true;
                    Controls.Add(txtDescripcion);
                    txtDescripcion.Text = (row.Cells["nombre"].Value.ToString() + Environment.NewLine);
                    txtDescripcion.Text += (row.Cells["marca"].Value.ToString() + Environment.NewLine);
                    txtDescripcion.Text += ("$ "+row.Cells["precio"].Value.ToString() + Environment.NewLine);
                    txtDescripcion.Visible = true;
                    //CREAMOS EL BOTON PARA CADA PRODUCTO
                    Button btnComprar = new Button();
                    btnComprar.Location = new System.Drawing.Point(xBtn, yBtn);
                    btnComprar.Size = new System.Drawing.Size(200, 25);
                    btnComprar.Text = "COMPRAR";
                    btnComprar.Cursor = Cursors.Hand;
                    Controls.Add(btnComprar);
                    xTxt += 210;
                    x += 210;
                    xBtn += 210;
                }

            }            
        }
    }
}
