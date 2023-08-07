using BackEndCadastro.Context;
using BackEndCadastro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Util;

namespace BackEndCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usuario  
        [HttpGet]
        [Authorize]
        public IEnumerable<Usuario> GetUsuario()
        {
            var pessoas =  _context.tblUsuario;

            return pessoas;
        }

        // GET: api/Pessoa/5  
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUsuario(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.tblUsuario.SingleOrDefaultAsync(m => m.UsuarioId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Pessoa/5  
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] Usuario pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoa.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pessoa  
        [HttpPost]       
        public async Task<IActionResult> PostUsuario(Usuario pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string dataToProtect = pessoa.Senha;
            var key = new byte[] { 12, 2, 56, 117, 12, 67, 33, 23, 12, 2, 56, 117, 12, 67, 33, 23 };

            var Encrypt = new EncryptDecrypt(key);
            string base64EncryptString = Encrypt.Encrypt(dataToProtect);

            pessoa.Senha = base64EncryptString;

            _context.tblUsuario.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.UsuarioId }, pessoa);
        }

        // DELETE: api/Pessoa/5  
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.tblUsuario.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.tblUsuario.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool UsuarioExiste(int id)
        {
            return _context.tblUsuario.Any(e => e.UsuarioId == id);
        }
    }


}
