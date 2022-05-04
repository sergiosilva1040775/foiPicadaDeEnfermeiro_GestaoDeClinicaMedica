using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{


    public class itemSectorChecklistTypDAL
    {
        Models.itemSectorChecklistTyp _itSctChecLisrTypeCC;
        DAL_SQLite.checlistSectorItemsDAL checlistSectorItemsDAL = new DAL_SQLite.checlistSectorItemsDAL();
        public Models.itemSectorChecklistTyp itSctChecLisrTypeCC
        {
            get { return this._itSctChecLisrTypeCC; }
            set { this._itSctChecLisrTypeCC = value; }
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

        public void selectItemSectorChecklistTypById()
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
            //    String mensagem = "obterCategoriaById ItemSectorChecklistTypDAL" + Environment.NewLine + ex.Message;

            //}
        }

        private List<Models.itemSectorChecklistTyp> selectItemSectorChecklistTypAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.itemSectorChecklistTyp> ItemSectorChecklistTypList = new List<Models.itemSectorChecklistTyp>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from itemSectorChecklistTyp;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        //                                 ItemSectorChecklistTypList.Add(new Models.ItemSectorChecklistTyp(
                                        //Int32.Parse(reader["numeroId"].ToString()),
                                        //reader["description"].ToString(),
                                        //bool.Parse(reader["active"].ToString())

                                        //      ));

                                    }

                                    return ItemSectorChecklistTypList;
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
                    String mensagem = "selectItemSectorChecklistTypAll ItemSectorChecklistTypDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }

        public List<Models.itemSectorChecklistTyp> selectItemSectorChecklistTypDescripttionActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.itemSectorChecklistTyp> ItemSectorChecklistTypList = new List<Models.itemSectorChecklistTyp>();
                try
                {
                    // MessageBox.Show(itSctChecLisrTypeCC.numeroId_CheckListType + Environment.NewLine + itSctChecLisrTypeCC.numeroId_Sector);

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "select A.numeroIdItemSectorChecklistTyp, A.numeroId_Item, B.description  from itemSectorChecklistTyp as A, checklistItens as B   where  A.numeroId_checklistType = @numeroId_checklistType And A.numeroId_Sectors= @numeroId_Sectors And A.active=1 And B.active=1 and A.numeroId_Item= B.numeroId;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            command.Parameters.AddWithValue("numeroId_checklistType", _itSctChecLisrTypeCC.numeroId_CheckListType);
                            command.Parameters.AddWithValue("numeroId_Sectors", _itSctChecLisrTypeCC.numeroId_Sector);
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        //       MessageBox.Show(reader["description"].ToString());
                                        ItemSectorChecklistTypList.Add(new Models.itemSectorChecklistTyp(
                                            reader["description"].ToString(),
                                            Int32.Parse(reader["numeroIdItemSectorChecklistTyp"].ToString()),
                                             Int32.Parse(reader["numeroId_Item"].ToString())
                                                  ));
                                    }
                                    return ItemSectorChecklistTypList;
                                }
                                else
                                { return null; }

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    String mensagem = "selectItemSectorChecklistTypActive ItemSectorChecklistTypDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }

        public (int codigo, string erro) insertItemSectorChecklistTyp()
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
                    if (Convert.ToInt16(selectIdByName()) == 0)
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                        {
                            conn.Open();
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO itemSectorChecklistTyp ( numeroId_Item, numeroId_Sectors, numeroId_checklistType ) VALUES ( @numeroId_Item, @numeroId_Sectors, @numeroId_checklistType);";
                                sqlite_cmd.Parameters.AddWithValue("numeroId_Item", _itSctChecLisrTypeCC.numeroId_Item);
                                sqlite_cmd.Parameters.AddWithValue("numeroId_Sectors", _itSctChecLisrTypeCC.numeroId_Sector);
                                sqlite_cmd.Parameters.AddWithValue("numeroId_checklistType", _itSctChecLisrTypeCC.numeroId_CheckListType);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }

                        }
                    }
                    else { return (selectDescriptionRepetida(_itSctChecLisrTypeCC)); }
                }
                catch (Exception ex)
                {
                    return (0, "insertItemSectorChecklistTyp itemSectorChecklistTypDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


        public (int codigo, string erro) updateItemSectorChecklistTyp()
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
                    if (Convert.ToInt16(selectIdByName()) == _itSctChecLisrTypeCC.numeroId_ItemCTSCTR || Convert.ToInt16(selectIdByName()) ==0)
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                        {
                            conn.Open();
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {


                                sqlite_cmd.CommandText = "UPDATE itemSectorChecklistTyp SET numeroId_Item = @numeroId_Item, numeroId_Sectors = @numeroId_Sectors, numeroId_checklistType = @numeroId_checklistType WHERE numeroIdItemSectorChecklistTyp = @numeroIdItemSectorChecklistTyp";
                                sqlite_cmd.Parameters.AddWithValue("@numeroId_checklistType", _itSctChecLisrTypeCC.numeroId_CheckListType);
                                sqlite_cmd.Parameters.AddWithValue("@numeroId_Sectors", _itSctChecLisrTypeCC.numeroId_Sector);
                                sqlite_cmd.Parameters.AddWithValue("@numeroId_Item", _itSctChecLisrTypeCC.numeroId_Item);
                                sqlite_cmd.Parameters.AddWithValue("numeroIdItemSectorChecklistTyp", _itSctChecLisrTypeCC.numeroId_ItemCTSCTR);

                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo update com sucesso!");
                            }

                        }
                    }
                    else { return (selectDescriptionRepetida(_itSctChecLisrTypeCC)); }
                }
                catch (Exception ex)
                {
                    return (0, "insertItemSectorChecklistTyp itemSectorChecklistTypDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


        private (int codigo, string mensagem) selectDescriptionRepetida(Models.itemSectorChecklistTyp _itSctChecLisrTypeCC)
        {
            string mensagemSaida = "";
            Handlers.checlistSectorItemsHander checlistSectorItemsHander = new Handlers.checlistSectorItemsHander();
            (int codigoCLSIH, Models.checlistSectorItems checlistSectorItemsCC, string mensagemDeErroCLIH) = checlistSectorItemsHander.ValidarServicesMaintenanceSelectById (_itSctChecLisrTypeCC.numeroId_Item .ToString());
            switch (codigoCLSIH)
            {
                case 1:
                    MessageBox.Show(mensagemDeErroCLIH);
                    break;
                default:
                    checlistSectorItemsDAL.CheclistSectorItemsCC = checlistSectorItemsCC;
                    (int errorServices, string description) = checlistSectorItemsDAL.selectCheclistSectorItemsById ();
                    if (errorServices == 0) { mensagemSaida = "Registo com o nome: " + description + " já existe!"; }
                    else
                    { mensagemSaida = description; }
                    break;

            }
            return (0, mensagemSaida);
        }


        public string selectIdByName()
        {
            //try
            //{
            string saida = "X";
            string query = "Select numeroIdItemSectorChecklistTyp from itemSectorChecklistTyp Where numeroId_Item = @numeroId_Item And numeroId_Sectors = @numeroId_Sectors And numeroId_checklistType = @numeroId_checklistType And active = 1";
            carregarLerLigacaoBD();
            using (SQLiteConnection conn = new SQLiteConnection(ligacao))
            {
                using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                {
                    sqlite_cmd.Connection = conn;
                    conn.Open();
                    // MessageBox.Show(itSctChecLisrTypeCC.numeroId_Item.ToString());
                    sqlite_cmd.Parameters.AddWithValue("numeroId_Item", _itSctChecLisrTypeCC.numeroId_Item);
                    sqlite_cmd.Parameters.AddWithValue("numeroId_Sectors", _itSctChecLisrTypeCC.numeroId_Sector);
                    sqlite_cmd.Parameters.AddWithValue("numeroId_checklistType", _itSctChecLisrTypeCC.numeroId_CheckListType);
                    using (SQLiteDataReader sdr = sqlite_cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                                saida = sdr["numeroIdItemSectorChecklistTyp"].ToString();
                            return saida;
                        }
                        else { return "0"; }
                    }
                }
            }
        }
        //}
        //catch (Exception ex)
        //{
        //    String mensagem = "selectIdByName ItemSectorChecklistTypDAL" + Environment.NewLine + ex.Message;
        //    return "0";
        //}


        public (int codigo, string erro) deleteItemSectorChecklistTyp()
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
                            sqlite_cmd.CommandText = "UPDATE itemSectorChecklistTyp SET active = '0' WHERE numeroIdItemSectorChecklistTyp = @numeroIdItemSectorChecklistTyp";
                            sqlite_cmd.Parameters.AddWithValue("numeroIdItemSectorChecklistTyp", _itSctChecLisrTypeCC.numeroId_ItemCTSCTR);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteeItemSectorChecklistTyp itemSectorChecklistTypDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


    }




}
