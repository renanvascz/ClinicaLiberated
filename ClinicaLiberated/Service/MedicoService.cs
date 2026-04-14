using ClinicaLiberated.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaLiberated.Service
{
    public class MedicoService
    {
        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();

        //MÉTODOS
        public MedicoModel? editarMedico(MedicoModel medicoEditado, string crm)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm == crm)
                {
                    medico.crm = medicoEditado.crm;
                    medico.nomeCompleto = medicoEditado.nomeCompleto;
                    medico.telefone = medicoEditado.telefone;
                    medico.email = medicoEditado.email;
                    medico.dataNascimento = medicoEditado.dataNascimento;
                    return medico;

                }
            }
            return null;
        }
    }
   
}
