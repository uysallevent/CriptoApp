using CriptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xfx;

namespace CriptoApp.Helper
{
    public class CompareValidationBehavior : Behavior<XfxEntry>
    {
        public static BindableProperty TextProperty = BindableProperty.Create<CompareValidationBehavior, string>(x => x.Text, string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        protected override void OnAttachedTo(XfxEntry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        UserSettingsViewModel userSettingsViewModel = new UserSettingsViewModel();
        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = e.NewTextValue == Text;
            if (!IsValid)
                ((XfxEntry)sender).ErrorText = "Şifre Uyuşmamaktadır";
            else
                ((XfxEntry)sender).ErrorText = "";
            ((XfxEntry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }


        protected override void OnDetachingFrom(XfxEntry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
