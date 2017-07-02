using DigitalData.AppService;
using DigitalData.Domain.Entities.Address.Contracts;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.Service;
using DigitalData.SqlRepository;
using DigitalData.SqlRepository.Contracts;
using DigitalData.SqlRepository.Entities.Address;
using DigitalData.SqlRepository.Entities.Company;
using DigitalData.SqlRepository.Entities.Item;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace DigitalData.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<ICompanyAppService, CompanyAppService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IAddressRepository, AddressRepository>();

            container.RegisterType<IItemAppService, ItemAppService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemRepository, ItemRepository>();

            container.RegisterType<IRepositoryBase, RepositoryBase>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}