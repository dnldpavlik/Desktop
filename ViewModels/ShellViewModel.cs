
namespace DonPavlik.Desktop.ViewModels
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel.Composition;
	using Caliburn.Micro;
	using DonPavlik.Desktop.Infrastructure;
	using DonPavlik.Desktop.Infrastructure.Interfaces;

	[Export(typeof(IShell))]
	public class ShellViewModel : PropertyChangedBase, IShell, IPartImportsSatisfiedNotification
	{
		public ShellViewModel()
		{
			this.Modules = new ObservableCollection<IModule>();
		}

		[ImportMany(typeof(IModule))]
		public ObservableCollection<IModule> Modules { get; set; }

		public IModule Module { get; set; }

		public void CloseShell()
		{
			App.Current.MainWindow.Close();
		}

		public void OnImportsSatisfied()
		{
			this.Module = this.Modules[0];
			this.NotifyOfPropertyChange(() => this.Module);
			this.NotifyOfPropertyChange(() => this.Modules);
		}
	}
}
