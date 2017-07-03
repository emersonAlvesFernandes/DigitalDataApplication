using DigitalData.Domain.Entities.Address.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Address;
using DigitalData.SqlRepository.Entities.Address;

namespace DigitalData.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            this._repository = repository;
        }

        public AddressService()
        {
            this._repository = new AddressRepository();
        }

        public AddressEntity CreateCompanyAddress(int companyId, AddressEntity address)
        {
            return _repository.CreateCompanyAddress(companyId, address);
        }

        public AddressEntity UpdateCompanyAddress(int addressId, AddressEntity address)
        {
            return _repository.UpdateCompanyAddress(addressId, address);
        }

        public AddressEntity GetCompanyAddress(int companyId)
        {
            return _repository.GetCompanyAddress(companyId);
        }

        public AddressEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
