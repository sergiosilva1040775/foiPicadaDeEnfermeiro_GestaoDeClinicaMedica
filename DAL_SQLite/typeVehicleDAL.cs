using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{

    public class typeVehicleDAL
    {
        Models.typeVehicle _TypeVehicleCC;
        public Models.typeVehicle  TypeVehicleCC
        {
            get { return this._TypeVehicleCC; }
            set { this._TypeVehicleCC = value; }
        }

        string ligacao = "";


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
                String mensagem = "carregarLerLigacaoBD typeVehicleDAL" + Environment.NewLine + ex.Message;
                ligacao = "";
            }

        }

        public void selectCarBrandById()
        {
            //try
            //{
            //    carregarLerLigacaoBD();
            //    DataTable dataTable = new DataTable();
            //    string query = "Select * from typeVehicle Where Activo = 1 And Id = '" + id + "';";
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

        public (string error, List<Models.typeVehicle >) selectTypeVehicleAll()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return ("Error to connect to database!", null);
            }
            else
            {

                List<Models.typeVehicle > TypeVehicleList = new List<Models.typeVehicle>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from typeVehicle;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        // MessageBox.Show(reader["description"].ToString());
                                        TypeVehicleList.Add(new Models.typeVehicle(
            Int32.Parse(reader["numeroId"].ToString()),
            reader["description"].ToString(),
            bool.Parse(reader["active"].ToString())

             ));

                                    }
                                    return (null, TypeVehicleList);

                                }
                                else
                                { return ("Error to connect to database!", null); }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    String mensagem = "selectTypeVehicleActive typeVehicleDAL" + Environment.NewLine + ex.Message;
                    return (mensagem, null);
                }
            }

        }


        public (string error, List<Models.typeVehicle> TypeVehicleList) selectTypeVehicleActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {

                return ("Error to connect to database!", null);
            }
            else
            {
                List<Models.typeVehicle> TypeVehicleList = new List<Models.typeVehicle>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from typeVehicle where active = 1;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                       //  MessageBox.Show(reader["description"].ToString());
                                        TypeVehicleList.Add(new Models.typeVehicle(
            Int32.Parse(reader["numeroId"].ToString()),
            reader["description"].ToString(),
            bool.Parse(reader["active"].ToString())

             ));

                                    }
                                    return (null, TypeVehicleList);

                                }
                                else
                                    return ("No information in this table", null);

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    String mensagem = "selectTypeVehicleActive typeVehicleDAL" + Environment.NewLine + ex.Message;
                    return (mensagem, null);
                }
            }

        }




        public (int codigo, string erro) updateTypeVehicle()
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
                        if (Convert.ToInt16(selectIdByName(_TypeVehicleCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE typeVehicle SET description = @descriptionBrand WHERE numeroId = @id";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _TypeVehicleCC.description);
                                sqlite_cmd.Parameters.AddWithValue("id", _TypeVehicleCC.numeroId);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _TypeVehicleCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "updateTypeVehicle typeVehicleDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public string selectIdByName(string descriptionBrand)
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return "0";
            }
            else
            {
                try
                {
                    string saida = "X";
                    string query = "Select numeroId from typeVehicle Where description = @descriptionBrand And active = 1";

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@descriptionBrand", descriptionBrand));
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
                    String mensagem = "selectIdByName typeVehicleDAL" + Environment.NewLine + ex.Message;
                    return "0";
                }
            }

        }


        public (int codigo, string erro) insertTypeVehicle()
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
                        if (Convert.ToInt16(selectIdByName(_TypeVehicleCC.description.ToString())) == 0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "INSERT INTO typeVehicle (description) VALUES (@descriptionBrand);";
                                sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _TypeVehicleCC.description);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (0, "Registo com o nome: " + _TypeVehicleCC.description + " já existe!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertTypeVehicle typeVehicleDAL" + Environment.NewLine + ex.Message);
                }
            }

        }

        public (int codigo, string erro) deleteTypeVehicle()
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
                            sqlite_cmd.CommandText = "UPDATE typeVehicle SET active = '0' WHERE numeroId = @id;";
                            sqlite_cmd.Parameters.AddWithValue("id", _TypeVehicleCC.numeroId);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteTypeVehicle typeVehicleDAL" + Environment.NewLine + ex.Message);
                }
            }
        }
    }

}


