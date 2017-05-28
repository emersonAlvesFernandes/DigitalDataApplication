using DigitalData.Domain.Contracts.Default;
using DigitalData.Domain.Entities.Default;
using DigitalData.Domain.Entities.Default.Contracts.Default;
using DigitalData.SqlRepository;
using System.Collections.Generic;

namespace DigitalData.Service
{
    public class DefaultDataService : IDefaultDataService
    {
        private readonly IDefaultDataRepository defaultDataRepository;

        public DefaultDataService(IDefaultDataRepository defaultDataRepository)
        {
            this.defaultDataRepository = defaultDataRepository;
        }

        public DefaultDataService()
        {
            this.defaultDataRepository = new DefaultDataRepository();
        }

        public DefaultData Create(DefaultData defaultData)
        {            
            return defaultDataRepository.Create(defaultData);
        }

        public IEnumerable<DefaultData> Read()
        {
            return defaultDataRepository.Read();
        }

        public DefaultData Read(int id)
        {
            return defaultDataRepository.Read(id);
        }
    }
}
