using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2019MD601_NUMERO_CARNET2.Models
{
    public class comentariosContext : DbContext
    {

        public comentariosContext(DbContextOptions<comentariosContext> options) : base(options)
        {


        }
        public DbSet<calificaciones> calificaciones { get; set; }

    }
}
