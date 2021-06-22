using OrceiPdf.Domain.Enum;
using OrceiPdf.Domain.Models;
using System;
using System.Collections;
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
        public Guid ClienteId { get; set; }
        public EOrcamentoStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [CannotBeEmpty(ErrorMessage = "Lista de itens deve conter pelo menos um registro.")]
        public ICollection<OrcamentoItem> OrcamentoItens { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CannotBeEmptyAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IEnumerable;
            return list != null && list.GetEnumerator().MoveNext();
        }
    }
}
