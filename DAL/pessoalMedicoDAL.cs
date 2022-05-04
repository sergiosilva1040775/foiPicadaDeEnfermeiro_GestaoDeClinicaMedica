using foiPicadaDeEnfermeiro.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace foiPicadaDeEnfermeiro.DAL
{
    public class pessoalMedicoDAL


    {
        private string connStr = BaseDAL.connStr;

        public (int registo, string erro) inserirPessoalMedico(pessoalMedico pessoalMedicos)
        {
            int registo = 0;
            if (!RefExiste(pessoalMedicos.numeroCedulaProfissional))
            {
                string query = "INSERT INTO pessoalmedico (numeroCedulaProfissional, nomeAplido, contactoMovel, numeroIdEspecialidade)" +
                                               "VALUES(@numeroCedulaProfissional, @nomeAplido, @contactoMovel, @numeroIdEspecialidade)";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroCedulaProfissional", pessoalMedicos.numeroCedulaProfissional);
                        cmd.Parameters.AddWithValue("@nomeAplido", pessoalMedicos.nomeAplido);
                        cmd.Parameters.AddWithValue("@contactoMovel", pessoalMedicos.contactoMovel);
                        cmd.Parameters.AddWithValue("@numeroIdEspecialidade", pessoalMedicos.numeroIdEspecialidade);

                        try
                        {
                            registo = cmd.ExecuteNonQuery();
                            return (registo, null);
                        }
                        catch (Exception e)
                        {
                            return (0, e.Message.ToString());
                        }
                    }
                }
            }
            else
            {
                return (0, "Já exsite número da celula profissional");
            }

        }

        public List<pessoalMedico> listarPessoalMedico()
        {
            List<pessoalMedico> ListarPessoalMedicos = new List<pessoalMedico>();

            string query = "SELECT * FROM pessoalmedico";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    //cmd.Connection = conn;
                    conn.Open();

                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {

                                ListarPessoalMedicos.Add(new pessoalMedico(
                                    sdr["numeroCedulaProfissional"].ToString(),
                                    sdr["nomeAplido"].ToString(),
                                     sdr["contactoMovel"].ToString(),
                                     Int32.Parse(sdr["numeroIdEspecialidade"].ToString())
                                    ));
                            }
                        }
                    }
                }
            }
            return ListarPessoalMedicos;
        }

        public List<pessoalMedico> listarPessoalMedicoByEspecialidade(pessoalMedico pessoalMedicos)
        {
            List<pessoalMedico> ListarPessoalMedicos = new List<pessoalMedico>();

            string query = "SELECT * FROM pessoalmedico where numeroIdEspecialidade = @numeroIdEspecialidade";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    //cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@numeroIdEspecialidade", pessoalMedicos.numeroIdEspecialidade);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                // MessageBox.Show(pessoalMedicos.numeroIdEspecialidade.ToString());
                                ListarPessoalMedicos.Add(new pessoalMedico(
                                    sdr["numeroCedulaProfissional"].ToString(),
                                    sdr["nomeAplido"].ToString(),
                                     sdr["contactoMovel"].ToString(),
                                     Int32.Parse(sdr["numeroIdEspecialidade"].ToString())
                                    ));
                            }
                        }
                    }
                }
            }
            return ListarPessoalMedicos;
        }

        public string listarPessoalMedicoById(string numeroCedulaProfissional)
        {
            string id = "0";
            List<pessoalMedico> ListarPessoalMedicos = new List<pessoalMedico>();

            string query = "SELECT * FROM pessoalmedico where numeroCedulaProfissional = @numeroCedulaProfissional";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    //cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@numeroCedulaProfissional", numeroCedulaProfissional);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {

                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {

                                id = sdr["numeroIdEspecialidade"].ToString();

                            }
                        }
                    }
                }
            }
            return id;
        }

        public (int registo, string erro) eliminarPessoalMedico(pessoalMedico pessoalMedicos)
        {
            int result = 0;
            if (RefExiste(pessoalMedicos.numeroCedulaProfissional))
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query = "DELETE FROM pessoalmedico WHERE numeroCedulaProfissional	=@numeroCedulaProfissional";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroCedulaProfissional", pessoalMedicos.numeroCedulaProfissional);

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                            return (result, null);
                        }
                        catch (Exception e)
                        {
                            return (-1, e.Message.ToString());
                        }
                    }

                }
            }
            else
            {
                return (-1, "Não exsite número da celula profissional");
            }
        }

        public (int registo, string erro) atualizarPessoalMedico(pessoalMedico pessoalMedicos)
        {
            int registo = 0;

            if (RefExiste(pessoalMedicos.numeroCedulaProfissional))
            {
                string query = @"UPDATE pessoalmedico set  numeroIdEspecialidade=@numeroIdEspecialidade, nomeAplido=@nomeAplido, contactoMovel=@contactoMovel WHERE numeroCedulaProfissional=@numeroCedulaProfissional";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroCedulaProfissional", pessoalMedicos.numeroCedulaProfissional);
                        cmd.Parameters.AddWithValue("@nomeAplido", pessoalMedicos.nomeAplido);
                        cmd.Parameters.AddWithValue("@contactoMovel", pessoalMedicos.contactoMovel);
                        cmd.Parameters.AddWithValue("@numeroIdEspecialidade", pessoalMedicos.numeroIdEspecialidade);


                        try
                        {
                            registo = cmd.ExecuteNonQuery();
                            return (registo, null);
                        }
                        catch (Exception e)
                        {
                            return (-1, e.Message.ToString());
                        }
                    }
                }

            }
            else
            {
                return (-1, "Não exsite número da celula profissional");
            }


        }

        public bool RefExiste(string description)
        {
            bool existe = false;
            string query = "SELECT * FROM pessoalmedico WHERE numeroCedulaProfissional=@numeroCedulaProfissional";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@numeroCedulaProfissional", description);

                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            existe = true;
                        }
                    }
                }
            }
            return existe;
        }
    }
}
