using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class OrderCost : IComparable
  {
    public int OrderID { get; set; }
    public int DroneID { get; set; }
    public decimal CompletionProduct { get; set; }
    public int DroneCost { get; set; }
    public int CostOrder { get; set; }

    public int CompareTo(object obj)
    {
      var orderCost = obj as OrderCost;
      int compare = this.CompletionProduct.CompareTo(orderCost.CompletionProduct);
      if (compare == 0)
      {
        compare = (orderCost.DroneCost + orderCost.CostOrder).CompareTo(this.DroneCost + this.CostOrder);
      }

      return compare;
    }
  }
}
