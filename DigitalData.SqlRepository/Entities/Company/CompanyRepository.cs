using DigitalData.Domain.Entities.Company.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Company;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Domain.Entities.Address.Contracts;
using DigitalData.Domain.Entities.Address;
using DigitalData.Utils;

namespace DigitalData.SqlRepository.Entities.Company
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {

        public CompanyEntity Create(CompanyEntity company)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {                    
                using (var cmd = new SqlCommand("spr_ins_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_empre", company.Name);
                    cmd.Parameters.AddWithValue("@des_cnpj", company.Cnpj);
                    cmd.Parameters.AddWithValue("@val_logo", company.Logo);
                    cmd.Parameters.AddWithValue("@des_site", company.WebSite);
                    cmd.Parameters.AddWithValue("@des_email", company.Email);
                    cmd.Parameters.AddWithValue("@dat_criac", company.CreationDate);
                    cmd.Parameters.AddWithValue("@dat_atual", company.LastUpdate);
                    cmd.Parameters.AddWithValue("@ind_ativa", company.IsActive);
                    
                    var id = (int)cmd.ExecuteScalar();
                    var c = new CompanyEntity(id, company);
                    return c;
                }                
            }
            catch(Exception ex)
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
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_del_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_empre", id);
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

        public IEnumerable<CompanyEntity> GetAll()
        {
            try
            {
                var collection = new List<CompanyEntity>();

                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_empre", connection))
                {
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var id = dataReader["id"].ToInt32();
                        var name = dataReader["nom_empre"].ToString();
                        var cnpj = dataReader["des_cnpj"].ToString();
                        //var Logo = dataReader["val_logo"].,
                        var webSite = dataReader["des_site"].ToString();
                        var email = dataReader["des_email"].ToString();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();
                        var isActive = dataReader["ind_ativa"].ToBoolean();

                        var c = new CompanyEntity(id, name, cnpj, webSite, email, isActive, creationDate, lastUpdate);
                        collection.Add(c);
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

        public CompanyEntity GetById(int id)
        {
            try
            {                
                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var idCompany = dataReader["id"].ToInt32();
                        var name = dataReader["nom_empre"].ToString();
                        var cnpj = dataReader["des_cnpj"].ToString();
                        //var Logo = dataReader["val_logo"].,
                        var webSite = dataReader["des_site"].ToString();
                        var email = dataReader["des_email"].ToString();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();
                        var isActive = dataReader["ind_ativa"].ToBoolean();

                        var c = new CompanyEntity(idCompany, name, cnpj, webSite, email, isActive, creationDate, lastUpdate);
                        return c;
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

        public CompanyEntity Update(CompanyEntity company)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_upd_empre", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", company.Id);
                    cmd.Parameters.AddWithValue("@nom_empre", company.Name);
                    cmd.Parameters.AddWithValue("@des_cnpj", company.Cnpj);
                    cmd.Parameters.AddWithValue("@val_logo", company.Logo);
                    cmd.Parameters.AddWithValue("@des_site", company.WebSite);
                    cmd.Parameters.AddWithValue("@des_email", company.Email);
                    
                    cmd.ExecuteNonQuery();
                    
                    return company;
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

        public IEnumerable<CompanyEntity> GetCompanyByItem(int itemId)
        {
            try
            {
                var collection = new List<CompanyEntity>();

                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_empresa_por_item", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_item", itemId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var id = dataReader["id"].ToInt32();
                        var name = dataReader["nom_empre"].ToString();
                        var cnpj = dataReader["des_cnpj"].ToString();
                        //var Logo = dataReader["val_logo"].,
                        var webSite = dataReader["des_site"].ToString();
                        var email = dataReader["des_email"].ToString();
                        var creationDate = dataReader["dat_criac"].ToDateTime();
                        var lastUpdate = dataReader["dat_atual"].ToDateTime();
                        var isActive = dataReader["ind_ativa"].ToBoolean();

                        var c = new CompanyEntity(id, name, cnpj, webSite, email, isActive, creationDate, lastUpdate);
                        collection.Add(c);
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

        public int GetCompanyItemSubItemRelationId(int companyId, int itemId, int? subItemId)
        {
            try
            {
                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();
                var id = 0;

                using (var cmd = new SqlCommand("spr_ler_empre_item_subitem_id", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);
                    cmd.Parameters.AddWithValue("@id_item", itemId);
                    cmd.Parameters.AddWithValue("@id_subitem", subItemId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        id = dataReader["id"].ToInt32();                        
                    }                    
                }
                return id;
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

        public bool CreateCompanyUserRelation(int userId, int companyId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_empre_usuar", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", userId);
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);

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
    }
}
