using System.ComponentModel.DataAnnotations;

namespace ClinicaLiberated.Models
{
    public class PacienteModel
    {   
        public string? nomeCompleto {  get; set; }
        public string? email { get; set; }
        public string? endereco { get; set; }
        [Key] public string? cpf {  get; set; }
        public string? telefone { get; set; }
        public string? dataNascimento {  get; set; }

 
    }
}
