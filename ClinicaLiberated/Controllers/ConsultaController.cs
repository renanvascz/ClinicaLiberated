using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaLiberated.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        //Método Http que retorne os pacientes atendidos hoje (nome)
        [HttpGet("atendidosHoje")]
        public List<string> pacientesAtendidosHoje()
        {
            //A lógica para retornar os nomes dos pacientes (pelo menos 3)
            List<string> pacienteAtendidosHoje = new List<string>();
            pacienteAtendidosHoje = ["Giovanni", "Ricardo", "Sergio"];
            return pacienteAtendidosHoje;
        }
    }
}