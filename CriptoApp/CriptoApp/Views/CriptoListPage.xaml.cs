
using CriptoApp.Models;
using CriptoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CriptoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CriptoListPage : ContentPage
	{
        CriptoListViewModel viewModel;
		public CriptoListPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new CriptoListViewModel(this.Navigation);
        }
    }
}