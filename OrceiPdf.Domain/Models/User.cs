using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace OrceiPdf.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Empresa> Empresas { get; set; }
    }
}
