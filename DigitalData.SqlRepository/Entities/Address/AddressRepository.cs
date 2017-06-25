using DigitalData.Domain.Entities.Address.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Address;
using System.Data.SqlClient;
using System.Data;

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
    }
}
