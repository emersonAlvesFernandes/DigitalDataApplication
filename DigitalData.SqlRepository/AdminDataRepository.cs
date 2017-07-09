using DigitalData.Domain.AdminData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.SqlRepository
{
    public class AdminDataRepository : RepositoryBase, IAdminDataRepository
    {
        public bool DeleteAllData()
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_del_limpa_db", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;                    
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
