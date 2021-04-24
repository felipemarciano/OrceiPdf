using System;

namespace OrceiPdf.Domain.Models
{
    public class OrcamentoItem : BaseEntity
    {
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }
        public Guid OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
