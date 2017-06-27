using DigitalData.Domain.Entities.Address.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Address;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Utils;

namespace DigitalData.SqlRepository.Entities.Address
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressEntity CreateCompanyAddress(int entityId, AddressEntity address)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_empre_ender", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@des_logra", address.Address);
                    cmd.Parameters.AddWithValue("@num_logra", address.Number);
                    cmd.Parameters.AddWithValue("@num_cep", address.Zipcode);
                    cmd.Parameters.AddWithValue("@val_compl", address.Complement);
                    cmd.Parameters.AddWithValue("@nom_cidad", address.City);
                    cmd.Parameters.AddWithValue("@nom_estad", address.State);
                    cmd.Parameters.AddWithValue("@nom_bairr", address.Neighborhood);

                    address.Id = (int)cmd.ExecuteScalar();

                }

                base.CloseConnection();

                return address;
            }
            finally
            {
                base.CloseConnection();
            }
        }

        public AddressEntity GetCompanyAddress(int companyId)
        {
            try
            {
                base.connection = new SqlConnection(connectionstring);
                this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_empre_ender", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empre", companyId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var address = new AddressEntity()
                        {
                            Id = dataReader["id"].ToInt32(),
                            Address = dataReader["des_logra"].ToString(),
                            Number = dataReader["num_logra"].ToString(),
                            Complement = dataReader["val_compl"].ToString(),
                            Zipcode = dataReader["num_cep"].ToString(),
                            Neighborhood = dataReader["nom_bairr"].ToString(),
                            City = dataReader["nom_cidad"].ToString(),
                            State = dataReader["nom_estad"].ToString()
                        };

                        return address;                        
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

        public AddressEntity UpdateCompanyAddress(int companyId, AddressEntity address)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_upd_empre_ender", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", address.Id);
                    cmd.Parameters.AddWithValue("@des_logra", address.Address);
                    cmd.Parameters.AddWithValue("@num_logra", address.Number);
                    cmd.Parameters.AddWithValue("@num_cep", address.Zipcode);
                    cmd.Parameters.AddWithValue("@val_compl", address.Complement);
                    cmd.Parameters.AddWithValue("@nom_cidad", address.City);
                    cmd.Parameters.AddWithValue("@nom_estad", address.State);
                    cmd.Parameters.AddWithValue("@nom_bairr", address.Neighborhood);

                    address.Id = (int)cmd.ExecuteScalar();

                }

                base.CloseConnection();

                return address;
            }
            finally
            {
                base.CloseConnection();
            }
        }
    }
}
