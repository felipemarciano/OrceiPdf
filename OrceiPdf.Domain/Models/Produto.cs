using System;
using System.Collections.Generic;

namespace OrceiPdf.Domain.Models
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public double ValorUnitario { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrcamentoItem> OrcamentoItens { get; set; }
    }
}
