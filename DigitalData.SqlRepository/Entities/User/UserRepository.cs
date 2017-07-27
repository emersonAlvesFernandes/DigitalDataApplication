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
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserEntity Create(UserEntity user)
        {
            base.Initialize();
            base.OpenConnection();
            try
            {
                using (var cmd = new SqlCommand("spr_ins_usuar", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@des_nome", user.FirstName);
                    cmd.Parameters.AddWithValue("@des_sobrenome", user.LastName);
                    cmd.Parameters.AddWithValue("@des_email", user.Email);
                    cmd.Parameters.AddWithValue("@des_cpf", user.Document);
                    cmd.Parameters.AddWithValue("@des_username", user.UserName);
                    cmd.Parameters.AddWithValue("@des_psw", user.Password);                    
                    cmd.Parameters.AddWithValue("@des_phone1", user.Phone1);
                    cmd.Parameters.AddWithValue("@des_phone2", user.Phone2);
                    cmd.Parameters.AddWithValue("@dat_criac", user.RegisterDate);
                    cmd.Parameters.AddWithValue("@ind_ativo", user.IsActive);

                    var id = (int)cmd.ExecuteScalar();
                    user.Id = id;
                    return user;
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

        public IEnumerable<UserEntity> GetAllByCompany(int companyId)
        {

            base.Initialize();
            base.OpenConnection();
            try
            {
                var collection = new List<UserEntity>();

                //base.connection = new SqlConnection(connectionstring);
                //this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_usuario_empresa", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_empresa", companyId);

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var id = dataReader["id"].ToInt32();
                        var firstName = dataReader["des_nome"].ToString();
                        var lasttName = dataReader["des_sobrenome"].ToString();
                        var email = dataReader["des_email"].ToString();
                        var document = dataReader["des_cpf"].ToString();
                        var username = dataReader["des_username"].ToString();
                        var password = dataReader["des_psw"].ToString();                       
                        //var password = "****************";
                        var phone1 = dataReader["des_phone1"].ToString();
                        var phone2 = dataReader["des_phone2"].ToString();
                        var registerDate = dataReader["dat_criac"].ToDateTime();
                        
                        var c = new UserEntity(id, firstName, lasttName, email, document, username, password, phone1, phone2, registerDate);
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

        public UserEntity GetByUsername(string userName)
        {            
            try
            {
                base.Initialize();
                base.OpenConnection();

                //base.connection = new SqlConnection(connectionstring);
                //this.OpenConnection();

                using (var cmd = new SqlCommand("spr_ler_usuario_por_username", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@des_username", userName.ToLower().Trim());

                    var dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        var id = dataReader["id"].ToInt32();
                        var firstName = dataReader["des_nome"].ToString();
                        var lasttName = dataReader["des_sobrenome"].ToString();
                        var email = dataReader["des_email"].ToString();
                        var document = dataReader["des_cpf"].ToString();
                        var username = dataReader["des_username"].ToString();
                        var password = dataReader["des_psw"].ToString();
                        var phone1 = dataReader["des_phone1"].ToString();
                        var phone2 = dataReader["des_phone2"].ToString();
                        var registerDate = dataReader["dat_criac"].ToDateTime();
                        var companyId = dataReader["id_empresa"].ToInt32();

                        var c = new UserEntity(id, firstName, lasttName, email, document,
                            username, password, phone1, phone2, registerDate);

                        c.CompanyId = companyId;

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
        
        //
        public UserEntity Update(UserEntity user)
        {
            throw new NotImplementedException();
        }
        //
        public bool UpdatePassword(string psw, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

