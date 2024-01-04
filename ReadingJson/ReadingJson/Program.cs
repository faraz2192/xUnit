using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadingJson
{

    public class Program
    {
        public static async Task Main()
        {
            var httpClient = new HttpClient();
            var apiClient = new ApiControllerClient(httpClient);

            // Define the API endpoint
            var controllerEndpoint = "https://your-api-base-url/controller-endpoint";

            // Use the client to get data from the controller
            MyData data = await apiClient.GetDataFromController<MyData>(controllerEndpoint);

            // Now you have the deserialized data, and you can work with it as needed
            Console.WriteLine($"Name: {data.Name}");
            Console.WriteLine($"Language: {data.Language}");
            // Extract more data as required
        }
    }


 /*   public class Program
    {
        static void Main()
        {
            string jsonFilePath = "D:\\bio.json";

            // check if file exists
            if (File.Exists(jsonFilePath))
            {
                // Read Json file
                string jsonContent = File.ReadAllText(jsonFilePath);

                // Deserialize the file
                List<MyData> myDataList = JsonConvert.DeserializeObject<List<MyData>>(jsonContent);
                foreach (MyData data in myDataList)
                {
                    Console.WriteLine("Name: " + data.Name);
                    Console.WriteLine("Language: " + data.Language);
                    Console.WriteLine("ID: " + data.Id);
                    Console.WriteLine("Bio: " + data.Bio);
                    Console.WriteLine("Version: " + data.Version);
                    Console.WriteLine();
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("File does not exist");
                Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            }
        }
    } */
}
