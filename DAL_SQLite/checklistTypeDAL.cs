using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{
    public class checklistTypeDAL
    {

        Models.checklistType _ChecklistTypeCC;
        public Models.checklistType ChecklistTypeCC
        {
            get { return this._ChecklistTypeCC; }
            set { this._ChecklistTypeCC = value; }
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

        public void selectChecklistTypeById()
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
            //    String mensagem = "obterCategoriaById CarBrand" + Environment.NewLine + ex.Message;

            //}
        }

        private List<Models.checklistType> selectChecklistTypeAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.checklistType> ChecklistTypeList = new List<Models.checklistType>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from checklistType ;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        ChecklistTypeList.Add(new Models.checklistType(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return ChecklistTypeList;
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
                    String mensagem = "selectCarBrandActive ChecklistTypeDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }


        public (string error,  List<Models.checklistType>) selectChecklistTypeActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return ("Error to connect to database!", null);
            }
            else
            {
                List<Models.checklistType> ChecklistTypeList = new List<Models.checklistType>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from checklistType  where active = 1;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        ChecklistTypeList.Add(new Models.checklistType(
       Int32.Parse(reader["numeroId"].ToString()),
       reader["description"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return (null,   ChecklistTypeList);
                                }
                                else
                                { return ("Don't exist information", null); }

                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    String mensagem = "selectCarBrandActive ChecklistTypeDAL" + Environment.NewLine + ex.Message;
                    return (mensagem, null);
                }
            }
        }




        public (int codigo, string erro) updateChecklistType()
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
                        if (Convert.ToInt16(selectIdByName(_ChecklistTypeCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE checklistType SET description = @descriptionBrand WHERE numeroId = @id";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _ChecklistTypeCC.description);
                                sqlite_cmd.Parameters.AddWithValue("id", _ChecklistTypeCC.numeroId);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _ChecklistTypeCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "updateChecklistType checklistTypeDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public string selectIdByName(string descriptionCT)
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return "X";
            }
            else
            {
                try
                {
                    string saida = "X";
                    string query = "Select numeroId from checklistType  Where description = @description And active = 1";

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@description", descriptionCT));
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
                    String mensagem = "selectIdByName ChecklistTypeDAL" + Environment.NewLine + ex.Message;
                    return "X";
                }
            }
        }



        public (int codigo, string erro) insertChecklistType()
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
                        if (Convert.ToInt16(selectIdByName(_ChecklistTypeCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO checklistType (description) VALUES (@descriptionBrand);";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _ChecklistTypeCC.description);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _ChecklistTypeCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertChecklistType checklistTypeDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


        public (int codigo, string erro) deleteChecklistType()
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
                            sqlite_cmd.CommandText = "UPDATE checklistType SET active = '0' WHERE numeroId = @id;";
                            sqlite_cmd.Parameters.AddWithValue("id", _ChecklistTypeCC.numeroId);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteChecklistType checklistTypeDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

    }
}
