using foiPicadaDeEnfermeiro.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace foiPicadaDeEnfermeiro.DAL
{
    public class gestaoConsultasDAL
    {
        private string connStr = BaseDAL.connStr;

        public (int registo, string erro) inserirConsultaMedica(gestaoConsulta gestaoConsultas)
        {
            int registo = 0;
            string query = "INSERT INTO gestaoconsulta (data,numeroIdMedico, numeroIdPaciente )" +
                                           "VALUES(@data, @numeroIdMedico, @numeroIdPaciente )";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@data", gestaoConsultas.dataHora);
                    cmd.Parameters.AddWithValue("@numeroIdMedico", gestaoConsultas.numeroIdMedico);
                    cmd.Parameters.AddWithValue("@numeroIdPaciente", gestaoConsultas.numeroIdPaciente);
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



        public List<gestaoConsulta> listarGestaoConsulta()
        {
            List<gestaoConsulta> ListarGestaoConsulta = new List<gestaoConsulta>();

            string query = "SELECT * FROM gestaoconsulta";

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
                                ListarGestaoConsulta.Add(new gestaoConsulta(
                                    Int32.Parse(sdr["numeroIdConsulta"].ToString()),
                                    DateTime.Parse(sdr["data"].ToString()),
                                    sdr["numeroIdMedico"].ToString(),
                                   sdr["numeroIdPaciente"].ToString()
                                    ));
                            }
                        }
                    }
                }
            }
            return ListarGestaoConsulta;
        }

        public List<gestaoConsultasPlus> listarGestaoConsultaPlus()
        {
            List<gestaoConsultasPlus> ListarGestaoConsultasPlus = new List<gestaoConsultasPlus>();

            string query = "SELECT A.*, B.nomeAplido As momeMedico, C.nomeAplido As nomePaciente FROM gestaoconsulta as A, pessoalmedico as B, clientepaciente as C Where A.numeroIdMedico = B.numeroCedulaProfissional And C. numeroNIF = A.numeroIdPaciente    ";

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
                                ListarGestaoConsultasPlus.Add(new gestaoConsultasPlus(
                                    Int32.Parse(sdr["numeroIdConsulta"].ToString()),
                                    DateTime.Parse(sdr["data"].ToString()),
                                    sdr["numeroIdMedico"].ToString(),
                                    sdr["numeroIdPaciente"].ToString(),
                                    sdr["momeMedico"].ToString(),
                                   sdr["nomePaciente"].ToString()
                                    ));
                            }
                        }
                    }
                }
            }
            return ListarGestaoConsultasPlus;
        }


        public (int registo, string erro) eliminarConsultaMedica(gestaoConsulta gestaoConsultas)
        {
            int result = 0;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "DELETE FROM gestaoconsulta WHERE numeroIdConsulta 	=@numeroIdConsulta ";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@numeroIdConsulta", gestaoConsultas.numeroIdConsulta);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        return (result, null);
                    }
                    catch (Exception e)
                    {
                        return (0, e.Message.ToString());
                    }
                }

            }
        }


        public (int registo, string erro) eliminarConsultaMedicaPlus(gestaoConsultasPlus gestaoConsultas)
        {
            int result = 0;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "DELETE FROM gestaoconsulta WHERE numeroIdConsulta 	=@numeroIdConsulta ";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@numeroIdConsulta", gestaoConsultas.numeroIdConsulta);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                        return (result, null);
                    }
                    catch (Exception e)
                    {
                        return (0, e.Message.ToString());
                    }
                }

            }
        }


        public (int registo, string erro) atualizarConsultaMedica(gestaoConsulta gestaoConsultas)
        {
            int registo = 0;
            string query = @"UPDATE gestaoconsulta set  data	= @data, numeroIdMedico	= @numeroIdMedico, numeroIdPaciente= @numeroIdPaciente WHERE numeroIdConsulta=@numeroIdConsulta";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@numeroIdConsulta", gestaoConsultas.numeroIdConsulta);
                    cmd.Parameters.AddWithValue("@data", gestaoConsultas.dataHora);
                    cmd.Parameters.AddWithValue("@numeroIdMedico", gestaoConsultas.numeroIdMedico);
                    cmd.Parameters.AddWithValue("@numeroIdPaciente", gestaoConsultas.numeroIdPaciente);
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

        public bool RefExiste(string description)
        {
            bool existe = false;
            string query = "SELECT * FROM gestaoconsulta WHERE numeroIdConsulta=@numeroIdConsulta";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@numeroIdConsulta", description);

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
