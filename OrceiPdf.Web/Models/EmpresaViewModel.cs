using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrceiPdf.Web.Models
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
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
