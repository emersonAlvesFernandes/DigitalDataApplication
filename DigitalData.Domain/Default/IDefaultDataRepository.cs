using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Default
{
    public interface IDefaultDataRepository
    {
        DefaultData Create(DefaultData defaultData);

        IEnumerable<DefaultData> Read();

        DefaultData Read(int id);
    }
}
