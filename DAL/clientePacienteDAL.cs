using foiPicadaDeEnfermeiro.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace foiPicadaDeEnfermeiro.DAL
{
    public class clientePacienteDAL


    {
        private string connStr = BaseDAL.connStr;

        public (int registo, string erro) inserirClientePaciente(clientePaciente clientePacientes)
        {
            int registo = 0;
            if (!RefExiste(clientePacientes.numeroNIF ))
            {
                string query = "INSERT INTO clientepaciente (numeroNIF, nomeAplido, contactoMovel, numeroSNS)" +
                                               "VALUES(@numeroNIF, @nomeAplido, @contactoMovel, @numeroSNS)";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroNIF", clientePacientes.numeroNIF );
                        cmd.Parameters.AddWithValue("@nomeAplido", clientePacientes.nomeAplido);
                        cmd.Parameters.AddWithValue("@contactoMovel", clientePacientes.contactoMovel);
                        cmd.Parameters.AddWithValue("@numeroSNS", clientePacientes.numeroSNS );

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
                return (0, "Já exsite número NIF");
            }

        }

        public List<clientePaciente > listarClientePaciente()
        {
            List<clientePaciente > ListarclientePaciente = new List<clientePaciente>();

            string query = "SELECT * FROM clientepaciente";

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

                                ListarclientePaciente.Add(new clientePaciente(
                                    sdr["numeroNIF"].ToString(),
                                    sdr["nomeAplido"].ToString(),
                                     sdr["contactoMovel"].ToString(),
                                    sdr["numeroSNS"].ToString()
                                    ));
                            }
                        }
                    }
                }
            }
            return ListarclientePaciente;
        }


        public (int registo, string erro) eliminarClientePaciente(clientePaciente clientePacientes)
        {
            int result = 0;
            if (RefExiste(clientePacientes.numeroNIF ))
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query = "DELETE FROM clientepaciente WHERE numeroNIF	=@numeroNIF";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroNIF", clientePacientes.numeroNIF);

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
                return (-1, "Não exsite numero NIF");
            }
        }

        public (int registo, string erro) atualizarClientePaciente(clientePaciente clientePacientes)
        {
            int registo = 0;

            if (RefExiste(clientePacientes.numeroNIF))
            {
                string query = @"UPDATE clientepaciente set  numeroSNS=@numeroSNS, nomeAplido=@nomeAplido, contactoMovel=@contactoMovel WHERE numeroNIF=@numeroNIF";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroSNS", clientePacientes.numeroSNS);
                        cmd.Parameters.AddWithValue("@nomeAplido", clientePacientes.nomeAplido);
                        cmd.Parameters.AddWithValue("@contactoMovel", clientePacientes.contactoMovel);
                        cmd.Parameters.AddWithValue("@numeroNIF", clientePacientes.numeroNIF );


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
                return (-1, "Não exsite numero Nif");
            }


        }

        public bool RefExiste(string description)
        {
            bool existe = false;
            string query = "SELECT * FROM clientepaciente WHERE numeroNIF=@numeroNIF";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@numeroNIF", description);

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
