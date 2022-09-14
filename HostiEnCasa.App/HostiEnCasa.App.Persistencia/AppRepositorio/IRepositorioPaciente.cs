using System;
using System.Collections.Generic;
using System.Linq;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        int UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);    
        Paciente GetPaciente(int idPaciente);
        Medico AsignarMedico(int idPaciente, int idMedico);
        Paciente GetPacienteAll(int idPaciente);
        List<Paciente> GetPacienteSignoFrecuencia();
        List<SignoVital> GetSignosPaciente(int idPaciente);
    }

}