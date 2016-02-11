using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class Drone
  {
    public int Id { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public Dictionary<Order, List<OrderLine>> CommandesPartielles { get; set; }

    public int CalculeDistance(int x, int y)
    {
      return (int)Math.Ceiling(Math.Sqrt(Math.Pow(Math.Abs(this.X - x), 2) + Math.Pow(Math.Abs(this.Y - y), 2)));
    }

    public int PoidsCourant
    {
      get
      {
        return this.CommandesPartielles.Sum(item1 => item1.Value.Sum(item2 => item2.Poids));
      }
    }
  }
}
