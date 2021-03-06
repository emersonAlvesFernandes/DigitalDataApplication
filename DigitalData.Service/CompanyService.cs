﻿using DigitalData.Domain.Entities.Company.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Company;
using DigitalData.SqlRepository.Entities.Company;
using DigitalData.Domain.Entities.Address.Contracts;
using DigitalData.Domain.Entities.Address;
using DigitalData.SqlRepository.Entities.Address;
using DigitalData.Domain.ApiException;

namespace DigitalData.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
                
        public CompanyService(ICompanyRepository repository)
        {
            this._companyRepository = repository;
        }

        public CompanyService()
        {
            this._companyRepository = new CompanyRepository();
        }



        public CompanyEntity Create(CompanyEntity company)
        {                        
            return _companyRepository.Create(company);
        }
        
        public bool Delete(int id)
        {
            return _companyRepository.Delete(id);
        }

        public IEnumerable<CompanyEntity> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public CompanyEntity GetById(int id)
        {
            return _companyRepository.GetById(id);
        }

        public void Validate(int id)
        {
            var company = _companyRepository.GetById(id);

            if(company == null)
                throw new InvalidCompanyException();            
        }

        public CompanyEntity Update(CompanyEntity company)
        {
            return _companyRepository.Update(company);
        }

        public IEnumerable<CompanyEntity> GetCompanyByItem(int itemId)
        {
            return _companyRepository.GetCompanyByItem(itemId);
        }

        public int GetCompanyItemSubItemRelationId(int companyId, int itemId, int? subItemId)
        {
            return _companyRepository.GetCompanyItemSubItemRelationId(companyId, itemId, subItemId);
        }

        public bool CreateCompanyUserRelation(int userId, int companyId)
        {
            return _companyRepository.CreateCompanyUserRelation(userId, companyId);
        }
    }
}
