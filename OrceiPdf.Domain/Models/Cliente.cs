using System;
using System.Collections.Generic;

namespace OrceiPdf.Domain.Models
{
    public class Cliente : BaseEntity
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cnpj { get; set; }
        public string Logo { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Orcamento> Orcamentos { get; set; }
    }
}
