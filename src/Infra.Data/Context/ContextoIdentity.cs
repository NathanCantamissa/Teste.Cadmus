using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class ContextoIdentity : IdentityDbContext
    {
        public ContextoIdentity(DbContextOptions<ContextoIdentity> options) : base(options)
        {
        }
    }
}