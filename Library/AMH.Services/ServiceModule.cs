//-----------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace AMH.Services
{
    using Autofac;
    using Data;
    using AMH.Services.Contract;
    
    /// <summary>
    /// The Service module for dependency injection.
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataModule>();
            builder.RegisterType<V1.CategoryServices>().As<AbstractCategoryServices>().InstancePerDependency();
            builder.RegisterType<V1.AddressMasterServices>().As<AbstractAddressMasterServices>().InstancePerDependency();
            builder.RegisterType<V1.AppointmentServices>().As<AbstractAppointmentServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterAppointmentStatusServices>().As<AbstractMasterAppointmentStatusServices>().InstancePerDependency();
            builder.RegisterType<V1.CityMasterServices>().As<AbstractCityMasterServices>().InstancePerDependency();
            builder.RegisterType<V1.DepartmentServices>().As<AbstractDepartmentServices>().InstancePerDependency();
            builder.RegisterType<V1.StateMasterServices>().As<AbstractStateMasterServices>().InstancePerDependency();
            builder.RegisterType<V1.CountryMasterServices>().As<AbstractCountryMasterServices>().InstancePerDependency();
            builder.RegisterType<V1.AdminServices>().As<AbstractAdminServices>().InstancePerDependency();
            builder.RegisterType<V1.CustomerServices>().As<AbstractCustomerServices>().InstancePerDependency();
            builder.RegisterType<V1.StudentServices>().As<AbstractStudentServices>().InstancePerDependency();
            builder.RegisterType<V1.EmployeesServices>().As<AbstractEmployeesServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterCountryServices>().As<AbstractMasterCountryServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterEmCountryServices>().As<AbstractMasterEmCountryServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterCityServices>().As<AbstractMasterCityServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterEmCityServices>().As<AbstractMasterEmCityServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterStateServices>().As<AbstractMasterStateServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterEmStateServices>().As<AbstractMasterEmStateServices>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
