
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
        public CriptoListPage()
        {
            InitializeComponent();
            dgCripto = new Xamarin.Forms.DataGrid.DataGrid();
            BindingContext = viewModel = new CriptoListViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            //viewModel.client.Stop();
            base.OnDisappearing();
        }
    }
}