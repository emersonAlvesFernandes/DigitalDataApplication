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

            builder.RegisterType<AddressService>().As<IAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ItemAppService>().As<IItemAppService>().InstancePerLifetimeScope();
            builder.RegisterType<ItemService>().As<IItemService>().InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerLifetimeScope();

            builder.RegisterType<SubItemAppService>().As<ISubItemAppService>().InstancePerLifetimeScope();
            builder.RegisterType<SubItemService>().As<ISubItemService>().InstancePerLifetimeScope();
            builder.RegisterType<SubItemRepository>().As<ISubItemRepository>().InstancePerLifetimeScope();


            builder.RegisterType<PlanningAppService>().As<IPlanningAppService>().InstancePerLifetimeScope();
            builder.RegisterType<PlanningService>().As<IPlanningService>().InstancePerLifetimeScope();
            builder.RegisterType<PlanningRepository>().As<IPlanningRepository>().InstancePerLifetimeScope();

            builder.RegisterType<UserAppService>().As<IUserAppService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();

            builder.RegisterType<FunctionalityService>().As<IFuncionalityService>().InstancePerLifetimeScope();
            builder.RegisterType<FunctionalityRepository>().As<IFunctionalityRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AdminDataAppService>().As<IAdminDataAppService>().InstancePerLifetimeScope();
            builder.RegisterType<AdminDataService>().As<IAdminDataService>().InstancePerLifetimeScope();
            builder.RegisterType<AdminDataRepository>().As<IAdminDataRepository>().InstancePerLifetimeScope();

            builder.RegisterType<RepositoryBase>().As<IRepositoryBase>().InstancePerLifetimeScope();




            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}