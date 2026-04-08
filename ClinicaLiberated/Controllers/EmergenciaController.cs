using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaLiberated.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmergenciaController : Controller
    {

        [HttpGet("retornoCasa")]
        public string casa()
        {
            return "casa";
        }

        [HttpGet("nomePaciente")]

        public string paciente()
        {
            string nome = "Giovanni";
            return "Paciente: " + nome;
        }
        [HttpGet("listaPacientes")]
        public List<string> listaNome()
        {
            List <string> listaPacientes = new List<string>();
            listaPacientes = ["Giovanni", "Carlos", "Pedro"];
            return listaPacientes;
        }
        [HttpGet("pacientes")]
        public List<PacienteModel> ListaPaciente()
        {
            PacienteModel novoPaciente = new PacienteModel("1019210", "Giovanni", "10/04/1999", "Vermelha");
            List<PacienteModel> listaPaciente = new List<PacienteModel>();
            listaPaciente.Add(novoPaciente);
            novoPaciente = new PacienteModel("1020220", "Eduarda","15/03/1990","Verde");
            listaPaciente.Add(novoPaciente);
            return listaPaciente;

        }

    }
}
