using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Switch.Service
{
    public class UpdateClientListener
    {
        public async Task UpadeAsync(string json)
        {
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                
                var httpResponse = await httpClient.PostAsync("http://185.195.26.249:80/api/Update", httpContent);
               
            }
        }
       

       

    }
}
