using System;

namespace foiPicadaDeEnfermeiro.Handlers
{
    public class clientePacienteHander
    {


        Models.clientePaciente clientePacienteModel = new Models.clientePaciente();
        public (int, Models.clientePaciente, string mensagemDeErro) ValidarClientePacienteInsert(string numeroNIF, string nomeAplido, string contactoMovel, string numeroSNS)
        {

            if (numeroNIF.Length == 0) { return (1, null, "Falta  numero NIF"); }
            else
            {
                if (nomeAplido.Length == 0) { return (2, null, "Falta  Nome Aplido"); }
                else
                {
                    if (contactoMovel.Length == 0) { return (3, null, "Falta  Contacto Móvel"); }
                    else
                    {

                        if (numeroSNS.Length == 0) { return (4, null, "Falta  numero SNS"); }
                        else
                        {
                            clientePacienteModel.numeroNIF = numeroNIF;
                            clientePacienteModel.nomeAplido = nomeAplido.ToUpper();
                            clientePacienteModel.contactoMovel = contactoMovel.ToUpper();
                            clientePacienteModel.numeroSNS = numeroSNS;
                            return (0, clientePacienteModel, null);

                        }
                    }
                }
            }

        }
        public (int, Models.clientePaciente, string mensagemDeErro) ValidarClientePacienteUpdate(string numeroNIF, string nomeAplido, string contactoMovel, string numeroSNS)
        {

            if (numeroNIF.Length == 0) { return (1, null, "Falta  numero NIF"); }
            else
            {
                if (nomeAplido.Length == 0) { return (2, null, "Falta  Nome Aplido"); }
                else
                {
                    if (contactoMovel.Length == 0) { return (3, null, "Falta  Contacto Móvel"); }
                    else
                    {

                        if (numeroSNS.Length == 0) { return (4, null, "Falta  numero SNS"); }
                        else
                        {
                            clientePacienteModel.numeroNIF = numeroNIF;
                            clientePacienteModel.nomeAplido = nomeAplido.ToUpper();
                            clientePacienteModel.contactoMovel = contactoMovel.ToUpper();
                            clientePacienteModel.numeroSNS = numeroSNS;
                            return (0, clientePacienteModel, null);

                        }
                    }
                }
            }

        }

        public (int, Models.clientePaciente, string mensagemDeErro) VValidarClientePacienteDelete(string numeroId )
        {

            if (numeroId.Length == 0 || numeroId == "0") { return (1, null, "Select one item to delete"); }
            else
            {
                clientePacienteModel.numeroNIF =              numeroId;
                return (0, clientePacienteModel, null);


            }
        }
    }
}
