using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSnikers
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Productos> GetProductos();
        [OperationContract]
        int SetCliente(Cliente cliente);
        [OperationContract]
        int SetCompra(Compra compra);
        [OperationContract]
        int SetDetalleCompra(DetalleCompra detalle_compra);
        [OperationContract]
        int VerificarLogin(string correo, string contrasena);
    }    
}
