using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JSON_WCF_Model
{
    [DataContract]
    public class Input
    {
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public bool Reversed { get; set; }
    }
}
