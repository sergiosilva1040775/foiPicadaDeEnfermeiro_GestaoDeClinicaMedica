using System;

namespace foiPicadaDeEnfermeiro.Handlers
{
    public class especialidadeMedicaHander
    {


        Models.especialidadeMedica especialidadeMedicaModel = new Models.especialidadeMedica();
        public (int, Models.especialidadeMedica, string mensagemDeErro) ValidarEspecialidadeMedicaInsert(string description)
        {

            if (description.Length == 0) { return (1, null, "Falta  descricao"); }
            else
            {
                especialidadeMedicaModel.description = description.ToUpper();
                return (0, especialidadeMedicaModel, null);

            }

        }
        public (int, Models.especialidadeMedica , string mensagemDeErro) ValidarEspecialidadeMedicaUpdate(string numeroId, string description)
        {

            if (numeroId.Length == 0 || numeroId == "0") { return (1, null, "Select one item to update"); }
            else
            {
                if (description.Length == 0) { return (2, null, "Falta  descricao"); }
                else
                {
                    especialidadeMedicaModel.numeroId = Convert.ToInt32(numeroId);
                    especialidadeMedicaModel.description = description.ToUpper();
                    return (0, especialidadeMedicaModel, null);


                }
            }


        }

        public (int, Models.especialidadeMedica, string mensagemDeErro) ValidarEspecialidadeMedicaDelete(string numeroId )
        {

            if (numeroId.Length == 0 || numeroId == "0") { return (1, null, "Select one item to delete"); }
            else
            {
                especialidadeMedicaModel.numeroId = Convert.ToInt32(numeroId);
                return (0, especialidadeMedicaModel, null);


            }
        }
    }
}
