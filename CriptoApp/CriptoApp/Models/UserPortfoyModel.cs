using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoApp.Models
{
    public class UserPortfoyModel: BaseModel
    {
        public int UserId { get; set; }

        public string CriptoName { get; set; }

        public string CriptoSymbol { get; set; }

        public decimal Price { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal StopLoss { get; set; }

        public decimal Quantity { get; set; }

    }
}
