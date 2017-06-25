using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Address.Contracts
{
    public interface IAddressService
    {
        AddressEntity CreateCompanyAddress(int companyId, AddressEntity address);
    }
}
