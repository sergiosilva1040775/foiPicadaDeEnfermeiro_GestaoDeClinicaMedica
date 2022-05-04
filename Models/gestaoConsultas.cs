using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace foiPicadaDeEnfermeiro.Models
{
    public class gestaoConsulta
    {

        public int numeroIdConsulta { get; set; }

        public DateTime dataHora { get; set; }
  
        public string numeroIdMedico { get; set; }

        public string numeroIdPaciente { get; set; }



        public gestaoConsulta(int numeroIdConsulta, DateTime dataHora, string numeroIdMedico, string numeroIdPaciente)
        //ctor cria construtor prop cria propriedade
        {

            this.numeroIdConsulta = numeroIdConsulta;
            this.dataHora = dataHora;            
            this.numeroIdMedico = numeroIdMedico;
            this.numeroIdPaciente = numeroIdPaciente;


        }

        public gestaoConsulta()
        {

        }

    }  
}
