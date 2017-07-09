using DigitalData.AppService;
using DigitalData.Domain.AdminData;
using DigitalData.Domain.Entities.Address.Contracts;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.Domain.Entities.Planning.Contracts;
using DigitalData.Domain.Entities.SubItem.Contracts;
using DigitalData.Service;
using DigitalData.SqlRepository;
using DigitalData.SqlRepository.Contracts;
using DigitalData.SqlRepository.Entities.Address;
using DigitalData.SqlRepository.Entities.Company;
using DigitalData.SqlRepository.Entities.Item;
using DigitalData.SqlRepository.Entities.Planning;
using DigitalData.SqlRepository.Entities.SubItem;
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

            #region Company

            container.RegisterType<ICompanyAppService, CompanyAppService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();

            #endregion

            #region Address

            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IAddressRepository, AddressRepository>();

            #endregion

            #region Item

            container.RegisterType<IItemAppService, ItemAppService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemRepository, ItemRepository>();

            #endregion

            #region SubItem

            container.RegisterType<ISubItemAppService, SubItemAppService>();
            container.RegisterType<ISubItemService, SubItemService>();
            container.RegisterType<ISubItemRepository, SubItemRepository>();

            #endregion

            #region Planning

            container.RegisterType<IPlanningAppService, PlanningAppService>();
            container.RegisterType<IPlanningService, PlanningService>();
            container.RegisterType<IPlanningRepository, PlanningRepository>();

            #endregion

            container.RegisterType<IAdminDataAppService, AdminDataAppService>();
            container.RegisterType<IAdminDataService, AdminDataService>();
            container.RegisterType<IAdminDataRepository, AdminDataRepository>();

            container.RegisterType<IRepositoryBase, RepositoryBase>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}