using System;
using System.IO;


namespace projectoFinal.DAL_SQLite
{

    public class vehicleDAL
    {
        Models.vehicle _vehicleCC;
        public Models.vehicle vehicleCC
        {
            get { return this._vehicleCC; }
            set { this._vehicleCC = value; }
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
                String mensagem = "carregarLerLigacaoBD vehicleDAL" + Environment.NewLine + ex.Message;
                ligacao = "";
            }

        }

        //public void selectCarBrandById()
        //{
        //    //try
        //    //{
        //    //    carregarLerLigacaoBD();
        //    //    DataTable dataTable = new DataTable();
        //    //    string query = "Select * from categoria Where Activo = 1 And Id = '" + id + "';";
        //    //    SQLiteConnection conn = new SQLiteConnection(ligacao);
        //    //    SQLiteDataAdapter da = new SQLiteDataAdapter(query, ligacao);
        //    //    da.Fill(dataTable);
        //    //    Categoria = dataTable.Rows[0]["Categoria"].ToString();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    String mensagem = "obterCategoriaById vehicleDAL" + Environment.NewLine + ex.Message;

        //    //}
        //}

        //public (string error, List<Models.carBrand>) selectCarBrandAll()
        //{
        //    carregarLerLigacaoBD();
        //    if (ligacao.Length == 0)
        //    {
        //        return ("Error to connect to database!", null);
        //    }
        //    else
        //    {

        //        List<Models.carBrand> CarBrandList = new List<Models.carBrand>();
        //        try
        //        {

        //            using (SQLiteConnection conn = new SQLiteConnection(ligacao))
        //            {
        //                conn.Open();
        //                string sqlStri = "Select * from make;";
        //                using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
        //                {
        //                    using (SQLiteDataReader reader = command.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            while (reader.Read())
        //                            {
        //                                // MessageBox.Show(reader["description"].ToString());
        //                                CarBrandList.Add(new Models.carBrand(
        //    Int32.Parse(reader["numeroId"].ToString()),
        //    reader["description"].ToString(),
        //    bool.Parse(reader["active"].ToString())

        //     ));

        //                            }
        //                            return (null, CarBrandList);

        //                        }
        //                        else
        //                        { return ("Error to connect to database!", null); }

        //                    }
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            String mensagem = "selectCarBrandActive vehicleDAL" + Environment.NewLine + ex.Message;
        //            return (mensagem, null);
        //        }
        //    }

        //}


        //public (string error, List<Models.carBrand> CarBrandList) selectCarBrandActive()
        //{
        //    carregarLerLigacaoBD();
        //    if (ligacao.Length == 0)
        //    {

        //        return ("Error to connect to database!", null);
        //    }
        //    else
        //    {
        //        List<Models.carBrand> CarBrandList = new List<Models.carBrand>();
        //        try
        //        {

        //            using (SQLiteConnection conn = new SQLiteConnection(ligacao))
        //            {
        //                conn.Open();
        //                string sqlStri = "Select * from make where active = 1;";
        //                using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
        //                {
        //                    using (SQLiteDataReader reader = command.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            while (reader.Read())
        //                            {
        //                                // MessageBox.Show(reader["description"].ToString());
        //                                CarBrandList.Add(new Models.carBrand(
        //    Int32.Parse(reader["numeroId"].ToString()),
        //    reader["description"].ToString(),
        //    bool.Parse(reader["active"].ToString())

        //     ));

        //                            }
        //                            return (null, CarBrandList);

        //                        }
        //                        else
        //                            return ("No information in this table", null);

        //                    }
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            String mensagem = "selectCarBrandActive vehicleDAL" + Environment.NewLine + ex.Message;
        //            return (mensagem, null);
        //        }
        //    }

        //}




