using System;
using System.ComponentModel.DataAnnotations;

namespace OrceiPdf.Web.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Required]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }
        public Guid UserId { get; set; }
    }
}
