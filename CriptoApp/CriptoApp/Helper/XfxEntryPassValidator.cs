using CriptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xfx;

namespace CriptoApp.Helper
{
    public class XfxEntryPassValidator : Behavior<XfxEntry>
    {
        static string Password = "";
        protected override void OnAttachedTo(XfxEntry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(XfxEntry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
        }

        public void Compare()
        {

        }

        UserSettingsViewModel userSettingsViewModel = new UserSettingsViewModel();
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            XfxEntry xfxEntry = (XfxEntry)sender;
            if (xfxEntry.StyleId == "Sifre")
                Password = xfxEntry.Text;


            if (xfxEntry.StyleId == "entSifreTekrar" && !string.IsNullOrEmpty(Password.Trim()) && xfxEntry.Text.Trim() == Password.Trim())
            {
                xfxEntry.BackgroundColor = Color.Transparent;
                userSettingsViewModel.RegisterButtonIsEnable = true;
            }
            else if (xfxEntry.StyleId == "entSifreTekrar")
            {
                xfxEntry.BackgroundColor = Color.Red;
                userSettingsViewModel.RegisterButtonIsEnable = false;
            }
        }
    }
}
