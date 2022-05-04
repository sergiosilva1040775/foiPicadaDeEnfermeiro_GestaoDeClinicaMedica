using System;

namespace foiPicadaDeEnfermeiro.Handlers
{
    public class gestaoConsultaHander
    {
        Models.gestaoConsulta gestaoConsultaoModel = new Models.gestaoConsulta();
        public (int, Models.gestaoConsulta, string mensagemDeErro) ValidarGestaoConsultaInsert(string dataHora, string numeroIdMedico, string numeroIdPaciente)
        {
            DateTime dataHoraOut;


            if (!DateTime.TryParse(dataHora, out dataHoraOut)) { return (1, null, "Falta dataHora"); }
            else
            {
                if (numeroIdMedico.Length == 0 || numeroIdMedico == "-1") { return (2, null, "Falta  a indicação do medico"); }
                else
                {
                    if (numeroIdPaciente.Length == 0 || numeroIdPaciente == "-1") { return (3, null, "Falta a indicação do paciencia"); }
                    else
                    {


                        gestaoConsultaoModel.dataHora = dataHoraOut;
                        gestaoConsultaoModel.numeroIdMedico = numeroIdMedico;
                        gestaoConsultaoModel.numeroIdPaciente = numeroIdPaciente;

                        return (0, gestaoConsultaoModel, null);


                    }
                }
            }
        }
        public (int, Models.gestaoConsulta, string mensagemDeErro) ValidarGestaoConsultaUpdate(string numeroIdConsulta, string dataHora, string numeroIdMedico, string numeroIdPaciente)
        {


            DateTime dataHoraOut;


            if (!DateTime.TryParse(dataHora, out dataHoraOut)) { return (1, null, "Falta dataHora"); }
            else
            {
                if (numeroIdMedico.Length == 0 || numeroIdMedico == "-1") { return (2, null, "Falta  a indicação do medico"); }
                else
                {
                    if (numeroIdPaciente.Length == 0 || numeroIdPaciente == "-1") { return (3, null, "Falta a indicação do paciencia"); }
                    else
                    {
                        if (numeroIdConsulta.Length == 0) { return (4, null, "Falta a indicação da consulta a realizar"); }
                        else
                        {
                            gestaoConsultaoModel.numeroIdConsulta = Convert.ToInt32(numeroIdConsulta);
                            gestaoConsultaoModel.dataHora = dataHoraOut;
                            gestaoConsultaoModel.numeroIdMedico = numeroIdMedico;
                            gestaoConsultaoModel.numeroIdPaciente = numeroIdPaciente;

                            return (0, gestaoConsultaoModel, null);

                        }
                    }
                }
            }

        }

        public (int, Models.gestaoConsulta, string mensagemDeErro) ValidarGestaoConsultaoDelete(string numeroIdConsulta)
        {

            if (numeroIdConsulta.Length == 0) { return (1, null, "Falta  item a eliminar"); }
            else
            {
                gestaoConsultaoModel.numeroIdConsulta = Convert.ToInt16(numeroIdConsulta);
                return (0, gestaoConsultaoModel, null);
            }
        }

    }
}
