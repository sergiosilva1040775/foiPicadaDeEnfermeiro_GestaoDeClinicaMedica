using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{
    public class checlistSectorItemsDAL
    {


        Models.checlistSectorItems _CheclistSectorItemsCC;
        public Models.checlistSectorItems CheclistSectorItemsCC
        {
            get { return this._CheclistSectorItemsCC; }
            set { this._CheclistSectorItemsCC = value; }
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
                String mensagem = "carregarLerLigacaoBD checlistSectorItemsDAL" + Environment.NewLine + ex.Message;
                ligacao = "";
            }

        }


        public (int codigo, string description) selectCheclistSectorItemsById()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return (1, "Error to connect to database!");
            }
            else
            {
                try
                {
                    string saida = "X";
                    string query = "Select description from checklistItens Where numeroId = @numeroId And active = 1";
                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@numeroId", _CheclistSectorItemsCC.numeroId));
                            using (SQLiteDataReader sdr = sqlite_cmd.ExecuteReader())
                            {
                                if (sdr.HasRows)
                                {
                                    while (sdr.Read())
                                        saida = sdr["description"].ToString();
                                    return (0, saida);
                                }
                                else
                                {
                                    return (1, "Error to connect to database!");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    String mensagem = "selectIdByName ServicesMaintenanceDAL" + Environment.NewLine + ex.Message;
                    return (1, mensagem);
                }
            }
        }



        private List<Models.checlistSectorItems> selectCheclistSectorItemsAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.checlistSectorItems> CheclistSectorItemsList = new List<Models.checlistSectorItems>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from checklistItens;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        CheclistSectorItemsList.Add(new Models.checlistSectorItems(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return CheclistSectorItemsList;
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
                    String mensagem = "selectCarBrandActive CheclistSectorItemsDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }


        public (string error, List<Models.checlistSectorItems>) selectCheclistSectorItemsActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return ("Error to connect to database!", null);
            }
            else
            {
                List<Models.checlistSectorItems> CheclistSectorItemsList = new List<Models.checlistSectorItems>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from checklistItens where active = 1;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        CheclistSectorItemsList.Add(new Models.checlistSectorItems(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }
                                    return (null, CheclistSectorItemsList);
                                }
                                else
                                { return("Don't exist information", null); }

                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    String mensagem = "selectCheclistSectorItemsActive CheclistSectorItemsDAL" + Environment.NewLine + ex.Message;
                    return (mensagem, null);
                }
            }
        }




        public (int codigo, string erro) updateCheclistSectorItems()
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
                        if (Convert.ToInt16(selectIdByName(_CheclistSectorItemsCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE checklistItens SET description = @descriptionBrand WHERE numeroId = @id";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _CheclistSectorItemsCC.description);
                                sqlite_cmd.Parameters.AddWithValue("id", _CheclistSectorItemsCC.numeroId);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _CheclistSectorItemsCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "updateCheclistSectorItems checlistSectorItemsDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public string selectIdByName(string descriptionCI)
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
                    string query = "Select numeroId from checklistItens Where description = @description And active = 1";

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@description", descriptionCI));
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
                    String mensagem = "selectIdByName CheclistSectorItemsDAL" + Environment.NewLine + ex.Message;
                    return "0";
                }
            }
        }



        public (int codigo, string erro) insertCheclistSectorItems()
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
                        if (Convert.ToInt16(selectIdByName(_CheclistSectorItemsCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO checklistItens (description) VALUES (@descriptionBrand);";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _CheclistSectorItemsCC.description);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _CheclistSectorItemsCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertCheclistSectorItems checlistSectorItemsDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


        public (int codigo, string erro) deleteCheclistSectorItems()
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
                            sqlite_cmd.CommandText = "UPDATE checklistItens SET active = '0' WHERE numeroId = @id;";
                            sqlite_cmd.Parameters.AddWithValue("id", _CheclistSectorItemsCC.numeroId);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteCheclistSectorItems checlistSectorItemsDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


    }
}
