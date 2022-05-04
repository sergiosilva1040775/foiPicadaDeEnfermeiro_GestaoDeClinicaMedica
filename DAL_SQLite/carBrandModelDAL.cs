using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{
    public class carBrandModelDAL
    {

        Models.carBrandModel _CarModelCC;
        public Models.carBrandModel CarModelCC
        {
            get { return this._CarModelCC; }
            set { this._CarModelCC = value; }
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

        public void selectCarBrandModelById()
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
            //    String mensagem = "selectCarBrandModelById CarBrandModelDAL" + Environment.NewLine + ex.Message;

            //}
        }

        private List<Models.carBrandModel> selectCarBrandModelAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.carBrandModel> CarBrandModelList = new List<Models.carBrandModel>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from model Where numeroId_Make = @idBrand;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        CarBrandModelList.Add(new Models.carBrandModel(
       Int32.Parse(reader["numeroId_model"].ToString()),
        Int32.Parse(reader["numeroId_Make"].ToString()),
       reader["modelName"].ToString(),
       bool.Parse(reader["active"].ToString())

             ));

                                    }

                                    return CarBrandModelList;
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
                    String mensagem = "selectCarBrandModelAll CarBrandModelDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }


        }


        public List<Models.carBrandModel> selectCarModelByBrandActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.carBrandModel> CarBrandModelList = new List<Models.carBrandModel>();
                //try
                //{

                using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                {
                    conn.Open();
                    string sqlStri = "Select * from model Where active = 1 And numeroId_Make = @idBrand;";
                    using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                    {
                        command.Parameters.AddWithValue("idBrand", _CarModelCC.numeroIdBrand);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    //  MessageBox.Show(reader["modelName"].ToString());
                                    CarBrandModelList.Add(new Models.carBrandModel(
    Int32.Parse(reader["numeroId_model"].ToString()),
     Int32.Parse(reader["numeroId_Make"].ToString()),
    reader["modelName"].ToString(),
    bool.Parse(reader["active"].ToString())

          ));

                                }
                                return CarBrandModelList;

                            }
                            else
                            { return null; }

                        }
                    }
                }
                //               }
                //catch (Exception ex)
                //{
                //    String mensagem = "selectCarModelByBrandActive CarBrandModelDAL" + Environment.NewLine + ex.Message;
                //    return null;
                //}
            }

        }



        public (int codigo, string erro) updateCarBrandModel()
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
                        if (Convert.ToInt16(selectIdByName()) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE model SET modelName = @descriptionModel, numeroId_Make = @idBrand WHERE numeroId_model = @idModel;";
                                sqlite_cmd.Parameters.AddWithValue("descriptionModel", _CarModelCC.descriptionModel);
                                sqlite_cmd.Parameters.AddWithValue("idBrand", _CarModelCC.numeroIdBrand );
                                sqlite_cmd.Parameters.AddWithValue("idModel", _CarModelCC.numeroIdModel );
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _CarModelCC.descriptionModel  + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "updateCarBrandModel carBrandModelDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public string selectIdByName()
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
                    string query = "Select numeroId_model from model Where modelName = @descriptionModel  And numeroId_Make = @idBrand  And  active = 1;"; carregarLerLigacaoBD();
                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@descriptionModel", _CarModelCC.descriptionModel));
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@idBrand", _CarModelCC.numeroIdBrand));
                            using (SQLiteDataReader sdr = sqlite_cmd.ExecuteReader())
                            {
                                if (sdr.HasRows)
                                {
                                    while (sdr.Read())
                                        saida = sdr["numeroId_model"].ToString();
                                    return saida;
                                }
                                else { return "0"; }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    String mensagem = "selectIdByName carBrandModelDAL" + Environment.NewLine + ex.Message;
                    return "0";
                }
            }


        }



        public (int codigo, string erro) insertCarBrandModel()
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
                        if (Convert.ToInt16(selectIdByName()) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO model (modelName, numeroId_Make) VALUES (@descriptionModel, @idBrand);";
                                sqlite_cmd.Parameters.AddWithValue("descriptionModel", _CarModelCC.descriptionModel);
                                sqlite_cmd.Parameters.AddWithValue("idBrand", _CarModelCC.numeroIdBrand);                          
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _CarModelCC.descriptionModel + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertCarBrandModel carBrandModelDAL" + Environment.NewLine + ex.Message);
                }
            }

        }


        public (int codigo, string erro) deleteCarModel()
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
                            sqlite_cmd.CommandText = "UPDATE model SET active = '0' WHERE numeroId_model = @idModel;";
                            sqlite_cmd.Parameters.AddWithValue("idModel", _CarModelCC.numeroIdModel );                            
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteCarModel carBrandModelDAL" + Environment.NewLine + ex.Message);
                }
            }
        }


    }
}
