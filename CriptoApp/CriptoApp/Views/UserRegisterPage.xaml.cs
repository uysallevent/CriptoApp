using CriptoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CriptoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserRegisterPage : ContentPage
	{
        UserRegisterViewModel viewModel;
        public UserRegisterPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new UserRegisterViewModel(this.Navigation);
        }
    }
}