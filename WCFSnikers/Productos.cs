using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFSnikers
{
    [DataContract]
    public class Productos
    {
        [DataMember]
        public string id_producto { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string marca { get; set; }
        [DataMember]
        public int precio { get; set; }
        [DataMember]
        public int objetivo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public int precio_compra { get; set;}
    }
        
}