using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace foiPicadaDeEnfermeiro.Models
{
    public class pessoalMedico
    {
        public string numeroCedulaProfissional { get; set; }

        public string nomeAplido { get; set; }

        public string contactoMovel { get; set; }

        public int numeroIdEspecialidade { get; set; }



        public pessoalMedico(string numeroCedulaProfissional, string nomeAplido, string contactoMovel, int numeroIdEspecialidade)
        //ctor cria construtor prop cria propriedade
        {

            this.numeroCedulaProfissional = numeroCedulaProfissional;
            this.nomeAplido = nomeAplido;
            this.contactoMovel = contactoMovel;
            this.numeroIdEspecialidade = numeroIdEspecialidade;


        }
        public pessoalMedico()
        {

        }

    }  
}
