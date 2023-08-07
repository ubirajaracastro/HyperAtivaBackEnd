using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuRH360.Web.Models
{
    public class MatrizViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome da empresa.")]
        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }

        
        [Display(Name = "Tipo de Empresa")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ da empresa.")]
        [Display(Name = "CNPJ da Empresa")]
        public string CNPJ { get; set; }
               
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }

        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo celular da empresa.")]       
        public string Celular { get; set; }


        [Required(ErrorMessage = "Preencha o campo Nome do Administrador da empresa.")]
        public string NomeAdm { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF do Administrador da empresa.")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "Preencha o campo Email do Administrador da empresa.")]
        public string Email { get; set; }




    }
}
