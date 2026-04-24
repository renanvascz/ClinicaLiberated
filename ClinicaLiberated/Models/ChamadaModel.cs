namespace ClinicaLiberated.Models
{
    public class ChamadaModel
    {
        public string? Id { get; set; }
        public string? nomePaciente { get; set; }
        public string? SalaConsultorio { get; set; }
        public List<string> chamadaPaciente = new List<string>();
    }
}