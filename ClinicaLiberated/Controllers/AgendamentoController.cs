using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinicaLiberated.DTOs;
using ClinicaLiberated.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ClinicaLiberated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private ClinicaContext _context;

        public AgendamentoController(ClinicaContext context)
        {
            _context = context;
        }

        public static List<AgendamentoModel> listaDeAgendamentos = new List<AgendamentoModel>();
        [HttpPost("agendarconsulta")]
        public async Task<IActionResult> AgendarConsulta([FromBody] AgendamentoDTO dadosAgendamento)
        {
            try
            {   
                
                AgendamentoModel agendamento = new AgendamentoModel();
                agendamento.id = dadosAgendamento.id;
                agendamento.dataHoraAgendamento = dadosAgendamento.dataHoraAgendada;
                agendamento.crmMedico = dadosAgendamento.crmMedico;
                agendamento.cpfPaciente = dadosAgendamento.cpfPaciente;

                await _context.Agendamentos.AddAsync(agendamento);
                _context.SaveChanges();

                return Created();

            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }
        [HttpGet("buscarAgendamentos")]
        public async Task <IActionResult> BuscarAgendementos() 
        {
            try
            {
                var listaAgendamentos = await _context.Agendamentos.Include(p => p.paciente).Include(m => m.medico).ToListAsync();
                return Ok(listaAgendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro. " + ex.Message);
            }
        }
    }
}