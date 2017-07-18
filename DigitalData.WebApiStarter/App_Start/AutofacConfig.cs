using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.AppService;
using DigitalData.SqlRepository.Contracts;
using DigitalData.SqlRepository;
using DigitalData.Service;
using DigitalData.SqlRepository.Entities.Company;
using DigitalData.Domain.Entities.Address.Contracts;
using DigitalData.Domain.Entities.SubItem.Contracts;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.Domain.Entities.Planning.Contracts;
using DigitalData.Domain.Entities.User.Contracts;
using DigitalData.Domain.AdminData;
using DigitalData.SqlRepository.Entities.User;
using DigitalData.SqlRepository.Entities.Planning;
using DigitalData.SqlRepository.Entities.SubItem;
using DigitalData.SqlRepository.Entities.Item;
using DigitalData.SqlRepository.Entities.Address;

namespace DigitalData.WebApiStarter.App_Start
{
    /// <summary>
    /// Represent Autofac configuration.
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Configured instance of <see cref="IContainer"/>
        /// <remarks><see cref="AutofacConfig.Configure"/> must be called before trying to get Container instance.</remarks>
        /// </summary>
        public static IContainer Container;

        /// <summary>
        /// Initializes and configures instance of <see cref="IContainer"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Other components can be registered here.


            builder.RegisterType<CompanyAppService>().As<ICompanyAppService>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IAddressService>().As<AddressService>().InstancePerLifetimeScope();
            //builder.RegisterType<IAddressRepository>().As<AddressRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IItemAppService>().As<ItemAppService>().InstancePerLifetimeScope();
            //builder.RegisterType<IItemService>().As<ItemService>().InstancePerLifetimeScope();
            //builder.RegisterType<IItemRepository>().As<ItemRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<ISubItemAppService>().As<SubItemAppService>().InstancePerLifetimeScope();
            //builder.RegisterType<ISubItemService>().As<SubItemService>().InstancePerLifetimeScope();
            //builder.RegisterType<ISubItemRepository>().As<SubItemRepository>().InstancePerLifetimeScope();


            //builder.RegisterType<IPlanningAppService>().As<PlanningAppService>().InstancePerLifetimeScope();
            //builder.RegisterType<IPlanningService>().As<PlanningService>().InstancePerLifetimeScope();
            //builder.RegisterType<IPlanningRepository>().As<PlanningRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IUserAppService>().As<UserAppService>().InstancePerLifetimeScope();
            //builder.RegisterType<IUserService>().As<UserService>().InstancePerLifetimeScope();
            //builder.RegisterType<IUserRepository>().As<UserRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IRoleService>().As<RoleService>().InstancePerLifetimeScope();
            //builder.RegisterType<IRoleRepository>().As<RoleRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IFuncionalityService>().As<FunctionalityService>().InstancePerLifetimeScope();
            //builder.RegisterType<IFunctionalityRepository>().As<FunctionalityRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IAdminDataAppService>().As<AdminDataAppService>().InstancePerLifetimeScope();
            //builder.RegisterType<IAdminDataService>().As<AdminDataService>().InstancePerLifetimeScope();
            //builder.RegisterType<IAdminDataRepository>().As<AdminDataRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<IRepositoryBase>().As<RepositoryBase>().InstancePerLifetimeScope();



            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}