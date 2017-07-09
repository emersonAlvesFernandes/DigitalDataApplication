using DigitalData.Domain.Entities.Planning.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Planning;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Utils;

namespace DigitalData.SqlRepository.Entities.Planning
{
    public class PlanningRepository : RepositoryBase, IPlanningRepository
    {
        public PlanningEntity CreateMonthPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int relationId, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand(string.Empty, connection))
                {

                    //executar se ainda não houver vínculo
                    //var relationId = this.CreateEntityRelation(companyId, itemId, subItemId, userId, cmd);

                    cmd.CommandText = "spr_ins_planejamento_mensal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_empre_item_subitem", relationId);
                    cmd.Parameters.AddWithValue("@cod_mes", planning.Month);
                    cmd.Parameters.AddWithValue("@num_ano", planning.Year);
                    cmd.Parameters.AddWithValue("@val_reali", planning.DoneValue);
                    cmd.Parameters.AddWithValue("@val_previ", planning.PlannedValue);
                    cmd.Parameters.AddWithValue("@val_verde_ini", planning.GreenFrom);
                    cmd.Parameters.AddWithValue("@val_verde_fim", planning.GreenTo);
                    cmd.Parameters.AddWithValue("@val_verme_ini", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_verme_fim", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_orcad", planning.RedTo);
                    cmd.Parameters.AddWithValue("@dat_criac", planning.CreationDate);
                    cmd.Parameters.AddWithValue("@cod_usu_adm", userId);                    
                    cmd.Parameters.AddWithValue("@des_cor_status", planning.StatusColor);

                    var id = (int)cmd.ExecuteScalar();

                    var p = new PlanningEntity(id, planning.DoneValue, planning.PlannedValue,
                        planning.GreenFrom, planning.GreenTo, planning.RedFrom,
                        planning.RedTo, planning.Budgeted, planning.CreationDate, planning.Month, planning.Year);

