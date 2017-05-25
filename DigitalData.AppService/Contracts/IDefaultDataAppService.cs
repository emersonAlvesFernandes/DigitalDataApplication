using DigitalData.Domain.Entities.Default;
using System.Collections.Generic;

namespace DigitalData.AppService.Contracts
{
    public interface IDefaultDataAppService
    {
        DefaultData Create(DefaultData defaultData);

        IEnumerable<DefaultData> Read();

        DefaultData Read(int id);

        List<DefaultData> ImportExcelFile(DefaultDataExcel file);
    }
}
