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
            builder.RegisterType<V1.WishlistServices>().As<AbstractWishlistServices>().InstancePerDependency();
            builder.RegisterType<V1.UsersServices>().As<AbstractUsersServices>().InstancePerDependency();
            builder.RegisterType<V1.ProductServices>().As<AbstractProductServices>().InstancePerDependency();
            builder.RegisterType<V1.OrderAMHServices>().As<AbstractOrderAMHServices>().InstancePerDependency();
            builder.RegisterType<V1.GalleryServices>().As<AbstractGalleryServices>().InstancePerDependency();
            builder.RegisterType<V1.FeedbackServices>().As<AbstractFeedbackServices>().InstancePerDependency();
            builder.RegisterType<V1.CartServices>().As<AbstractCartServices>().InstancePerDependency();
            builder.RegisterType<V1.CategoryServices>().As<AbstractCategoryServices>().InstancePerDependency();
            builder.RegisterType<V1.SubCategoryServices>().As<AbstractSubCategoryServices>().InstancePerDependency();
            builder.RegisterType<V1.AdminServices>().As<AbstractAdminServices>().InstancePerDependency();
         
            base.Load(builder);
        }
    }
}
