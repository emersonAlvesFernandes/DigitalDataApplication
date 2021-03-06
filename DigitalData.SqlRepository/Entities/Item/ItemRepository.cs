﻿using DigitalData.Domain.Entities.Item.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Item;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Utils;
using System.Transactions;

namespace DigitalData.SqlRepository.Entities.Item
{
    public class ItemRepository : RepositoryBase, IItemRepository
    {
        public ItemEntity Create(ItemEntity item, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_item", connection))
                {
                    using (SqlTransaction tr = connection.BeginTransaction())
                    {
                        cmd.Transaction = tr;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nom_item", item.Name);
                        cmd.Parameters.AddWithValue("@ind_desdo", item.Desdobramento);
                        cmd.Parameters.AddWithValue("@des_descr", item.Description);
                        cmd.Parameters.AddWithValue("@ind_ativa", item.IsActive);
                        cmd.Parameters.AddWithValue("@cod_usu", userId);

                        var id = (int)cmd.ExecuteScalar();

                        this.CreateRelation(id, cmd);

                        tr.Commit();

                        var i = new ItemEntity(id, item.Name, item.Description, item.Desdobramento);
                        return i;
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

        private void CreateRelation(int id_item, SqlCommand cmd)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "spr_ins_item_subitem";
                cmd.Parameters.AddWithValue("@id_item", id_item);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_del_item", connection))
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

        public IEnumerable<ItemEntity> GetAll()
        {
            try
            {
                var collection = new List<ItemEntity>();

                base.Initialize();
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
                        var isActive = dataReader["ind_ativa"].ToBoolean();

                        var item = new ItemEntity(id, name, description, desdo, isActive, creationDate, lastUpdate);

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

        public ItemEntity GetById(int id)
        {
            try
            {
                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_item_por_id", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_item", id);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var itemId = dataReader["id"].ToInt32();
                        var name = dataReader["nom_item"].ToString();
                        var description = dataReader["des_descr"].ToString();
                        var desdo = dataReader["ind_desdo"].ToBoolean();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();
                        var isActive = dataReader["ind_ativa"].ToBoolean();

                        var item = new ItemEntity(itemId, name, description, desdo, isActive, creationDate, lastUpdate);
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

                base.Initialize();
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_empre_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);

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

                        var item = new ItemEntity(id, name, description, desdo, isActive, creationDate, lastUpdate);
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

        public bool Relate(int companyId, int id, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_empre_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);
                    cmd.Parameters.AddWithValue("@id_item", id);
                    cmd.Parameters.AddWithValue("@cod_usu", userId);

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

        public bool UnRelate(int companyId, int id, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_del_empre_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);
                    cmd.Parameters.AddWithValue("@id_item", id);
                    cmd.Parameters.AddWithValue("@cod_usu", userId);

                    cmd.ExecuteNonQuery();
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

        public ItemEntity Update(ItemEntity item, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_upd_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@nom_item", item.Name);
                    cmd.Parameters.AddWithValue("@ind_desdo", item.Desdobramento);
                    cmd.Parameters.AddWithValue("@des_descr", item.Description);
                    cmd.Parameters.AddWithValue("@cod_usu", userId);

                    cmd.ExecuteNonQuery();

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

