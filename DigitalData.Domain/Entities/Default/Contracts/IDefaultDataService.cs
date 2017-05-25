using System.Collections.Generic;

namespace DigitalData.Domain.Entities.Default.Contracts.Default
{
    public interface IDefaultDataService
    {
        DefaultData Create(DefaultData defaultData);

        IEnumerable<DefaultData> Read();

        DefaultData Read(int id);
    }
}
