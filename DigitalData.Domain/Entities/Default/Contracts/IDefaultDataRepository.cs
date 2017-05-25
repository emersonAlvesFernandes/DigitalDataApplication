using DigitalData.Domain.Entities.Default;
using System.Collections.Generic;

namespace DigitalData.Domain.Contracts.Default
{
    public interface IDefaultDataRepository
    {
        DefaultData Create(DefaultData defaultData);

        IEnumerable<DefaultData> Read();

        DefaultData Read(int id);
    }
}
