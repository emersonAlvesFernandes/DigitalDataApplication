using DigitalData.Domain.Entities.SubItem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.SubItem;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Utils;

namespace DigitalData.SqlRepository.Entities.SubItem
{
    public class SubItemRepository : RepositoryBase, ISubItemRepository
    {
        public SubItemEntity Create(int itemId, SubItemEntity item, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_subitem", connection))
                {
                    using (SqlTransaction tr = connection.BeginTransaction())
                    {
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_item", item.Name);
                        cmd.Parameters.AddWithValue("@nom_subitem", item.Name);                        
                        cmd.Parameters.AddWithValue("@des_descr", item.Description);
                        cmd.Parameters.AddWithValue("@ind_ativa", item.IsActive);
                        cmd.Parameters.AddWithValue("@cod_usu", userId);

                        var subItemId = (int)cmd.ExecuteScalar();
                        //this.CreateRelation(itemId, subItemId, cmd);

                        tr.Commit();

                        item.Id = subItemId;

                        return item;
                    }
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

        //private void CreateRelation(int itemId, int subitemId, SqlCommand cmd)
        //{
        //    try
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "spr_ins_item_subitem";
        //        cmd.Parameters.AddWithValue("@id_item", itemId);
        //        cmd.Parameters.AddWithValue("@id_subitem", subitemId);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public bool Delete(int id, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_del_subitem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_item", id);
                    cmd.ExecuteNonQuery();
                    return true;
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

        public IEnumerable<SubItemEntity> GetAll(int itemId)
        {
            try
            {
                var collection = new List<SubItemEntity>();

                base.Initialize();
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_subitem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_item", itemId);
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var id = dataReader["id"].ToInt32();
                        var name = dataReader["nom_item"].ToString();
                        var description = dataReader["des_descr"].ToString();
                        var desdo = dataReader["ind_desdo"].ToBoolean();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();
                        var isActive = dataReader["ind_ativa"].ToBoolean();
                        
                        var subItem = new SubItemEntity(id, name, description, isActive, creationDate, lastUpdate);
                        
                        collection.Add(subItem);
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

        public SubItemEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SubItemEntity Update(SubItemEntity subItem, int userId)
        {
            throw new NotImplementedException();
        }

        public SubItemEntity Relate(int companyId, int itemid, int id, int userId)
        {
            throw new NotImplementedException();
        }

        public bool UnRelate(int companyId, int itemid, int id, int userId)
        {
            throw new NotImplementedException();
        }        
    }
}
