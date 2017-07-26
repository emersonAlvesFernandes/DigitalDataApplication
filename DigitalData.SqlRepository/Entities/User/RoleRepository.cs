using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;
using System.Data.SqlClient;
using System.Data;
using DigitalData.Utils;

namespace DigitalData.SqlRepository.Entities.User
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        public bool CreateRelation(int roleId, int userId)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_usuario_perfil", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_usuario", userId);
                    cmd.Parameters.AddWithValue("@id_perfil", roleId);

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

        public bool DeleteRelation(int roleId, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                base.Initialize();
                base.OpenConnection();
                var roleCollection = new List<Role>();
                using (var cmd = new SqlCommand("spr_ler_perfil", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var id = dataReader["id"].ToInt32();
                        var description = dataReader["des_perfil"].ToString();

                        var role = new Role(id, description);
                        roleCollection.Add(role);
                    }
                    return roleCollection;
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

        public Role GetByUser(int userId)
        {
            try
            {
                base.Initialize();
                base.OpenConnection();
                
                using (var cmd = new SqlCommand("spr_ler_perfil_usuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", userId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var id = dataReader["id"].ToInt32();
                        var description = dataReader["des_perfil"].ToString();

                        var role = new Role(id, description);
                        return role;
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

        public bool UpdateRelation(int roleId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
