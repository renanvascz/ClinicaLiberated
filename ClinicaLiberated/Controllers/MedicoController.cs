using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClinicaLiberated.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();
        [HttpPost("cadastroMedico")]
        public string cadastroMedico([FromBody] string nomeMedico)
        {
            MedicoModel medicoCadastro = new MedicoModel();
            medicoCadastro.nome = nomeMedico;
            listaMedicos.Add(medicoCadastro);
            return $"Dr. {nomeMedico} Cadastro com sucesso";
        }
    }
}