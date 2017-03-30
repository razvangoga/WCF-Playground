using JSON_WCF_Client.SOAPAndJSONService;
using JSON_WCF_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
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

            try
            {
                using (SOAPAndJSONServiceClient jsonClient = new SOAPAndJSONServiceClient("json"))
                {
                    string getExampleUrl = $"{jsonClient.Endpoint.Address}/GetExample";
                    string doStuffUrl = $"{jsonClient.Endpoint.Address}/DoStuff";
                    string doOtherStuffUrl = $"{jsonClient.Endpoint.Address}/DoOtherStuff";

                    Output example = Post(getExampleUrl, new Input());
                    Console.WriteLine(example);

                    Output output1 = Post(doStuffUrl, new Input() { Info = "bubu", Reversed = false });
                    Console.WriteLine(output1.ToString());

                    Output output2 = Post(doOtherStuffUrl, new Input() { Info = "lulu", Reversed = true });
                    Console.WriteLine(output2.ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Direct JSON request failed : {0}", ex.ToString());
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static Output Post(string url, Input input)
        {
            DataContractJsonSerializer inputSerializer = new DataContractJsonSerializer(typeof(Input));
            using (MemoryStream inputStream = new MemoryStream())
            {
                inputSerializer.WriteObject(inputStream, input);
                string data = Encoding.UTF8.GetString(inputStream.ToArray(), 0, (int)inputStream.Length);

                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers["Content-type"] = "application/json";
                    webClient.Encoding = Encoding.UTF8;
                    string result = webClient.UploadString(url, "POST", data);

                    using (MemoryStream outputStream = new MemoryStream(Encoding.UTF8.GetBytes(result)))
                    {
                        DataContractJsonSerializer outputSerializer = new DataContractJsonSerializer(typeof(Output));
                        return (Output)outputSerializer.ReadObject(outputStream);
                    }
                }
            }

        }
    }
}
