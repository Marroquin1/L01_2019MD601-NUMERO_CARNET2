using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2019MD601_NUMERO_CARNET2.Models
{
    public class calificacionesContext : DbContext
    {

        public calificacionesContext(DbContextOptions<calificacionesContext> options) : base(options)
        {


        }
        public DbSet<calificaciones> calificaciones { get; set; }

    }
}
