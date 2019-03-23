using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xfx;

namespace CriptoApp.Helper
{
    public class EntryDecimalCheckBehavior : Behavior<XfxEntry>
    {
        protected override void OnAttachedTo(XfxEntry entry)
        {
            entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(XfxEntry entry)
        {
            entry.TextChanged -= Entry_TextChanged;
            base.OnDetachingFrom(entry);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((XfxEntry)sender).Text = ((XfxEntry)sender).Text.Replace(",",".");
        }
    }
}
