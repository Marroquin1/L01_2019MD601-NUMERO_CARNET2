using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2019MD601_NUMERO_CARNET2.Models
{
    public class usuariosContext : DbContext
    {
        public usuariosContext(DbContextOptions<usuariosContext> options) : base(options)
        {


        }
        public DbSet<usuarios> usuarios { get; set; }
    }
}