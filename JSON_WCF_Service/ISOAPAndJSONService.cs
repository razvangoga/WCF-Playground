using JSON_WCF_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace JSON_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISOAPAndJSONService
    {
        [OperationContract]
        //HACK : this should be a GET but the Proxt Client seams to only issue posts
        [WebInvoke(Method = "POST", UriTemplate = "GetExample", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Output GetExample();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DoStuff", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Output DoStuff(Input input);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DoOtherStuff", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Output DoOtherStuff(Input input);
    }
}
