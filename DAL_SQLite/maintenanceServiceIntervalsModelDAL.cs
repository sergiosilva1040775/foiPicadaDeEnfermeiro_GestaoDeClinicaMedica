using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace projectoFinal.DAL_SQLite
{
    public class maintenanceServiceIntervalsModelDAL
    {

        DAL_SQLite.servicesMaintenanceDAL servicesMaintenances = new DAL_SQLite.servicesMaintenanceDAL();
        Handlers.servicesMaintenanceHander servicesMaintenanceHander = new Handlers.servicesMaintenanceHander();


        string ligacao;

        Models.maintenanceIntervalsModel _maintenanceIntervalsModelCC;
        public Models.maintenanceIntervalsModel maintenanceIntervalsModelCC
        {
            get { return this._maintenanceIntervalsModelCC; }
            set { this._maintenanceIntervalsModelCC = value; }
        }


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

        //public void selectMaintenanceChecklistItemById()
        //{
        //try
        //{
        //    carregarLerLigacaoBD();
        //    DataTable dataTable = new DataTable();
        //    string query = "Select * from maintenanceChecklistItems Where Activo = 1 And Id = '" + id + "';";
        //    SQLiteConnection conn = new SQLiteConnection(ligacao);
        //    SQLiteDataAdapter da = new SQLiteDataAdapter(query, ligacao);
        //    da.Fill(dataTable);
        //    Categoria = dataTable.Rows[0]["Categoria"].ToString();
        //}
        //catch (Exception ex)
        //{
        //    String mensagem = "selectMaintenanceChecklistItemById MaintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message;

        //}
        //}

        //private DataTable selectMaintenanceChecklistItemAll()
        //{
        //    try
        //    {
        //        carregarLerLigacaoBD();
        //        DataTable dataTable = new DataTable();
        //        string query = "Select * from maintenanceChecklistItems;";
        //        SQLiteConnection conn = new SQLiteConnection(ligacao);
        //        SQLiteDataAdapter da = new SQLiteDataAdapter(query, ligacao);
        //        da.Fill(dataTable);
        //        return dataTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        String mensagem = "selectMaintenanceChecklistItemAll MaintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message;
        //        return null;
        //    }
        //}

        public List<Models.maintenanceIntervalsModel> selectMaintenanceIntervalsByModelDescActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.maintenanceIntervalsModel> maintenanceIntervalsModelList = new List<Models.maintenanceIntervalsModel>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select A.*, B.description from maintenanceIntervalsModel as A, services as B Where A.numeroId_Model = @numeroId_Model and A.active = 1 And B.active = 1 And A.numeroId_service = B.numeroId";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            //  MessageBox.Show(_maintenanceIntervalsModelCC.numeroId_Model.ToString());
                            command.Parameters.AddWithValue("numeroId_Model", _maintenanceIntervalsModelCC.numeroId_Model);

                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        //    MessageBox.Show(reader["numeroIdModelServices"].ToString());
                                        maintenanceIntervalsModelList.Add(new Models.maintenanceIntervalsModel(
                                              reader["description"].ToString(),
                                            Int32.Parse(reader["numeroIdModelServices"].ToString()),
                                            double.Parse(reader["intervalMilage"].ToString()),
                                            double.Parse(reader["intervalTime"].ToString()),
                                            reader["notes"].ToString(),
                                            bool.Parse(reader["active"].ToString()),
                                            Int32.Parse(reader["numeroId_service"].ToString()),
                                            Int32.Parse(reader["numeroId_Model"].ToString())));
                                    }
                                    return maintenanceIntervalsModelList;
                                }
                                else
                                { return null; }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    String mensagem = "selectMaintenanceIntervalsByModelActive MaintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }

        public List<Models.maintenanceIntervalsModel> selectMaintenanceIntervalsByModelActive()
        {
            carregarLerLigacaoBD();
            if (ligacao.Length == 0)
            {
                MessageBox.Show("Error to connect to database!");
                return null;
            }
            else
            {
                List<Models.maintenanceIntervalsModel> maintenanceIntervalsModelList = new List<Models.maintenanceIntervalsModel>();
                try
                {

                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        conn.Open();
                        string sqlStri = "Select * from maintenanceIntervalsModel Where numeroId_Model = @numeroId_Model;";
                        using (SQLiteCommand command = new SQLiteCommand(sqlStri, conn))
                        {
                            //  MessageBox.Show(_maintenanceIntervalsModelCC.numeroId_Model.ToString());
                            command.Parameters.AddWithValue("numeroId_Model", _maintenanceIntervalsModelCC.numeroId_Model);

                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        //    MessageBox.Show(reader["numeroIdModelServices"].ToString());
                                        maintenanceIntervalsModelList.Add(new Models.maintenanceIntervalsModel(
                                            Int32.Parse(reader["numeroIdModelServices"].ToString()),
                                            double.Parse(reader["intervalMilage"].ToString()),
                                            double.Parse(reader["intervalTime"].ToString()),
                                            reader["notes"].ToString(),
                                            bool.Parse(reader["active"].ToString()),
                                            Int32.Parse(reader["numeroId_service"].ToString()),
                                            Int32.Parse(reader["numeroId_Model"].ToString())));
                                    }
                                    return maintenanceIntervalsModelList;
                                }
                                else
                                { return null; }

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    String mensagem = "selectMaintenanceIntervalsByModelActive MaintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message;
                    return null;
                }
            }
        }

        private string update(SQLiteConnection conn)
        {
            string regist = "x";
            //using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
            //{
            //    sqlite_cmd.CommandText = "UPDATE maintenanceIntervalsModel SET intervalMilage = @intervalMilage, intervalTime = @intervalTime , notes = @notes, numeroId_service = @idService , numeroId_Model = @idModel WHERE numeroIdModelServices = @numeroIdModelServices;";
            //    sqlite_cmd.Parameters.AddWithValue("intervalMilage", this.intervalMilage);
            //    sqlite_cmd.Parameters.AddWithValue("intervalTime", this.intervalTime);
            //    sqlite_cmd.Parameters.AddWithValue("notes", this.notes);
            //    sqlite_cmd.Parameters.AddWithValue("idService", this.idService);
            //    sqlite_cmd.Parameters.AddWithValue("idModel", this.idModel);
            //    sqlite_cmd.Parameters.AddWithValue("numeroIdModelServices", this.id);
            //    //MessageBox.Show(sqlite_cmd.CommandText.ToString() + Environment.NewLine + this.descriptionModel + Environment.NewLine + this.idBrand + Environment.NewLine + this.idModel);
            //    regist = sqlite_cmd.ExecuteNonQuery().ToString();

            return regist.ToString();
            //}

        }


        public (int codigo, string erro) updateMaintenanceServiceIntervalsModel()
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
                        if (Convert.ToInt16(selectIdByName()) == _maintenanceIntervalsModelCC.numeroIdModelServices  || Convert.ToInt16(selectIdByName()) ==0)
                        {
                            using (SQLiteCommand sqlite_cmd = conn.CreateCommand())
                            {
                                sqlite_cmd.CommandText = "UPDATE maintenanceIntervalsModel SET intervalMilage = @intervalMilage, intervalTime = @intervalTime, notes = @notes,  numeroId_service = @numeroId_service,   numeroId_Model = @numeroId_Model WHERE numeroIdModelServices = @numeroIdModelServices";
                                sqlite_cmd.Parameters.AddWithValue("@numeroIdModelServices", _maintenanceIntervalsModelCC.numeroIdModelServices);
                                sqlite_cmd.Parameters.AddWithValue("@intervalMilage", _maintenanceIntervalsModelCC.intervalMilage);
                                sqlite_cmd.Parameters.AddWithValue("@intervalTime", _maintenanceIntervalsModelCC.intervalTime);
                                sqlite_cmd.Parameters.AddWithValue("@notes", _maintenanceIntervalsModelCC.notes);
                                sqlite_cmd.Parameters.AddWithValue("@numeroId_service", _maintenanceIntervalsModelCC.numeroId_service);
                                sqlite_cmd.Parameters.AddWithValue("@numeroId_Model", _maintenanceIntervalsModelCC.numeroId_Model);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo atualizado com sucesso!");
                        }
                    }
                        else
                    {
                        return (selectDescriptionRepetida(_maintenanceIntervalsModelCC));
                    }
                }

                }
                catch (Exception ex)
                {
                    return (0, "updateMaintenanceServiceIntervalsModel MaintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        private (int codigo, string mensagem) selectDescriptionRepetida(Models.maintenanceIntervalsModel _maintenanceIntervalsModelCC)
        {
            string mensagemSaida = "";
            Handlers.servicesMaintenanceHander servicesMaintenanceHander = new Handlers.servicesMaintenanceHander();
            (int codigoSMH, Models.servicesMaintenance servicesMaintenanceCC, string mensagemDeErroSMH) = servicesMaintenanceHander.ValidarServicesMaintenanceSelectById(_maintenanceIntervalsModelCC.numeroId_service.ToString());
            switch (codigoSMH)
            {
                case 1:
                    MessageBox.Show(mensagemDeErroSMH);
                    break;
                default:
                    servicesMaintenances.ServicesMaintenanceCC = servicesMaintenanceCC;
                    (int errorServices, string description) = servicesMaintenances.selectServicesMaintenanceById();
                    if (errorServices == 0) { mensagemSaida="Registo com o nome: " + description + " já existe!"; }
                    else
                    { mensagemSaida = description;  }
                    break;

            }
            return (0, mensagemSaida);
        }

        private string selectIdByName()
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
                    string query = "Select numeroIdModelServices from maintenanceIntervalsModel Where numeroId_service = @numeroId_service And numeroId_Model = @numeroId_Model and  active = 1";
                    //     string sqlStri = "Select A.*, B.description from maintenanceIntervalsModel as A, services as B Where A.numeroId_service = @numeroId_service And  A.numeroId_Model = @numeroId_Model and   A.active = 1 And B.active = 1 And A.numeroId_service = B.numeroId";
                    using (SQLiteConnection conn = new SQLiteConnection(ligacao))
                    {
                        using (SQLiteCommand sqlite_cmd = new SQLiteCommand(query))
                        {
                            sqlite_cmd.Connection = conn;
                            conn.Open();
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@numeroId_service", _maintenanceIntervalsModelCC.numeroId_service));
                            sqlite_cmd.Parameters.Add(new SQLiteParameter("@numeroId_Model", _maintenanceIntervalsModelCC.numeroId_Model));
                            using (SQLiteDataReader sdr = sqlite_cmd.ExecuteReader())
                            {
                                if (sdr.HasRows)
                                {
                                    while (sdr.Read())
                                        saida = sdr["numeroIdModelServices"].ToString();
                                    return saida;
                                }
                                else { return "0"; }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    String mensagem = "selectIdByName maintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message;
                    return "0";
                }
            }
        }

        public (int codigo, string erro) insertMaintenanceServiceIntervalsModel()
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
                                sqlite_cmd.CommandText = "INSERT INTO maintenanceIntervalsModel (intervalMilage, intervalTime, notes, numeroId_service, numeroId_Model) VALUES (@intervalMilage, @intervalTime, @notes, @idService, @idModel); ";
                                sqlite_cmd.Parameters.AddWithValue("intervalMilage", _maintenanceIntervalsModelCC.intervalMilage);
                                sqlite_cmd.Parameters.AddWithValue("intervalTime", _maintenanceIntervalsModelCC.intervalTime);
                                sqlite_cmd.Parameters.AddWithValue("notes", _maintenanceIntervalsModelCC.notes);
                                sqlite_cmd.Parameters.AddWithValue("idService", _maintenanceIntervalsModelCC.numeroId_service);
                                sqlite_cmd.Parameters.AddWithValue("idModel", _maintenanceIntervalsModelCC.numeroId_Model);
                                int regist = sqlite_cmd.ExecuteNonQuery();
                                conn.Close();
                                return (regist, "Registo inserido com sucesso!");
                            }
                        }
                        else
                        {
                            return (selectDescriptionRepetida(_maintenanceIntervalsModelCC));
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "insertMaintenanceServiceIntervalsModel maintenanceServiceIntervalsModelDAL" + Environment.NewLine + ex.Message);
                }
            }
        }

        public (int codigo, string erro) deleteMaintenanceServiceIntervalsModel()
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
                            sqlite_cmd.CommandText = "UPDATE maintenanceIntervalsModel SET active=0 WHERE numeroIdModelServices = @numeroIdModelServices;";
                            sqlite_cmd.Parameters.AddWithValue("numeroIdModelServices", _maintenanceIntervalsModelCC.numeroIdModelServices);
                            //MessageBox.Show(sqlite_cmd.CommandText.ToString() + Environment.NewLine + this.descriptionModel + Environment.NewLine + this.idBrand + Environment.NewLine + this.idModel);
                            int regist = sqlite_cmd.ExecuteNonQuery();
                            conn.Close();
                            return (regist, "Registo delitado com sucesso!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    return (0, "deleteCarBrand CarBrand" + Environment.NewLine + ex.Message);
                }
            }
        }


    }
}
