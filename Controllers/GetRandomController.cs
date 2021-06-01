using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Switch.Models;
using Switch.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace Switch.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class GetRandomController : ControllerBase
    {

        [HttpGet]
        public async Task<string> GetRandomDoubleAsync(string minMax) 
        {
            WebRequest request = WebRequest.Create($"http://185.195.26.249:8888/api/GetRandomDouble?minmax={minMax}");
            WebResponse response = await request.GetResponseAsync();
            string rnd;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    rnd = reader.ReadToEnd();
                }
            }
            response.Close();
            UpdateClientListener update = new UpdateClientListener();

            await update.UpadeAsync(rnd);

            return $"{rnd}";
        }

       

    }
}
