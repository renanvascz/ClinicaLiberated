using ClinicaLiberated.Models;
using ClinicaLiberated.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClinicaLiberated.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();
        private IEnumerable<object>? listaMedico;

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

        [HttpPut("editarMedico/{crm}")]
        public string editarMedico([FromBody] MedicoModel medicoEditado, string crm)
        {
            MedicoService medico = new MedicoService();
            medico.editarMedico(medicoEditado, crm);
            {
                if (medico == null)
                {
                    return "Médico não encontrado";
                }
                else
                {
                    return $"Médico de CRM N° {crm} editado com sucesso";
                }
            }    
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