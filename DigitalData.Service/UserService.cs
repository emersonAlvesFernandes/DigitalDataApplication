using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;

namespace DigitalData.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;        
        }
        

        public UserEntity Create(UserEntity user)
        {
            return _userRepository.Create(user);
        }

        public UserEntity GetByUsername(string userName)
        {
            return _userRepository.GetByUsername(userName);
        }

        public UserEntity GetByEmail(string userEmail)
        {
            return _userRepository.GetByEmail(userEmail);
        }

        public IEnumerable<UserEntity> GetAllByCompany(int companyId)
        {
            return _userRepository.GetAllByCompany(companyId);
        }        

        public UserEntity Update(UserEntity user)
        {
            return _userRepository.Update(user);
        }

        public bool UpdatePassword(string psw, int userId)
        {
            return _userRepository.UpdatePassword(psw, userId);
        }
    }
}
