﻿using DigitalData.AppService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Default;
using DigitalData.Service;
using DigitalData.Domain.Contracts.Default;

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
