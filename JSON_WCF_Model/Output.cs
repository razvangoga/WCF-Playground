using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JSON_WCF_Model
{
    [DataContract]
    public class Output
    {
        [DataMember]
        public string SomeString { get; set; }
        [DataMember]
        public byte[] SomeByteArray { get; set; }
        [DataMember]
        public FileType Type { get; set; }

        public override string ToString()
        {
            return $"[{SomeString}] - {Type} -> {SomeByteArray.Length}";
        }
    }

    public enum FileType
    {
        Unknown = 0,
        Html = 1,
        Other = 2,
    }
}
