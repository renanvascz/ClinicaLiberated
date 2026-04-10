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
        private IEnumerable<object> listaMedico;

        [HttpPost("cadastroMedico")]
        public string cadastroMedico([FromBody] MedicoModel medico)
        {
            listaMedicos.Add(medico);
            return $"Dr. {medico.nomeCompleto} cadastrado com sucesso";
        }

        //listar os médicos
        [HttpGet("listaMedicos")]
        public List<MedicoModel>listarMedicos()
        {
            return listaMedicos;          
        }

        //editar médico
        //public List<MedicoModel>

        [HttpPut("editarMedico/{id}")]
        public string editarMedico([FromBody] MedicoModel medicoEditado, string id)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm == id)
                {
                    medico.crm = medicoEditado.crm;
                    medico.nomeCompleto = medicoEditado.nomeCompleto;
                    medico.telefone = medicoEditado.telefone;
                    medico.email = medicoEditado.email;
                    medico.dataNascimento = medicoEditado.dataNascimento;
                    return $"Medico {medico.nomeCompleto}, crm anterior: {id} editado com sucesso";

                }
            }
            return "Paciente não encontrado.";
        }


        //buscar médico

        [HttpGet("buscarMedico/{id}")]
        public MedicoModel? buscarMedico(string id)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm == id)
                {
                    return medico;
                }
            }
            return null;
        }

        //excluir médico
        [HttpDelete("deletarMedico/{id}")]
        public string? deletarMedico (string id)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm == id)
                {
                    listaMedicos.Remove(medico);
                    return $"Medico: {id} deletado com sucesso";
                }
            }
            return "Medico não encontrado";
        }


    }
}