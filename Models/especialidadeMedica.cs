using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foiPicadaDeEnfermeiro.Models
{
    public class especialidadeMedica
    {
        public int numeroId { get; set; }

        public string description { get; set; }





        public especialidadeMedica(int numeroId, string description )
        //ctor cria construtor prop cria propriedade
        {

            this.numeroId = numeroId;
            this.description = description;
            

        }
        public especialidadeMedica()
        {

        }
    }
}
