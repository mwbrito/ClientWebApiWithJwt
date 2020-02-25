using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClientWebApi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Net.Http.Headers;

namespace ClientWebApi.Controllers
{
    public class HomeController : Controller{
        public async Task<IActionResult> Index(){

            //by-pass invalid certification error
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            LoginResponse responseObject = new LoginResponse();
            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                using (var response = client.PostAsync("https://localhost:5001/v1/account/login", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            username = "burns.montgomery",
                            password = "burn"
                        }), Encoding.UTF8, "application/json")).Result)
                {                    
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseObject = JsonConvert.DeserializeObject<LoginResponse>(apiResponse);
                }
            }
            return View(responseObject);
        }

        public async Task<IActionResult> Authenticated([FromForm]string token)
        {
            AuthenticatedViewModel responseModel = new AuthenticatedViewModel();

            //by-pass invalid certification error
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await client.GetAsync("https://localhost:5001/v1/account/authenticated"))
                {                    
                    responseModel.response = await response.Content.ReadAsStringAsync();
                }
            }

            return View(responseModel);
        }
    }
}
