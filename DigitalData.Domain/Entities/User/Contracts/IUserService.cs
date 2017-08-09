using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User.Contracts
{
    public interface IUserService
    {
        UserEntity Create(UserEntity user);

        UserEntity GetByUsername(string userName);

        UserEntity Update(UserEntity user);

        IEnumerable<UserEntity> GetAllByCompany(int companyId);

        UserEntity GetByEmail(string userEmail);

        #region password        

        bool UpdatePassword(string psw, int userId);

        #endregion
    }
}
