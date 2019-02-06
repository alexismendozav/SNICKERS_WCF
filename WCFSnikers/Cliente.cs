using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFSnikers
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int id_cliente { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellidos { get; set; }
        [DataMember]
        public string correo { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string codigo_postal { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public string ciudad { get; set; }
        [DataMember]
        public string colonia { get; set; }
        [DataMember]
        public string calle { get; set; }
        [DataMember]
        public string contrasena { get; set; }
    }
}