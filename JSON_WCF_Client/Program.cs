using JSON_WCF_Client.SOAPAndJSONService;
using JSON_WCF_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_WCF_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SOAPAndJSONServiceClient soapClient = new SOAPAndJSONServiceClient("soap"))
            {
                Output output1 = soapClient.DoStuff(new Input() { Info = "bubu", Reversed = false });
                Console.WriteLine(output1.ToString());

                Output output2 = soapClient.DoOtherStuff(new Input() { Info = "lulu", Reversed = true });
                Console.WriteLine(output2.ToString());
            }

            using (SOAPAndJSONServiceClient soapClient = new SOAPAndJSONServiceClient("json"))
            {
                Output output1 = soapClient.DoStuff(new Input() { Info = "bubu", Reversed = false });
                Console.WriteLine(output1.ToString());

                Output output2 = soapClient.DoOtherStuff(new Input() { Info = "lulu", Reversed = true });
                Console.WriteLine(output2.ToString());
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
