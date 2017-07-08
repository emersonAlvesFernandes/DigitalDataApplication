using DigitalData.Domain.Entities.Planning.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Planning;
using System.Data.SqlClient;
using System.Data;

namespace DigitalData.SqlRepository.Entities.Planning
{
    public class PlanningRepository : RepositoryBase, IPlanningRepository
    {
        public PlanningEntity CreateMonthPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand(string.Empty, connection))
                {

                    var relationId = this.CreateEntityRelation(companyId, itemId, subItemId, userId, cmd);

                    cmd.CommandText = "spr_ins_planejamento_mensal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_empre_item_subitem", relationId);
                    cmd.Parameters.AddWithValue("@cod_mes", planning.DoneValue);
                    cmd.Parameters.AddWithValue("@val_reali", planning.DoneValue);
                    cmd.Parameters.AddWithValue("@val_previ", planning.PlannedValue);
                    cmd.Parameters.AddWithValue("@val_verde_ini", planning.GreenFrom);
                    cmd.Parameters.AddWithValue("@val_verde_fim", planning.GreenTo);
                    cmd.Parameters.AddWithValue("@val_verme_fim", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_orcad", planning.RedTo);
                    cmd.Parameters.AddWithValue("@dat_criac", planning.CreationDate);
                    cmd.Parameters.AddWithValue("@cod_usu_adm", userId);                    
                    cmd.Parameters.AddWithValue("@des_cor_status", planning.StatusColor);

                    var id = (int)cmd.ExecuteScalar();

                    var p = new PlanningEntity(id, planning.DoneValue, planning.PlannedValue,
                        planning.GreenFrom, planning.GreenTo, planning.RedFrom,
                        planning.RedTo, planning.Budgeted, planning.CreationDate);

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

        private int CreateEntityRelation(int companyId, int itemId, int? subItemId, int userId, SqlCommand cmd)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spr_ins_item_subitem";
                cmd.Parameters.AddWithValue("@id_empresa", companyId);
                cmd.Parameters.AddWithValue("@id_item", itemId);
                cmd.Parameters.AddWithValue("@id_subitem", subItemId);
                cmd.Parameters.AddWithValue("@cod_usu", userId);
                var id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PlanningEntity CreateYearPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand(string.Empty, connection))
                {

                    var relationId = this.CreateEntityRelation(companyId, itemId, subItemId, userId, cmd);

                    cmd.CommandText = "spr_ins_planejamento_anual";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empre_item_subitem", relationId);                    
                    cmd.Parameters.AddWithValue("@val_reali", planning.DoneValue);
                    cmd.Parameters.AddWithValue("@val_previ", planning.PlannedValue);
                    cmd.Parameters.AddWithValue("@val_verde_ini", planning.GreenFrom);
                    cmd.Parameters.AddWithValue("@val_verde_fim", planning.GreenTo);
                    cmd.Parameters.AddWithValue("@val_verme_fim", planning.RedFrom);
                    cmd.Parameters.AddWithValue("@val_orcad", planning.RedTo);
                    cmd.Parameters.AddWithValue("@dat_criac", planning.CreationDate);
                    cmd.Parameters.AddWithValue("@cod_usu_adm", userId);
                    cmd.Parameters.AddWithValue("@des_cor_status", planning.StatusColor);

                    var id = (int)cmd.ExecuteScalar();

                    var p = new PlanningEntity(id, planning.DoneValue, planning.PlannedValue,
                        planning.GreenFrom, planning.GreenTo, planning.RedFrom,
                        planning.RedTo, planning.Budgeted, planning.CreationDate);

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

        public bool Delete(int idPlanning)
        {
            throw new NotImplementedException();
        }

        public PlanningEntity Get(int idPlanning)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningEntity> GetItemPlanning(int companyId, int itemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningEntity> GetSubItemPlanning(int companyId, int itemId, int subItemId)
        {
            throw new NotImplementedException();
        }

        public PlanningEntity Update(int idPlanning, PlanningEntity planning)
        {
            throw new NotImplementedException();
        }
    }
}
