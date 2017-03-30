using JSON_WCF_Client.SOAPAndJSONService;
using JSON_WCF_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JSON_WCF_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (SOAPAndJSONServiceClient soapClient = new SOAPAndJSONServiceClient("soap"))
                {
                    Output example = soapClient.GetExample();
                    Console.WriteLine(example);

                    Output output1 = soapClient.DoStuff(new Input() { Info = "bubu", Reversed = false });
                    Console.WriteLine(output1.ToString());

                    Output output2 = soapClient.DoOtherStuff(new Input() { Info = "lulu", Reversed = true });
                    Console.WriteLine(output2.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SOAP client failed : {0}", ex.ToString());
            }

            try
            {
                using (SOAPAndJSONServiceClient jsonClient = new SOAPAndJSONServiceClient("json"))
                {
                    Output example = jsonClient.GetExample();
                    Console.WriteLine(example);

                    Output output1 = jsonClient.DoStuff(new Input() { Info = "bubu", Reversed = false });
                    Console.WriteLine(output1.ToString());

                    Output output2 = jsonClient.DoOtherStuff(new Input() { Info = "lulu", Reversed = true });
                    Console.WriteLine(output2.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON client failed : {0}", ex.ToString());
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
