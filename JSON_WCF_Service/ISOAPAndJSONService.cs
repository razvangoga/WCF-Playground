using JSON_WCF_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JSON_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISOAPAndJSONService
    {
        [OperationContract]
        Output DoStuff(Input input);

        [OperationContract]
        Output DoOtherStuff(Input input);
    }
}
