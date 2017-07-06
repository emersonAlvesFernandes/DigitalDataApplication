﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Address.Contracts
{
    public interface IAddressRepository
    {
        AddressEntity CreateCompanyAddress(int companyId, AddressEntity address);

        AddressEntity UpdateCompanyAddress(int addressId, AddressEntity address);

        AddressEntity GetCompanyAddress(int companyId);

        AddressEntity GetById(int id);

    }
}