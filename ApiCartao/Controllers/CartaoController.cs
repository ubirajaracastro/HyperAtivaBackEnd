using BackEndCadastro.Context;
using BackEndCadastro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRH.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartaoController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCartao(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.tblCartaoDetail.SingleOrDefaultAsync(m => m.NumeroCartao == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostCartao()
        {

            string path = System.IO.Directory.GetCurrentDirectory();           
            string linha = string.Empty;
            int idCartao = 0;

            var listaArquivos = Directory.GetFiles(path + "\\Files");


            foreach (string item in listaArquivos)
            {
               
                try
                {
                    #region ImportFile
                    using (StreamReader sr = new StreamReader(item, Encoding.Default))
                    {
                        CartaoHeader ch = new CartaoHeader();

                        while ((linha = sr.ReadLine()) != null)
                        {
                            //card details

                            if (linha.Substring(0, 1).Equals("C"))
                            {

                                CartaoDetail cdt = new CartaoDetail();

                                cdt.NumeroCartao = idCartao.ToString();
                                cdt.Identificador = linha.Substring(0, 6).Trim();
                                cdt.NumeroLote = linha.Substring(7, 5);
                                cdt.NumeroCartaoCompleto = linha.Substring(12, 11).Trim();

                                _context.tblCartaoDetail.Add(cdt);
                                _context.SaveChanges();

                            }
                            else
                            {
                                ch.Nome = linha.Substring(0, 28).Trim();
                                ch.Data = linha.Substring(29, 8).Trim();
                                ch.Lote = linha.Substring(37, 9).Trim();
                                ch.QtdeRegistros = Int32.Parse(linha.Substring(45, 6).Trim());

                                AppDbContext contexto = new AppDbContext();
                                contexto.tblCartao.Add(ch);

                                contexto.SaveChanges();
                                idCartao = ch.CartaoId;

                                contexto.Dispose();

                            }

                            //transacao.Commit();


                            if (linha.Substring(0, 3).Equals("LOTE"))
                                return Ok();
                        }                        
                    }
                    #endregion

                }


                catch (Exception ex)
                {
                    //transacao.Rollback();

                }

                finally
                {

                    _context.Dispose();
                }
            }

            return Ok();
        }


        private bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
