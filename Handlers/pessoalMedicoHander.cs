using System;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro.Handlers
{
    public class pessoalMedicoHander
    {
        Models.pessoalMedico pessoalMedicoModel = new Models.pessoalMedico();
        public (int, Models.pessoalMedico, string mensagemDeErro) ValidarPessoalMedicoInsert(string numeroCedulaProfissional, string nomeAplido, string contactoMovel, string numeroIdEspecialidade)
        {
            
          
            if (numeroCedulaProfissional.Length == 0 ) { return (1, null, "Falta  numero Cedula Profissional"); }
            else
            {
                if (nomeAplido.Length == 0) { return (2, null, "Falta  Nome Aplido"); }
                else
                {
                    if (contactoMovel.Length == 0) { return (3, null, "Falta  Contacto Móvel"); }
                    else
                    {

                        if ( numeroIdEspecialidade.ToString() == "-1" ) { return (4, null, "Falta  especialidade"); }
                        else
                        {
                            pessoalMedicoModel.numeroCedulaProfissional = numeroCedulaProfissional;
                            pessoalMedicoModel.nomeAplido = nomeAplido.ToUpper();
                            pessoalMedicoModel.contactoMovel = contactoMovel.ToUpper();
                            pessoalMedicoModel.numeroIdEspecialidade = Convert.ToInt16(numeroIdEspecialidade);
                            return (0, pessoalMedicoModel, null);

                        }
                    }
                }
            }
        }
        public (int, Models.pessoalMedico, string mensagemDeErro) ValidarPessoalMedicoUpdate(string numeroCedulaProfissional, string nomeAplido, string contactoMovel, string numeroIdEspecialidade)
        {
            
           
            if (numeroCedulaProfissional.Length == 0 ) { return (1, null, "Falta  numero Cedula Profissional"); }
            else
            {
                if (nomeAplido.Length == 0) { return (2, null, "Falta  Nome Aplido"); }
                else
                {
                    if (contactoMovel.Length == 0) { return (1, null, "Falta  Contacto Móvel"); }
                    else
                    {

                        if ( numeroIdEspecialidade.ToString() == "-1" ) { return (1, null, "Falta  especialidade"); }
                        else
                        {                        
                            pessoalMedicoModel.numeroCedulaProfissional =  numeroCedulaProfissional;
                            pessoalMedicoModel.nomeAplido = nomeAplido.ToUpper();
                            pessoalMedicoModel.contactoMovel = contactoMovel.ToUpper();
                            pessoalMedicoModel.numeroIdEspecialidade = Convert.ToInt16 ( numeroIdEspecialidade);
                            return (0, pessoalMedicoModel, null);
                        }
                    }
                }
            }

        }

        public (int, Models.pessoalMedico, string mensagemDeErro) ValidarPessoalMedicoDelete(string numeroCedulaProfissional)
        {
            
            if (numeroCedulaProfissional.Length == 0 ) { return (1, null, "Falta  item a eliminar"); }
            else
            {
                pessoalMedicoModel.numeroCedulaProfissional = numeroCedulaProfissional;
                return (0, pessoalMedicoModel, null);
            }
        }

        public (int, Models.pessoalMedico, string mensagemDeErro) ValidarPessoalMedicoPesquisaEspecialidade(string numeroIdEspecialidade)
        {
           if (numeroIdEspecialidade == "-1") { return (1, null, "Falta  item a pesquisar"); }
            else
            {
                pessoalMedicoModel.numeroIdEspecialidade = Convert.ToInt16( numeroIdEspecialidade);
                return (0, pessoalMedicoModel, null);
            }
        }
    }
}
