using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JSON_WCF_Model;
using System.ServiceModel.Activation;

namespace JSON_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SOAPAndJSONService : ISOAPAndJSONService
    {
        public Output DoStuff(Input input)
        {
            string info = input.Reversed ? new string(input.Info.ToCharArray().Reverse().ToArray()) : input.Info;

            info += " (Processed by DoStuff)";

            return new Output()
            {
                SomeString = info,
                SomeByteArray = Encoding.ASCII.GetBytes(info),
                Type = FileType.Html
            };
        }

        public Output DoOtherStuff(Input input)
        {
            string info = input.Reversed ? new string(input.Info.ToCharArray().Reverse().ToArray()) : input.Info;

            info += " (Processed by DoOtherStuff)";

            return new Output()
            {
                SomeString = info,
                SomeByteArray = Encoding.ASCII.GetBytes(info),
                Type = FileType.Other
            };
        }
    }
}
