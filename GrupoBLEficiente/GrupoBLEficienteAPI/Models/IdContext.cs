using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrupoBLEficienteAPI.Models
{
    public class IdContext : IdentityDbContext
    {
        public IdContext(DbContextOptions<IdContext> options)
            : base(options)
        {

        }
    }
}
