using OrceiPdf.Domain.Enum;
using System;
using System.Collections.Generic;

namespace OrceiPdf.Domain.Models
{
    public class Orcamento : BaseEntity
    {
        public int Numero { get; set; }
        public string Observacao { get; set; }
        public DateTime DataValidade { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }        
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public EOrcamentoStatus Status { get; set; }
        public ICollection<OrcamentoItem> OrcamentoItens { get; set; }
    }
}
