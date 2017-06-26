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

                    company.Id = (int)cmd.ExecuteScalar();
                }

                return company;
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
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyEntity> GetAll()
        {

            var collection = new List<CompanyEntity>();            

            base.connection = new SqlConnection(connectionstring);
            this.OpenConnection();

            using (var cmd = new SqlCommand("spr_ler_empre", connection))
            {
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    var c = new CompanyEntity
                    {
                        Id = dataReader["id"].ToInt32(),
                        Name = dataReader["nom_empre"].ToString(),
                        //TODO: continuar aqui
                        
                    };
                    collection.Add(c);
                }

                dataReader.Close();
                base.CloseConnection();

                return collection;
            }
        }

        public CompanyEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyEntity Update(Domain.Entities.Company.CompanyEntity company)
        {
            throw new NotImplementedException();
        }
    }
}
