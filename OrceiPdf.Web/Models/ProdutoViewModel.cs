using System;
using System.ComponentModel.DataAnnotations;

namespace OrceiPdf.Web.Models
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Unidade de Medida")]
        public string UnidadeMedida { get; set; }
        [Required]
        [Display(Name = "Valor Unitário")]
        [DataType(DataType.Currency)]
        public double ValorUnitario { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
