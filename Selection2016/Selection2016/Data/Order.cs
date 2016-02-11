using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class Order
  {
    public int Id { get; set; }

    public List<OrderLine> Lignes { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int CalculeDistance(int x, int y)
    {
      return (int)Math.Ceiling(Math.Sqrt(Math.Pow(Math.Abs(this.X - x), 2) + Math.Pow(Math.Abs(this.Y - y), 2)));
    }

    public int PoidsTotal
    {
      get
      {
        return this.Lignes.Sum(item => item.Poids);
      }
    }

    public int TourCompletion { get; set; }
  }
}
