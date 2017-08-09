using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User.Contracts
{
    public interface IUserRepository
    {
        UserEntity Create(UserEntity user);

        UserEntity Update(UserEntity user);

        UserEntity GetByUsername(string userName);

        UserEntity GetByEmail(string userName);

        IEnumerable<UserEntity> GetAllByCompany(int companyId);


        #region password
        
        bool UpdatePassword(string psw, int userId);

        #endregion

    }
}
