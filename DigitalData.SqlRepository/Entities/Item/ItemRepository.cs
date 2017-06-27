using DigitalData.Domain.Entities.Item.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Item;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Utils;

namespace DigitalData.SqlRepository.Entities.Item
{
    public class ItemRepository : RepositoryBase, IItemRepository
    {
        public ItemEntity Create(ItemEntity item)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_Item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_item", item.Name);
                    cmd.Parameters.AddWithValue("@des_desdo", item.Desdobramento);
                    cmd.Parameters.AddWithValue("@des_descr", item.Description);

                    var id = (int)cmd.ExecuteScalar();
                    var i = new ItemEntity(id, item.Name, item.Description, item.Desdobramento);
                    return i;
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            try
            {
                var collection = new List<ItemEntity>();

                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_item", connection))
                {
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var id = dataReader["id"].ToInt32();
                        var name = dataReader["nom_item"].ToString();
                        var description = dataReader["des_descr"].ToString();
                        var desdo = dataReader["ind_desdo"].ToBoolean();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();

                        var item = new ItemEntity(id, name, description, desdo, creationDate, lastUpdate);

                        collection.Add(item);
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

        public ItemEntity GetById(int companyId)
        {
            try
            {
                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", companyId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var id = dataReader["id"].ToInt32();
                        var name = dataReader["nom_item"].ToString();
                        var description = dataReader["des_descr"].ToString();
                        var desdo = dataReader["ind_desdo"].ToBoolean();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();

                        var item = new ItemEntity(id, name, description, desdo, creationDate, lastUpdate);
                        return item;
                    }
                }
                return null;
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

        public IEnumerable<ItemEntity> GetByCompanyId(int companyId)
        {
            try
            {
                var collection = new List<ItemEntity>();

                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_item_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", companyId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var id = dataReader["id"].ToInt32();
                        var name = dataReader["nom_item"].ToString();
                        var description = dataReader["des_descr"].ToString();
                        var desdo = dataReader["ind_desdo"].ToBoolean();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();

                        var item = new ItemEntity(id, name, description, desdo, creationDate, lastUpdate);
                        collection.Add(item); 
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

        
        public bool Relate(int companyId, int id)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_Item_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empre", companyId);
                    cmd.Parameters.AddWithValue("@id_item", id);                    

                    var idRelation = (int)cmd.ExecuteScalar();                                        
                }
                return true;
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

        public bool UnRelate(int companyId, int id)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_del_Item_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empre", companyId);
                    cmd.Parameters.AddWithValue("@id_item", id);

                    var idRelation = (int)cmd.ExecuteScalar();
                }
                return true;
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

        public ItemEntity Update(ItemEntity item)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_Item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_item", item.Name);
                    cmd.Parameters.AddWithValue("@des_desdo", item.Desdobramento);
                    cmd.Parameters.AddWithValue("@des_descr", item.Description);
                    
                    return item;
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
