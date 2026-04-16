using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaLiberated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiViaCepController : ControllerBase
    {
        [HttpGet("{cep}")]
        public async Task<IActionResult> BuscaEndereco(string cep)
        {
            if (cep.Length != 8)
            {
                return BadRequest("Cep dev conter 8 dígitos");
            }
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<ViaCepModel>();
                    if (content.cep == null)
                    {
                        return NotFound("Cep Não Encontrado.");
                    }
                    return Ok(content);
                }
                else
                {
                    return NotFound("CEP não encontrado.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Erro no serviço: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro Inesperado: " + ex.Message);
            }
            return BadRequest();
        }
    }
}

