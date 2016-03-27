using System;
using System.Collections.Generic;
using System.Linq;

namespace RockMvvmForms
{
	public class RockServiceLocator
	{
		private static RockServiceLocator instance;

		private RockServiceLocator ()
		{
			services = new Dictionary<Type, object> ();
		}

		public static RockServiceLocator Current
		{
			get { return instance ?? (instance = new RockServiceLocator()); }
		}

		/// <summary>
		/// List of services
		/// </summary>
		private readonly Dictionary<Type, object> services;

		/// <summary>
		/// Gets the first available service
		/// </summary>
		/// <typeparam name="T">Type of service to get</typeparam>
		/// <returns>First available service if there are any, otherwise null</returns>
		public T Get<T>() where T : class
		{
			object service = null;
			if (services.TryGetValue (typeof(T), out service))
				return service as T;
			return default(T);
		}

		/// <summary>
		/// Registers a service provider
		/// </summary>
		/// <typeparam name="T">Type of the service</typeparam>
		/// <param name="service">Service provider</param>
		public RockServiceLocator Register<T>(T service) where T : class
		{
			var type = typeof(T);
			if (this.services.ContainsKey(type))
			{
				this.services.Remove (type);
			}

			this.services.Add (type, service);

			return this;
		}

		public RockServiceLocator Register<T, TImpl>()
			where T : class
			where TImpl : class, T
		{
			var service = Activator.CreateInstance (typeof(TImpl)) as T;
			return Register<T>(service);
		}

	}
}

