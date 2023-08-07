using System.ComponentModel.DataAnnotations;

namespace MeuRH360.Web.Models
{
    public class PessoaViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome Completo.")]
        [Display(Name = "Nome Completo")]       
        public string Nome { get; set; }


        [Required(ErrorMessage = "Preeencha o campo email.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha.")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "Preencha o campo Confirmação de senha.")]
        [Display(Name = "Confirmação de senha")]
        [Compare("Senha")]
        public string Confirmacao { get; set; }

        [Display(Name = "")]
        public bool AceitoContrato { get; set; }

    }
}
