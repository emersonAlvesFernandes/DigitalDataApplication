﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Company.Contracts
{
    public interface ICompanyService
    {
        CompanyEntity Create(CompanyEntity company);

        IEnumerable<CompanyEntity> GetAll();

        CompanyEntity GetById(int id);
        
        void Validate(int id);

        CompanyEntity Update(CompanyEntity company);

        bool Delete(int id);

        IEnumerable<CompanyEntity> GetCompanyByItem(int itemId);

        int GetCompanyItemSubItemRelationId(int compnyId, int itemId, int? subItemId);

        bool CreateCompanyUserRelation(int userId, int companyId);

    }
}
