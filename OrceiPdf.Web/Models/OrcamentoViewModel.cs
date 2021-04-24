using OrceiPdf.Domain.Enum;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrceiPdf.Web.Models
{
    public class OrcamentoViewModel
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string Observacao { get; set; }
        public DateTime DataValidade { get; set; }
        public Guid EmpresaId { get; set; }
        public EOrcamentoStatus Status { get; set; }
        public ICollection<OrcamentoItem> OrcamentoItens { get; set; }
    }
}
