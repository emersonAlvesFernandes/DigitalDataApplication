using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.SqlRepository.Contracts
{
    public interface IRepositoryBase
    {
        bool OpenConnection();

        bool CloseConnection();

        void Initialize();
    }
}
