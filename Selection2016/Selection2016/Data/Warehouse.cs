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
      Dictionary<Product, int> resultat = new Dictionary<Product, int>();

      foreach(KeyValuePair<Product, int> item in this.RepartitionProduit)
      {
        resultat.Add(item.Key, item.Value);
      }

      return resultat;
    }

    public int CalculeDistance(Drone drone)
    {
      return drone.CalculeDistance(this.X, this.Y);
    }

    public int CalculeDistance(Order commande)
    {
      return commande.CalculeDistance(this.X, this.Y);
    }
  }
}
