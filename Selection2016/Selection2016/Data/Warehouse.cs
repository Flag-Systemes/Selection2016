using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class Warehouse
  {
    public int X { get; set; }

    public int Y { get; set; }

    public Dictionary<Product, int> RepartitionProduit { get; set; }

    public Dictionary<Product, int> CloneRepartitionProduit()
    {
      return new Dictionary<Product, int>();
    }
  }
}
