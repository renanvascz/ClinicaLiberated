using ClinicaLiberated.Data;
using ClinicaLiberated.Models;
using ClinicaLiberated.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClinicaLiberated.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();
        private ClinicaContext _context;

        public MedicoController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpPost("cadastroMedico")]
        public async Task<IActionResult> CadastrarMedico([FromBody] MedicoModel MedicoCadastrado)
        {
            try
            {
                _context.Add(MedicoCadastrado);
                _context.SaveChanges();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
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
        public async Task<IActionResult> editarMedico([FromBody] MedicoModel medicoEditado, string crm)
        {
            try
            {
                _context.Medicos.Update(medicoEditado);
                await _context.SaveChangesAsync();
                return Ok(medicoEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //buscar médico

        [HttpGet("buscarMedico/{id}")]
        public async Task<IActionResult> buscarMedico(string crm)
        {
            try
            {
                MedicoModel? MedicoEncontrado = await _context.Medicos.FindAsync(crm);
                return Ok(MedicoEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //excluir médico
        [HttpDelete("deletarMedico/{cpf}")]
        public async Task<ActionResult> deletarMedico (string crm)
        {
            try
            {
                MedicoModel? MedicoEncontrado = await _context.Medicos.FindAsync(crm);

                if (MedicoEncontrado != null)
                {
                    _context.Medicos.Remove(MedicoEncontrado);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    throw new Exception($"Medico de CPF: {crm} não existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro. " + ex.Message);
            }
        }


    }
}