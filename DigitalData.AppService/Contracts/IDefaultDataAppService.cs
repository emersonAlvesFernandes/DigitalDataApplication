using DigitalData.Domain.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
