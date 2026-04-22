using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinicaLiberated.DTOs;

namespace ClinicaLiberated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        public static List<AgendamentoModel> listaDeAgendamentos = new List<AgendamentoModel>();
        [HttpPost("agendarconsulta")]
        public async Task<IActionResult> AgendarConsulta([FromBody] AgendamentoDTO dadosAgendamento)
        {
            try
            {
                AgendamentoModel agendamento = new AgendamentoModel();
                agendamento.nomePaciente = dadosAgendamento.paciente?.nomeCompleto;
                agendamento.telefonePaciente = dadosAgendamento.paciente?.telefone;
                agendamento.cpfPaciente = dadosAgendamento.paciente?.cpf;
                agendamento.nomeMedico = dadosAgendamento.medico?.nomeCompleto;
                agendamento.crmMedico = dadosAgendamento.medico?.crm;
                agendamento.especialidadeMedico = dadosAgendamento.medico?.especialidade;
                agendamento.dataHoraAgendamento = dadosAgendamento.dataHoraAgendamento;

                listaDeAgendamentos.Add(agendamento);
                return Created();

            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }
    }
}