                    return p;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.CloseConnection();
            }
        }

        //private int CreateEntityRelation(int companyId, int itemId, int? subItemId, int userId, SqlCommand cmd)
        //{
        //    try
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "spr_ins_empre_item";
        //        cmd.Parameters.AddWithValue("@id_empresa", companyId);
        //        cmd.Parameters.AddWithValue("@id_item", itemId);
        //        cmd.Parameters.AddWithValue("@id_subitem", subItemId);
        //        cmd.Parameters.AddWithValue("@cod_usu", userId);
        //        var id = (int)cmd.ExecuteScalar();
        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public PlanningEntity CreateYearPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int relationId, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand(string.Empty, connection))
                {

                    //executar se ainda não houver vínculo
                    //var relationId = this.CreateEntityRelation(companyId, itemId, subItemId, userId, cmd);

                    cmd.CommandText = "spr_ins_planejamento_anual";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empre_item_subitem", relationId);
                    
                    cmd.Parameters.AddWithValue("@num_ano", planning.Year);
                    cmd.Parameters.AddWithValue("@val_reali", planning.DoneValue);
                    cmd.Parameters.AddWithValue("@val_previ", planning.PlannedValue);
                    cmd.Parameters.AddWithValue("@val_verde_ini", planning.GreenFrom);
                    cmd.Parameters.AddWithValue("@val_verde_fim", planning.GreenTo);
                    cmd.Parameters.AddWithValue("@val_verme_ini", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_verme_fim", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_orcad", planning.RedTo);
                    cmd.Parameters.AddWithValue("@dat_criac", planning.CreationDate);
                    cmd.Parameters.AddWithValue("@cod_usu_adm", userId);
                    cmd.Parameters.AddWithValue("@des_cor_status", planning.StatusColor);

                    var id = (int)cmd.ExecuteScalar();

                    var p = new PlanningEntity(id, planning.DoneValue, planning.PlannedValue,
                        planning.GreenFrom, planning.GreenTo, planning.RedFrom,
                        planning.RedTo, planning.Budgeted, planning.CreationDate, planning.Month, planning.Year);

                    return p;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.CloseConnection();
            }
        }

        public IEnumerable<PlanningEntity> GetSubItemPlanning(int companyId, int itemId, int subItemId)
        {
            base.Initialize();
            base.OpenConnection();

            try
            {
                var collection = new List<PlanningEntity>();

                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_plan_subitem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);
                    cmd.Parameters.AddWithValue("@id_item", itemId);
                    cmd.Parameters.AddWithValue("@id_subitem", subItemId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var id = dataReader["id"].ToInt32();
                        var year = dataReader["num_ano"].ToInt32();
                        var month = dataReader["cod_mes"].ToInt32();
                        var doneValue = dataReader["val_reali"].ToDouble();
                        var plannedValue = dataReader["val_previ"].ToDouble();
                        var greenFrom = dataReader["val_verde_ini"].ToDouble();
                        var greenTo = dataReader["val_verde_fim"].ToDouble();
                        var redFrom = dataReader["val_verme_ini"].ToDouble();
                        var redTo = dataReader["val_verme_fim"].ToDouble();
                        var budgeted = dataReader["val_orcad"].ToDouble();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var statusColor = dataReader["des_cor_status"].ToString();

                        var planning = new PlanningEntity(id,
                            doneValue, plannedValue, greenFrom, greenTo, redFrom, redTo, budgeted,
                            creationDate, month, year, statusColor);

                        collection.Add(planning);
                    }
                }
                return collection;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.CloseConnection();
            }
        }

        public IEnumerable<PlanningEntity> GetItemPlanning(int companyId, int itemId)
        {
            base.Initialize();
            base.OpenConnection();

            try
            {
                var collection = new List<PlanningEntity>();

                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("ler_plan_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_item", itemId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var id = dataReader["id"].ToInt32();
                        var year = dataReader["num_ano"].ToInt32();
                        var month = dataReader["cod_mes"].ToInt32();
                        var doneValue = dataReader["val_reali"].ToDouble();
                        var plannedValue = dataReader["val_previ"].ToDouble();
                        var greenFrom = dataReader["val_verde_ini"].ToDouble();
                        var greenTo = dataReader["val_verde_fim"].ToDouble();
                        var redFrom = dataReader["val_verme_ini"].ToDouble();
                        var redTo = dataReader["val_verme_fim"].ToDouble();
                        var budgeted = dataReader["val_orcad"].ToDouble();
                        var creationDate = dataReader["dat_criac"].ToDateTime();                        
                        var statusColor = dataReader["des_cor_status"].ToString();

                        var planning = new PlanningEntity(id, 
                            doneValue, plannedValue, greenFrom, greenTo, redFrom, redTo, budgeted, 
                            creationDate, month, year, statusColor);

                        collection.Add(planning);
                    }
                }
                return collection;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.CloseConnection();
            }
        }        

        public PlanningEntity Update(int PlanningId, PlanningEntity planning, int adminId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand(string.Empty, connection))
                {

                    cmd.CommandText = "spr_upd_planejamento_mensal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", PlanningId);
                    cmd.Parameters.AddWithValue("@cod_mes", planning.Month);
                    cmd.Parameters.AddWithValue("@num_ano", planning.Year);
                    cmd.Parameters.AddWithValue("@val_reali", planning.DoneValue);
                    cmd.Parameters.AddWithValue("@val_previ", planning.PlannedValue);
                    cmd.Parameters.AddWithValue("@val_verde_ini", planning.GreenFrom);
                    cmd.Parameters.AddWithValue("@val_verde_fim", planning.GreenTo);
                    cmd.Parameters.AddWithValue("@val_verme_ini", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_verme_fim", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_orcad", planning.RedTo);
                    cmd.Parameters.AddWithValue("@dat_criac", planning.CreationDate);
                    cmd.Parameters.AddWithValue("@cod_usu_adm", adminId);
                    cmd.Parameters.AddWithValue("@des_cor_status", planning.StatusColor);

                    return planning;                                        
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.CloseConnection();
            }
        }

        public PlanningEntity FillDoneValue(PlanningEntity planning, int clientId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand(string.Empty, connection))
                {
                    cmd.CommandText = "spr_upd_preenchimento_clien_planejamento_mensal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", planning.Id);                    
                    cmd.Parameters.AddWithValue("@val_reali", planning.DoneValue);                    
                    cmd.Parameters.AddWithValue("@cod_usu_clien", clientId);
                    cmd.Parameters.AddWithValue("@des_cor_status", planning.StatusColor);

                    return planning;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.CloseConnection();
            }
        }
        
    }
}
