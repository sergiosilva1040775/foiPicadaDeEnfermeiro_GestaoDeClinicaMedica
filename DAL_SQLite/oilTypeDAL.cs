using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{
    public class oilTypeDAL
    {
        Models.oilType _OilTypeCC;
        public Models.oilType OilTypeCC
        {
            get { return this._OilTypeCC; }
            set { this._OilTypeCC = value; }
        }

        string ligacao;


        private void carregarLerLigacaoBD()
        {
            string local = AppDomain.CurrentDomain.BaseDirectory + "\\regedit.bin";
            try
            {
                if (File.Exists(local))
                {
                    FileStream fs1 = new FileStream(local, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs1);
                    string _string = br.ReadString();
                    fs1.Close();
                    if (File.Exists(_string.Replace("Data Source=", "")))
                    { ligacao = _string; }
                    else
                    { ligacao = ""; }
                }
                else
                { ligacao = ""; }


            }
            catch (Exception ex)
            {
                String mensagem = "carregarLerLigacaoBD CarBrand" + Environment.NewLine + ex.Message;
                ligacao = "";
            }

        }

        public void selectOilTypeId()
        {
            //try
            //{
            //    carregarLerLigacaoBD();
            //    DataTable dataTable = new DataTable();
            //    string query = "Select * from categoria Where Activo = 1 And Id = '" + id + "';";
            //    SQLiteConnection conn = new SQLiteConnection(ligacao);
            //    SQLiteDataAdapter da = new SQLiteDataAdapter(query, ligacao);
            //    da.Fill(dataTable);
            //    Categoria = dataTable.Rows[0]["Categoria"].ToString();
            //}
            //catch (Exception ex)
            //{
            //    String mensagem = "selectOilTypeId OilTypeDAL" + Environment.NewLine + ex.Message;

            //}
        }

        private List<Models.oilType> selectOilTypeAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.oilType> OilTypeList = new List<Models.oilType>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from oilType;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        OilTypeList.Add(new Models.oilType(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return OilTypeList;
                                }
                                else
                                { return null; }

                            }
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    String mensagem = "selectOilTypeAll OilTypeDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }


        public (string error, List<Models.oilType>) selectOilTypeActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return ("Error to connect to database!", null);
            }
            else
            {
                List<Models.oilType> OilTypeList = new List<Models.oilType>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from oilType where active = 1;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        OilTypeList.Add(new Models.oilType(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return (null, OilTypeList);
                                }
                                else
                                { return ("Don't exist information", null); }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    String mensagem = "selectOilTypeActive OilTypeDAL" + Environment.NewLine + ex.Message;
                    return (mensagem, null);
                }
            }
        }




        public (int codigo, string erro) updateOilType()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return (0, "Error to connect to database!");
            }
            else
            {
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        if (Convert.ToInt16(selectIdByName(_OilTypeCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE oilType SET description = @descriptionBrand WHERE numeroId = @id";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _OilTypeCC.description);
                                sqlite_cmd.Parameters.AddWithValue("id", _OilTypeCC.numeroId);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _OilTypeCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "updateOilType OilTypeDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public string selectIdByName(string descriptionOT)
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return "0";
            }
            else
            {
                try
                {
                    string saida = "X";
                    string query = "Select numeroId from oilType Where description = @description And active = 1";

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@description", descriptionOT));
                            using (SQLiteDataReader sdr = sqlite_cmd.ExecuteReader())
                            {
                                if (sdr.HasRows)
                                {
                                    while (sdr.Read())
                                        saida = sdr["numeroId"].ToString();
                                    return saida;
                                }
                                else { return "0"; }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    String mensagem = "selectIdByName OilTypeDAL" + Environment.NewLine + ex.Message;
                    return "0";
                }
            }
        }



        public (int codigo, string erro) insertOilType()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return (0, "Error to connect to database!");
            }
            else
            {
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        if (Convert.ToInt16(selectIdByName(_OilTypeCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO oilType (description) VALUES (@descriptionBrand);";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _OilTypeCC.description);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _OilTypeCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertOilType OilTypeDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


        public (int codigo, string erro) deleteOilType()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return (0, "Error to connect to database!");
            }
            else
            {
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();

                        using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                        {
                            sqlite_cmd.CommandText = "UPDATE oilType SET active = '0' WHERE numeroId = @id;";
                            sqlite_cmd.Parameters.AddWithValue("id", _OilTypeCC.numeroId);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteOilType OilTypeDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


    }
}
