using System.Collections.Generic;

namespace OrceiPdf.Domain.Models
{
    public class GridResult<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int CountTotal { get; set; }
    }
}
