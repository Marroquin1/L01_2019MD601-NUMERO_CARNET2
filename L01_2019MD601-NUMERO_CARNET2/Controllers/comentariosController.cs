using L01_2019MD601_NUMERO_CARNET2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L01_2019MD601_NUMERO_CARNET2.Propierties
{
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase
    {
        private readonly comentariosContext _comentariosContexto;

        public comentariosController(comentariosContext comentariosContexto)
        {
            _comentariosContexto = comentariosContexto;
        }
    }
}
