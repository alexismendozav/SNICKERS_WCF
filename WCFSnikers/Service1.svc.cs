using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSnikers
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [System.Web.Script.Services.ScriptService]
    public class Service1 : IService1
    {
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando;

        public Service1()
        {
            ConectarBD();
        }
        //OBTIENE TODOS LOS PRODUCTOS Y LOS DEVUELVE EN UNA LISTA DE OBJETOS 
        public List<Productos> GetProductos()
        {
            List<Productos> products = new List<Productos>();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand ( "SELECT * FROM productos",conexion);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Productos producto = new Productos()
                    {
                        id_producto   = reader[0].ToString(),
                        nombre        = reader[1].ToString(),
                        marca         = reader[2].ToString(),
                        precio        = Convert.ToInt32(reader[3]),
                        objetivo      = Convert.ToInt32(reader[4]),
                        descripcion   = reader[5].ToString(),
                        precio_compra = Convert.ToInt32(reader[6])
                    };
                    products.Add(producto);
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
            finally{
                if(conexion != null)
                conexion.Close();
            }
        }
        //ISERTA UN CLIENTE
        public int SetCliente(Cliente cliente)
        {
            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO clientes VALUES (@id_cliente,@nombre,@apellidos,@correo,@telefono,@codigo_postal,@estado,@ciudad,@colonia,@calle,@contrasena)";
                comando.Parameters.AddWithValue("id_cliente", cliente.id_cliente);
                comando.Parameters.AddWithValue("nombre", cliente.nombre);
                comando.Parameters.AddWithValue("apellidos", cliente.apellidos);
                comando.Parameters.AddWithValue("correo", cliente.correo);
                comando.Parameters.AddWithValue("telefono", cliente.telefono);
                comando.Parameters.AddWithValue("codigo_postal", cliente.codigo_postal);
                comando.Parameters.AddWithValue("estado", cliente.estado);
                comando.Parameters.AddWithValue("ciudad", cliente.ciudad);
                comando.Parameters.AddWithValue("colonia", cliente.colonia);
                comando.Parameters.AddWithValue("calle", cliente.calle);
                comando.Parameters.AddWithValue("contrasena", cliente.contrasena);
                comando.CommandType = System.Data.CommandType.Text;
                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
        }
        //VERIFICA SI EL USUARIO Y CONTRASEÑA EXISTEN 
        public int VerificarLogin(string correo,string contrasena)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM clientes WHERE correo=@correo AND contraseña =@contrasena ", conexion);
                cmd.Parameters.AddWithValue("correo", correo);
                cmd.Parameters.AddWithValue("contrasena", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt.Rows.Count ;                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
        }
        //AÑADE LA COMPRA
        public int SetCompra(Compra compra)
        {
            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO compras VALUES (@id_compra,@id_cliente,@fecha,@precio_total,@direccion_entrega,@costo_envio)";
                comando.Parameters.AddWithValue("id_compra",compra.id_compra);
                comando.Parameters.AddWithValue("id_cliente",compra.id_cliente);
                comando.Parameters.AddWithValue("fecha",compra.fecha);
                comando.Parameters.AddWithValue("precio_total", compra.precioTotal);
                comando.Parameters.AddWithValue("direccion_entrega", compra.direccion_entrega);
                comando.Parameters.AddWithValue("costo_envio", compra.costo_envio);
                comando.CommandType = System.Data.CommandType.Text;
                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
        }
        //AÑADE EL DETALLE DE LA COMPRA
        public int SetDetalleCompra(DetalleCompra detalle_compra)
        {
            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO detalle_compra VALUES (@id_compra,@id_producto,@precio,@cantidad)";
                comando.Parameters.AddWithValue("id_compra", detalle_compra.id_compra);
                comando.Parameters.AddWithValue("id_producto", detalle_compra.id_producto);
                comando.Parameters.AddWithValue("precio", detalle_compra.precio);
                comando.Parameters.AddWithValue("cantidad", detalle_compra.cantidad);
                comando.CommandType = System.Data.CommandType.Text;
                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
        }

        //OBTIENE TODOS LOS PRODUCTOS Y LOS DEVUELVE EN UNA LISTA DE OBJETOS 
        public List<Productos> GetBusqueda(int objetivo)
        {
            List<Productos> products = new List<Productos>();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM productos WHERE objetivo = "+objetivo+"", conexion);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Productos producto = new Productos()
                    {
                        id_producto = reader[0].ToString(),
                        nombre = reader[1].ToString(),
                        marca = reader[2].ToString(),
                        precio = Convert.ToInt32(reader[3]),
                        objetivo = Convert.ToInt32(reader[4]),
                        descripcion = reader[5].ToString(),
                        precio_compra = Convert.ToInt32(reader[6])
                    };
                    products.Add(producto);
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }
        }

        public void ConectarBD()
        {
            conexion.ConnectionString = "workstation id=snikers.mssql.somee.com;packet size=4096;user id=programacion_SQLLogin_1;" +
                                        "pwd=srdnzqedpm;data source=snikers.mssql.somee.com;persist security info=False;initial catalog=snikers";
            comando = conexion.CreateCommand();
        }
    }
}
