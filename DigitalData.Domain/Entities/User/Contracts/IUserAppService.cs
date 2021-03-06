﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User.Contracts
{
    public interface IUserAppService
    {
        UserEntity Create(UserEntity user, int roleId);

        //UserEntity IsValid(string userName, string psw);

        UserEntity Update(UserEntity user);

        IEnumerable<UserEntity> GetAllByCompany(int companyId);
        
        bool UpdatePassword(string newPsw, string oldPsw, string userName);        
    }
}
