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
            using (SOAPAndJSONServiceClient client = new SOAPAndJSONServiceClient())
            {
                Output output1 = client.DoStuff(new Input() { Info = "bubu", Reversed = false });
                Console.WriteLine(output1.ToString());

                Output output2 = client.DoOtherStuff(new Input() { Info = "lulu", Reversed = true });
                Console.WriteLine(output2.ToString());
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
