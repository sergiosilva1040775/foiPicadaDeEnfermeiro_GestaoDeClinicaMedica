using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{
    public class maintenanceChecklistItemDAL
    {
        Models.maintenanceChecklistItem _MaintenanceChecklistItemCC;
        public Models.maintenanceChecklistItem MaintenanceChecklistItemCC
        {
            get { return this._MaintenanceChecklistItemCC; }
            set { this._MaintenanceChecklistItemCC = value; }
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
                String mensagem = "carregarLerLigacaoBD maintenanceChecklistItemDAL" + Environment.NewLine + ex.Message;
                ligacao = "";
            }

        }


        public void selectMaintenanceChecklistItemById()
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
            //    String mensagem = "obterCategoriaById MaintenanceChecklistItemDAL" + Environment.NewLine + ex.Message;

            //}
        }

        private List<Models.maintenanceChecklistItem> selectMaintenanceChecklistItemAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.maintenanceChecklistItem> MaintenanceChecklistItemList = new List<Models.maintenanceChecklistItem>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from maintenanceChecklistItems;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        MaintenanceChecklistItemList.Add(new Models.maintenanceChecklistItem(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return MaintenanceChecklistItemList;
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
                    String mensagem = "selectMaintenanceChecklistItemAll MaintenanceChecklistItemDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }


        public (string error, List<Models.maintenanceChecklistItem>) selectMaintenanceChecklistItemActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return ("Error to connect to database!", null);
            }
            else
            {
                List<Models.maintenanceChecklistItem> MaintenanceChecklistItemList = new List<Models.maintenanceChecklistItem>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from maintenanceChecklistItems where active = 1;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        MaintenanceChecklistItemList.Add(new Models.maintenanceChecklistItem(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return (null, MaintenanceChecklistItemList);
                                }
                                else
                                { return ("Don't exist information", null); }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    String mensagem = "selectMaintenanceChecklistItemActive MaintenanceChecklistItemDAL" + Environment.NewLine + ex.Message;
                    return (mensagem, null);
                }
            }
        }




        public (int codigo, string erro) updateMaintenanceChecklistItem()
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
                        if (Convert.ToInt16(selectIdByName(_MaintenanceChecklistItemCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE maintenanceChecklistItems SET description = @descriptionBrand WHERE numeroId = @id";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _MaintenanceChecklistItemCC.description);
                                sqlite_cmd.Parameters.AddWithValue("id", _MaintenanceChecklistItemCC.numeroId);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _MaintenanceChecklistItemCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "updateMaintenanceChecklistItem maintenanceChecklistItemDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public string selectIdByName(string descriptionMCI)
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
                    string query = "Select numeroId from maintenanceChecklistItems Where description = @descriptionBrand And active = 1";

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@descriptionBrand", descriptionMCI));
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
                    String mensagem = "selectIdByName MaintenanceChecklistItemDAL" + Environment.NewLine + ex.Message;
                    return "0";
                }
            }
        }



        public (int codigo, string erro) insertMaintenanceChecklistItem()
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
                        if (Convert.ToInt16(selectIdByName(_MaintenanceChecklistItemCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO maintenanceChecklistItems (description) VALUES (@descriptionBrand);";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _MaintenanceChecklistItemCC.description);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _MaintenanceChecklistItemCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertMaintenanceChecklistItem maintenanceChecklistItemDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public (int codigo, string erro) deleteMaintenanceChecklistItem()
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
                            sqlite_cmd.CommandText = "UPDATE maintenanceChecklistItems SET active = '0' WHERE numeroId = @id;";
                            sqlite_cmd.Parameters.AddWithValue("id", _MaintenanceChecklistItemCC.numeroId);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteMaintenanceChecklistItem maintenanceChecklistItemDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


    }
}
