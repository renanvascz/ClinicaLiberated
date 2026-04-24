using ClinicaLiberated.Data;
using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaLiberated.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        public static List<PacienteModel> listaPaciente = new List<PacienteModel>();

        private ClinicaContext _context;

        public PacienteController(ClinicaContext context) 
        { 
            _context = context;
        }

        [HttpPost("CadastrarPaciente")]
        public async Task<IActionResult> CadastrarPaciente([FromBody] PacienteModel pacienteCadastrado)
        {
            try
            {   
                _context.Add(pacienteCadastrado);
                _context.SaveChanges();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }


        [HttpGet("listaPacientes")]
        public List<PacienteModel> listarPaciente()
        {
            return listaPaciente;
        }

        [HttpGet("buscaPaciente/{cpf}")]
        public async Task<IActionResult> buscarPaciente(string cpf)     
        {
            try
            {
                PacienteModel? pacienteEncontrado = await _context.Pacientes.FindAsync(cpf);
                return Ok(pacienteEncontrado);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("editarPaciente/{cpf}")]
        public async Task<IActionResult> editarPaciente([FromBody] PacienteModel pacienteEditado, string cpf)
        {
            try
            {
                _context.Pacientes.Update(pacienteEditado);
                await _context.SaveChangesAsync();
                return Ok(pacienteEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletarPaciente/{cpf}")]
        public async Task<ActionResult> deletarPaciente(string cpf)
        {
            try
            {
                PacienteModel? pacienteEncontrado = await _context.Pacientes.FindAsync(cpf);

                if (pacienteEncontrado != null)
                {
                    _context.Pacientes.Remove(pacienteEncontrado);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    throw new Exception($"Paciente de CPF: {cpf} não existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro. " + ex.Message);
            }
     
        }

    }
}
