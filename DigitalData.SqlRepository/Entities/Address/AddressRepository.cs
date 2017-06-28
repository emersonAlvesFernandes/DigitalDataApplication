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
                    cmd.Parameters.AddWithValue("@id_empre", entityId);
                    cmd.Parameters.AddWithValue("@des_logra", address.Address);
                    cmd.Parameters.AddWithValue("@num_logra", address.Number);
                    cmd.Parameters.AddWithValue("@num_cep", address.Zipcode);
                    cmd.Parameters.AddWithValue("@val_compl", address.Complement);
                    cmd.Parameters.AddWithValue("@nom_cidad", address.City);
                    cmd.Parameters.AddWithValue("@nom_estad", address.State);
                    cmd.Parameters.AddWithValue("@nom_bairr", address.Neighborhood);

                    var Id = (int)cmd.ExecuteScalar();
                    var newAddress = new AddressEntity(Id, address);
                    return newAddress;
                }                                                
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

                        var Id = dataReader["id"].ToInt32();
                        var Address = dataReader["des_logra"].ToString();
                        var Number = dataReader["num_logra"].ToString();
                        var Complement = dataReader["val_compl"].ToString();
                        var Zipcode = dataReader["num_cep"].ToString();
                        var Neighborhood = dataReader["nom_bairr"].ToString();
                        var City = dataReader["nom_cidad"].ToString();
                        var State = dataReader["nom_estad"].ToString();


                        var address = new AddressEntity(Id, Address,
                            Number, Complement, Zipcode, Neighborhood,
                            City, State);
                        

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
                    
                    var Id = (int)cmd.ExecuteScalar();
                    var newAddress = new AddressEntity(Id, address);
                    return newAddress;
                }                                
            }
            finally
            {
                base.CloseConnection();
            }
        }
    }
}
