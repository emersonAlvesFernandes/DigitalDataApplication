using DigitalData.AppService.Contracts;
using System.Collections.Generic;
using DigitalData.Service;
using DigitalData.Domain.Entities.Default;
using DigitalData.Domain.Entities.Default.Contracts.Default;

namespace DigitalData.AppService
{
    public class DefaultDataAppService : IDefaultDataAppService
    {
        private readonly IDefaultDataService defaultDataService;

        public DefaultDataAppService(IDefaultDataService defaultDataService)
        {
            this.defaultDataService = defaultDataService;
        }

        public DefaultDataAppService()
        {
            this.defaultDataService = new DefaultDataService();
        }

        public DefaultData Create(DefaultData defaultData)
        {
            return defaultDataService.Create(defaultData);
        }

        public IEnumerable<DefaultData> Read()
        {
            return defaultDataService.Read();
        }

        public DefaultData Read(int id)
        {
            return defaultDataService.Read(id);
        }

        public List<DefaultData> ImportExcelFile(DefaultDataExcel file)
        {
            file.SetDefaultData();
            return file.DefaultDataCollection;
        }
    }
}
