using CriptoApp.Validator;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CriptoApp.Helper
{
    public class ValidationGroupBehavior : Behavior<View>
    {
        View _view;
        IErrorStyle _style = new BasicErrorStyle();
        public string PropertyName { get; set; }

        IList<ValidationBehavior> _validationBehaviors;
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create("IsValid",
                                    typeof(bool),
                                    typeof(ValidationGroupBehavior),
                                    false);
        public ValidationGroupBehavior()
        {
            _validationBehaviors = new List<ValidationBehavior>();
        }

        public void Add(ValidationBehavior validationBehavior)
        {
            _validationBehaviors.Add(validationBehavior);
        }

        public void Remove(ValidationBehavior validationBehavior)
        {
            _validationBehaviors.Remove(validationBehavior);
        }

        public void Update()
        {
            bool isValid = true;

            foreach (ValidationBehavior validationItem in _validationBehaviors)
            {
                isValid = isValid && validationItem.Validate();
            }

            IsValid = isValid;
        }

        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }
        
    }
}
