using BackEndCadastro.Models;
using MeuRH360.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MeuRH360.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DadosViewModel dados = new DadosViewModel();
            return View(dados);
        }

        public IActionResult Passo2()
        {
            return View();
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Passo2(DadosViewModel dados)
        {
            #region objetoEntidade
            ViewBag.NomeUsuario = dados.Pessoa.Nome;

            Usuario p = new Usuario
            {
                Nome = dados.Pessoa.Nome,
                Email = dados.Pessoa.Email,               
                Senha = dados.Pessoa.Senha,
               
            };
            #endregion

            #region PostApi
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:1168/api/pessoa");
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var jsonContent = JsonConvert.SerializeObject(p);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(client.BaseAddress.ToString(), contentString);

            }
            #endregion

            return View(dados);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Save(DadosViewModel dados) 
        {
            #region objetoEntidade
            Usuario userResult = null;

            Usuario m = new Usuario
            {
                Nome = "UBIRAJARA"
                


            };
            #endregion

            #region PostApi
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:1168/api/matriz");
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var jsonContent = JsonConvert.SerializeObject(m);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(client.BaseAddress.ToString(), contentString);
                var data = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode) {

                    userResult = JsonConvert.DeserializeObject<Usuario>(data);
                
                }

                             
               
            }

            //MatrizViewModel empresaviewModel = new MatrizViewModel();

            //DadosViewModel dadosGerais = new DadosViewModel();
            //dadosGerais.Matriz = empresaviewModel;
            #endregion

            return View("DadosMatriz", userResult);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
