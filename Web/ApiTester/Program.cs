using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://i-pacs.net/certified/auto-match";

            string key = Convert.ToBase64String(Encoding.UTF8.GetBytes("Smartcareworks"));

            string webRequest = new System.Net.WebClient().DownloadString($"{url}?key={key}&patient_id={442}&accession_number={2071580016868000}&study_date=2020-12-05");

            bool.TryParse(webRequest, out bool result);

            string json = "{ " +
                            $"\"key\": \"{key}\", " +
                            $"\"patient_id\": \"{00002448}\", " +
                            $"\"patient_name\": \"이복자\", " +
                            $"\"accession_number\": \"{517540}\", " +
                            $"\"study_date\": \"{2021 - 05 - 28}\", " +
                            $"\"study_description\": \"{11111}\", " +
                            $"\"emr_data\": \"{2222}\", " +
                            $"\"department\": \"{33333}\", " +
                            $"\"matching\": 111, " +
                            $"\"requested_doctor\": \"sdfs\" " +
                            "}";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                Console.WriteLine(streamReader.ReadToEnd());
                Console.ReadLine();
            }
        }
    }
}
