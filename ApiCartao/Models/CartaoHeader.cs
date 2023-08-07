using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCadastro.Models
{
    public class CartaoHeader
    {
        public int CartaoId { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Lote { get; set; }
        public int QtdeRegistros { get; set; }
        
    }
}
