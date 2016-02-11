using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class Order
  {
    public Dictionary<Product, Tuple<int, int>> Produits { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int PoidsTotal
    {
      get
      {
        return this.Produits.Sum(item => item.Key.Poids);
      }
    }


  }
}
