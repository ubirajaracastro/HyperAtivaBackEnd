using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCadastro.Models
{
    public class CartaoDetail
    {
        [Key]
        public int CartaoDetalId { get; set; }

        public string NumeroCartao { get; set; }
        public string Identificador { get; set; }
        public string NumeroLote { get; set; }
        public string NumeroCartaoCompleto { get; set; }


    }
}
