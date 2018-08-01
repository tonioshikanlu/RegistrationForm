using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class MvcRegisterContext : DbContext
    {
        public MvcRegisterContext (DbContextOptions<MvcRegisterContext> options)
            : base(options)
        {
        }

        public DbSet<Identity.Models.MvcRegister> Registers { get; set; }

    }

}
