using Microsoft.AspNetCore.Identity;
using OrceiPdf.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrceiPdf.Domain.Models
{
    public class User : IdentityUser<Guid>
    {

    }
}
