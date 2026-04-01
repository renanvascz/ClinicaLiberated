namespace ClinicaLiberated.Models
{
    public class Paciente
    {
        public string? nomeCompleto {  get; set; }
        public string? email { get; set; }
        public string? endereco { get; set; }
        public string? prioridade { get; set; }
        public string? cpf {  get; set; }
        public string? telefone { get; set; }
        public string? dataNascimento {  get; set; }

        public Paciente(string? cpf, string? nomecompleto, string? prioridade, string? dataNascimento)
        {
            this.cpf = cpf;
            this.nomeCompleto = nomecompleto;
            this.dataNascimento = dataNascimento;
            this.prioridade = prioridade;
        }
    }
}
