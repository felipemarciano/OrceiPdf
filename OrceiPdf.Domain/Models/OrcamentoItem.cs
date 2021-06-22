using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrceiPdf.Domain.Models
{
    public class OrcamentoItem : BaseEntity
    {
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal ValorUnitario { get; set; }
        public Guid OrcamentoId { get; set; } 
        public Orcamento Orcamento { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
