
namespace DonPavlik.Desktop.Infrastructure
{
	using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Windows.Threading;
using Caliburn.Micro;

	public class DesktopBootstrapper : Bootstrapper<IShell>
	{
		public DesktopBootstrapper()
		{
		}

		protected override void Configure()
		{
			var batch = new CompositionBatch();
			batch.AddExportedValue<IWindowManager>(new WindowManager());
			batch.AddExportedValue<IEventAggregator>(new EventAggregator());
			batch.AddExportedValue(Container.Instance);
			Container.Instance.Compose(batch);
		}

		protected override IEnumerable<Assembly> SelectAssemblies()
		{
			List<Assembly> assemblies = new List<Assembly>();
			assemblies.Add(Assembly.LoadFrom("DonPavlik.Desktop.Contacts.dll"));
			assemblies.Add(Assembly.GetExecutingAssembly());
			return assemblies;
		}

		protected override object GetInstance(Type serviceType, string key)
		{
			string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
			var exports = Container.Instance.GetExportedValues<object>(contract);

			if (exports.Count() > 0)
				return exports.First();

			throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
		}

		protected override IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return Container.Instance.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
		}

		protected override void BuildUp(object instance)
		{
			Container.Instance.SatisfyImportsOnce(instance);
		}

		protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) 
		{
			System.Windows.MessageBox.Show(e.Exception.Message);
		}
	}
}
