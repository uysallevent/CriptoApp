namespace CriptoApp.Models
{
    public class UserPortfoyModel : BaseModel
    {

        private int _SQLServerID;
        public int SQLServerID
        {
            get { return _SQLServerID; }
            set
            {
                _SQLServerID = value;
                OnPropertyChange("SQLServerID");
            }
        }
        public int UserId { get; set; }

        private string _CriptoName;
        public string CriptoName
        {
            get { return _CriptoName; }
            set
            {
                _CriptoName = value;
                OnPropertyChange("CriptoName");
            }
        }

        private string _CriptoSymbol;
        public string CriptoSymbol
        {
            get { return _CriptoSymbol; }
            set
            {
                _CriptoSymbol = value;
                OnPropertyChange("CriptoSymbol");
            }
        }

        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChange("Price");
            }
        }

        private decimal _PurchasePrice;
        public decimal PurchasePrice
        {
            get { return _PurchasePrice; }
            set
            {
                _PurchasePrice = value;
                OnPropertyChange("PurchasePrice");
            }
        }

        private decimal _StopLoss;
        public decimal StopLoss
        {
            get { return _StopLoss; }
            set
            {
                _StopLoss = value;
                OnPropertyChange("StopLoss");
            }
        }

        private decimal _Quantity;
        public decimal Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChange("Quantity");
            }
        }

    }
}
