using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class OrderLineEnLivraison
  {
    public int IdCommande { get; set; }

    public Product Produit { get; set; }

    public int QteLivree { get; set; }

    public int QteCommandee { get; set; }

    public bool EstLivree
    {
      get
      {
        return this.QteLivree >= this.QteCommandee;
      }
    }

    public int Poids
    {
      get
      {
        return (this.QteCommandee - this.QteLivree) * this.Produit.Poids;
      }
    }

    public int TourAvantLivraison { get; set; }
  }
}
