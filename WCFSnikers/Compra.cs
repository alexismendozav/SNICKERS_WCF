using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFSnikers
{
    [DataContract]
    public class Compra
    {
        [DataMember]
        public int id_compra { get; set; }
        [DataMember]
        public int id_cliente { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public int precioTotal { get; set; }
        [DataMember]
        public string direccion_entrega { get; set; }
        [DataMember]
        public int costo_envio { get; set; }
    }
}