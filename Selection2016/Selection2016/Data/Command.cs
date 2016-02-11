using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class Command
  {
    public Drone Drone { get; set; }

    public CommandType TypeOrdre { get; set; }

    public int IdOrder { get; set; }

    public Product Produit { get; set; }

    public int QteLivree { get; set; }

    public int NbToursAttente { get; set; }

    public override string ToString()
    {
      StringBuilder resultat = new StringBuilder();

      resultat.Append(this.Drone.Id);
      resultat.Append(this.TypeOrdre.ToString());
      if (this.TypeOrdre != CommandType.Wait)
      {
        resultat.Append(this.IdOrder);
        resultat.Append(this.Produit.Id);
        resultat.Append(this.QteLivree);
      }
      else
      {
        resultat.Append(this.NbToursAttente);
      }

      return resultat.ToString();
    }
  }

  public enum CommandType
  {
    Load = 'L',
    Deliver = 'D',
    Unload = 'U',
    Wait = 'W'
  }
}
