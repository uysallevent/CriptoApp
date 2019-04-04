using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CriptoApp.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {
            Crated = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int? IsDeleted { get; set; }

        public DateTime? Crated { get; set; }

        public string CreatedDateFormat { get { return Crated.Value.ToString("dd.MM.yyyy"); } }

        public DateTime? Update { get; set; }

        public DateTime? Delete { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