        public (int codigo, string erro) updateVehicle()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return (0, "Error to connect to database!");
            }

            //    else
            //    {
            //        try
            //        {
            //            using (SQLiteConnection conn = new SQLiteConnection(ligacao))
            //            {
            //                conn.Open();
            //                if (Convert.ToInt16(selectIdByName(_CarBrandCC.description.ToString())) == 0)
            //                {
            //                    using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
            //                    {
            //                        sqlite_cmd.CommandText = "UPDATE make SET description = @descriptionBrand WHERE numeroId = @id";
            //                        sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _CarBrandCC.description);
            //                        sqlite_cmd.Parameters.AddWithValue("id", _CarBrandCC.numeroId);
            //                        int regist = sqlite_cmd.ExecuteNonQuery();
            //                        conn.Close();
            //                        return (regist, "Registo atualizado com sucesso!");
            //                    }
            //                }
            //                else
            //                {
            //                    return (0, "Registo com o nome: " + _CarBrandCC.description + " já existe!");
            //                }
            //            }

            //    }
            //    catch (Exception ex)
            //    {
            return (0, "updateVehicle vehicleDAL");
            //        return (0, "insertCarBrand vehicleDAL" + Environment.NewLine + ex.Message);
            //    }
            }

            //public string selectIdByName(string descriptionBrand)
            //{
            //    carregarLerLigacaoBD();
            //    if (ligacao.Length == 0)
            //    {
            //        return "0";
            //    }
            //    else
            //    {
            //        try
            //        {
            //            string saida = "X";
            //            string query = "Select numeroId from make Where description = @descriptionBrand And active = 1";

            //            using (SQLiteConnection conn = new SQLiteConnection(ligacao))
            //            {
            //                using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
            //                {
            //                    sqlite_cmd.Connection = conn;
            //                    conn.Open();
            //                    sqlite_cmd.Parameters.Add(new SQLiteParameter("@descriptionBrand", descriptionBrand));
            //                    using (SQLiteDataReader sdr = sqlite_cmd.ExecuteReader())
            //                    {
            //                        if (sdr.HasRows)
            //                        {
            //                            while (sdr.Read())
            //                                saida = sdr["numeroId"].ToString();
            //                            return saida;
            //                        }
            //                        else { return "0"; }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            String mensagem = "selectIdByName vehicleDAL" + Environment.NewLine + ex.Message;
            //            return "0";
            //        }
            //    }

            //}


            public (int codigo, string erro) insertVehicle()
            {
                carregarLerLigacaoBD();
                if (ligacao.Length == 0)
                {
                    return (0, "Error to connect to database!");
                }
                //else
                //{
                //    try
                //    {
                //        using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                //        {
                //            conn.Open();
                //            if (Convert.ToInt16(selectIdByName(_CarBrandCC.description.ToString())) == 0)
                //            {
                //                using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                //                {
                //                    sqlite_cmd.CommandText = "INSERT INTO make (description) VALUES (@descriptionBrand);";
                //                    sqlite_cmd.Parameters.AddWithValue("descriptionBrand", _CarBrandCC.description);
                //                    int regist = sqlite_cmd.ExecuteNonQuery();
                //                    conn.Close();
                //                    return (regist, "Registo inserido com sucesso!");
                //                }
                //            }
                //            else
                //            {
                //                return (0, "Registo com o nome: " + _CarBrandCC.description + " já existe!");
                //            }
                //        }

                //    }
                //    catch (Exception ex)
                //    {
                return (0, "insertVehicle vehicleDAL");
                //        return (0, "insertCarBrand vehicleDAL" + Environment.NewLine + ex.Message);
                //    }
                //}

            }

        public (int codigo, string erro) deleteVehicle()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                return (0, "Error to connect to database!");
            }
            //    else
            //    {
            //        try
            //        {
            //            using (SQLiteConnection conn = new SQLiteConnection(ligacao))
            //            {
            //                conn.Open();

            //                using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
            //                {
            //                    sqlite_cmd.CommandText = "UPDATE make SET active = '0' WHERE numeroId = @id;";
            //                    sqlite_cmd.Parameters.AddWithValue("id", _CarBrandCC.numeroId);
            //                    int regist = sqlite_cmd.ExecuteNonQuery();
            //                    conn.Close();
            //                    return (regist, "Registo delitado com sucesso!");
            //                }
            //            }

            //        }
            //        catch (Exception ex)
            //        {
            return (0, "deleteVehicle vehicleDAL");
           // return (0, "deleteVehicle vehicleDAL" + Environment.NewLine + ex.Message);
            //        }
            //    }
            }
        }

    }


