using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection2016.Data
{
  public class Ordonanceur
  {
    Grid Grid { get; set; }
    List<Drone> Drones { get; set; }
    List<Warehouse> Entrepots { get; set; }
    List<Order> Commandes { get; set; }
    List<Product> Produits { get; set; }
    
    // TODO liste d'ordres ??
    public int DroneLePlusProche(Warehouse entrepot, out Drone drone)
    {
      drone = this.Drones.OrderBy(item => entrepot.CalculeDistance(item)).FirstOrDefault();
      if (drone != null)
      {
        return entrepot.CalculeDistance(drone);
      }
      else
      {
        return 0;
      }
    }

    public void MainLoop()
    {
      do
      {
        // Pour chaque entrepot
        //   Evaluation du cout d'une commande
        // Pour chaque commande
        //   sélection des meilleurs instructions
        foreach (var entrepot in Entrepots)
        {
          var listeCost = new List<OrderCost>();
          var currentStock = entrepot.CloneRepartitionProduit();
          foreach (var order in Commandes)
          {
            OrderCost oc = new OrderCost();
            oc.CostOrder = order.Lignes.Sum( p => Math.Min(p.QteCommandee, currentStock[p.Produit])) / order.Lignes.Sum(p => p.QteCommandee);
          
          }
        }        
      }while (Grid.TourCourrant < Grid.NbTours);
    }
  }
}
