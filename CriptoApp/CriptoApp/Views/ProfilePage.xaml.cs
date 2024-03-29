﻿using CriptoApp.Models;
using CriptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CriptoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        ProfileViewModel viewModel;
        public ProfilePage (CurrencyServiceModel selected)
		{
			InitializeComponent ();
            BindingContext = viewModel = new ProfileViewModel(selected);

        }
	}
}