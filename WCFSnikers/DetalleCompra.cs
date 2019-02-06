using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFSnikers
{
    [DataContract]
    public class DetalleCompra
    {
        [DataMember]
        public int id_compra { get; set; }
        [DataMember]
        public string id_producto { get; set; }
        [DataMember]
        public int precio { get; set; }
        [DataMember]
        public int cantidad { get; set; }
    }
}