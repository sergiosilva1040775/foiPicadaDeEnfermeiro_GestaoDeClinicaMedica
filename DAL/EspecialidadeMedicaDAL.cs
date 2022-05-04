using foiPicadaDeEnfermeiro.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace foiPicadaDeEnfermeiro.DAL
{
    public class EspecialidadeMedicaDAL
    {
        private string connStr = BaseDAL.connStr;

        public (int registo, string erro) inserirEspecialidadeMedica(especialidadeMedica especialidadesMedicas)
        {
            int registo = 0;

            if (!RefExiste(especialidadesMedicas.description))
            {

                string query = "INSERT INTO especialidademedica (description)" +
                                               "VALUES(@description)";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.Parameters.AddWithValue("@description", especialidadesMedicas.description);

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
                return (0, "Já exsite esta especialidade de medica");
            }

        }

        public List<especialidadeMedica> listarEspecialidadesMedica()
        {
            List<especialidadeMedica> ListarespecialidadesMedicas = new List<especialidadeMedica>();

            string query = "SELECT * FROM especialidademedica";

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
                                ListarespecialidadesMedicas.Add(new especialidadeMedica(
                                    Int32.Parse(sdr["numeroId"].ToString()),
                                    sdr["description"].ToString()
                                    ));
                            }
                        }
                    }
                }
            }
            return ListarespecialidadesMedicas;
        }


        public (int registo, string erro) eliminarEspecialidadeMedica(especialidadeMedica especialidadesMedicas)
        {
            int result = 0;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "DELETE FROM especialidademedica WHERE numeroId	=@numeroId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@numeroId", especialidadesMedicas.numeroId);

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

        public (int registo, string erro) atualizarEspecialidadeMedica(especialidadeMedica especialidadesMedicas)
        {
            int registo = 0;
            if (!RefExiste(especialidadesMedicas.description))
            {

                string query = @"UPDATE especialidademedica set  description=@description WHERE numeroId=@numeroId";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.Parameters.AddWithValue("@numeroId", especialidadesMedicas.numeroId);
                        cmd.Parameters.AddWithValue("@description", especialidadesMedicas.description);


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
                return (0, "Já exsite esta especialidade de medica");
            }
        }

        public bool RefExiste(string description)
        {
            bool existe = false;
            string query = "SELECT * FROM especialidademedica WHERE description=@description";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@description", description);

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
