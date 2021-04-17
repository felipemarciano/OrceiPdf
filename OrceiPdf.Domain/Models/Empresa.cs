using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Models
{
    public class Empresa : BaseEntity
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cnpj { get; set; }
        public string Logo { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
