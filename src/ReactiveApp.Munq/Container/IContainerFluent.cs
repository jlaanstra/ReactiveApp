// --------------------------------------------------------------------------------------------------
// � Copyright 2011 by Matthew Dennis.
// Released under the Microsoft Public License (Ms-PL) http://www.opensource.org/licenses/ms-pl.html
// --------------------------------------------------------------------------------------------------

using System;

namespace Munq
{
    /// <summary>
    /// The IContainerFluent interface defined the fluent interface that can be used to configure
    /// the IocContainer.
    /// </summary>
    public interface IContainerFluent
    {
        /// <summary>
        /// Sets the LifetimeManager that will be used on new Registrations by default.  This can 
        /// be changed calling WithRegistration on the IRegistration returned from a call to Register.
        /// </summary>
        /// <param name="lifetimeManager">The Lifetime manager to use.</param>
        /// <returns>'this' so that the method calls can be chained.</returns>
        /// <example>
        /// <para>
        /// This example shows how an application wide instance of the IOC Container could be created
        /// and configured to scope resolved instances to the HttpRequest lifetime as a default.
        /// </para>
        /// <para>
        /// The class MyDatabase implements the IDatabase interface, and requires an instance of
        /// a class implementing ILogger as a constructor parameter.  The same instance of MyDatabase
        /// will be used for all instances Resolved for the duration of the current Http Request.
        /// The ILogger can be a Singleton and so the LifetimeManager is explicitly set.
        /// </para>
        /// <code>
        ///     public class MyIocContainer
        ///     {
        ///         private static Container _container;
        ///         private static ILifetimeManager _defaultLifetimeManager = new RequestLifetime();
        ///
        ///         public Container Container { get { return _container; } }
        ///
        ///        // Initializes the Container to use the HttpRequest Lifetime Manager to scope
        ///         // the resolved object to the current HttpRequest by default.
        ///         public static MyContainer()
        ///         {
        ///              _container = new IocContainer();
        ///              Container.UsesDefaultLifetimeManagerOf(_defaultLifetimeManager);
        ///		 
        ///              Container.Register&lt;IDatabase, MyDatabase&gt;(); // RequestLifetime
        ///              Container.Register&lt;ILogger, MyLogger&gt;().WithLifetimeManager(new ContainerLifetime());
        ///         }
        ///     }
        /// </code>
        ///</example>
        IContainerFluent UsesDefaultLifetimeManagerOf(ILifetimeManager lifetimeManager);
    }
}
