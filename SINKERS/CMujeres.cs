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
    public partial class CMujeres : Form
    {
       string modelo = "";
        public CMujeres()
        {
            InitializeComponent();
        }

        private void CMujeres_Load(object sender, EventArgs e)
        {
            using (WCFSnickers.Service1Client conexion = new WCFSnickers.Service1Client())
            {
                int figuras = 1;
                int x = 80, xTxt = 80, xBtn = 80;
                int y = 10, yTxt = 150, yBtn = 210;

                dataGridView1.DataSource = conexion.GetBusqueda(2);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //CREAMOS NUEVA IMAGEN CADA QUE ENCUENTRE UN PRODUCTO
                    var imgPictureBox = new PictureBox();
                    imgPictureBox.Location = new System.Drawing.Point(x, y);
                    imgPictureBox.Size = new System.Drawing.Size(220, 130);
                    imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgPictureBox.Image = Image.FromFile(row.Cells["id_producto"].Value.ToString() + ".jpg");
                    Controls.Add(imgPictureBox);
                    imgPictureBox.Visible = true;
                    //CREAMOS LA DESCRIPCION DE DICHO PRODUCTO
                    TextBox txtDescripcion = new TextBox();
                    txtDescripcion.Location = new System.Drawing.Point(xTxt, yTxt);
                    txtDescripcion.Size = new System.Drawing.Size(220, 50);
                    txtDescripcion.Multiline = true;
                    txtDescripcion.BorderStyle = BorderStyle.None;
                    txtDescripcion.ReadOnly = true;
                    txtDescripcion.TextAlign = HorizontalAlignment.Center;
                    txtDescripcion.BackColor = Color.White;
                    Controls.Add(txtDescripcion);
                    txtDescripcion.Text = (row.Cells["nombre"].Value.ToString() + Environment.NewLine);
                    txtDescripcion.Text += (row.Cells["marca"].Value.ToString() + Environment.NewLine);
                    txtDescripcion.Text += ("$ " + row.Cells["precio"].Value.ToString() + Environment.NewLine);
                    txtDescripcion.Visible = true;
                    //CREAMOS EL BOTON PARA CADA PRODUCTO
                    Button btnComprar = new Button();
                    btnComprar.Location = new System.Drawing.Point(xBtn, yBtn);
                    btnComprar.Size = new System.Drawing.Size(220, 25);
                    btnComprar.Text = "COMPRAR\n" + row.Cells["id_producto"].Value.ToString();
                    btnComprar.Cursor = Cursors.Hand;
                    btnComprar.Click += new EventHandler(btnComprar_Click);
                    Controls.Add(btnComprar);
                    if (figuras <= 3)
                    {
                        xTxt += 240;
                        x += 240;
                        xBtn += 240;
                    }
                    else
                    {
                        x = 80;
                        xTxt = 80;
                        xBtn = 80;
                        y += 250;
                        yTxt += 250;
                        yBtn += 250;
                        figuras = 0;
                    }
                    figuras++;
                }

            }
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            string[] valores = boton.Text.Split('\n');
            modelo = valores[1];
            InicioSesion sesion = new InicioSesion(modelo);
            sesion.Show();

        }
    }
}
