using ClinicaLiberated.Models;

namespace ClinicaLiberated.DTOs
{
    public class AgendamentoDTO
    {
        public PacienteModel? paciente { get; set; }
        public MedicoModel? medico { get; set; }
        public DateTime dataHoraAgendamento {  get; set; }
    }
}
