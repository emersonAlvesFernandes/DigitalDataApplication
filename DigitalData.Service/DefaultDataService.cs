using DigitalData.Domain.Default;
using DigitalData.SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Create(DefaultData defaultData)
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
