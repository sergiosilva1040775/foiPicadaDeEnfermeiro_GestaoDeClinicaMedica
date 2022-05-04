using System;

namespace foiPicadaDeEnfermeiro.Models
{
    public class gestaoConsultasPlus
    {

        public int numeroIdConsulta { get; }

        public DateTime dataHora { get; }

        public string numeroIdMedico { get; }

        public string numeroIdPaciente { get; }
        public string nomeMedico { get; }
        public string nomeCliente { get; }




        public gestaoConsultasPlus(int numeroIdConsulta, DateTime dataHora, string numeroIdMedico, string numeroIdPaciente, string nomeMedico, string nomeCliente)
        //ctor cria construtor prop cria propriedade
        {

            this.numeroIdConsulta = numeroIdConsulta;
            this.dataHora = dataHora;
            this.numeroIdMedico = numeroIdMedico;
            this.numeroIdPaciente = numeroIdPaciente;
            this.nomeMedico = nomeMedico;
            this.nomeCliente = nomeCliente;


        }
        public gestaoConsultasPlus()
        {

        }

    }
}
