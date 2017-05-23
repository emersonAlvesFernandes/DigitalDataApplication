using DigitalData.Domain.Contracts.Default;
using DigitalData.Domain.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.SqlRepository
{
    public class DefaultDataRepository : IDefaultDataRepository
    {
        public DefaultData Create(DefaultData defaultData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DefaultData> Read()
        {
            throw new NotImplementedException();
        }

        public DefaultData Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
