using System.ComponentModel.DataAnnotations;
namespace L01_2019MD601_NUMERO_CARNET2.Models
{
    public class calificaciones
    {

        [Key]
        public int calificacionId { get; set; }
        public int? publicacionId { get; set; }
        public int? usuarioId { get; set; }
        public int? calificacion { get; set; }
    }
}
