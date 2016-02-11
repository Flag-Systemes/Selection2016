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

    List<Command> OrdresDrones { get; set; }

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
      this.OrdresDrones = new List<Command>();
      do
      {
        // MàJ des drones
        // Effecteur le dépôt de produits
        foreach (var drone in this.Drones)
        {
          if (!drone.EnVol)
          {
            // Dépôt des produits
            // MaJ des coordonnées des drones
          }
        }

        AttributLesLivraisons();

        foreach (var drone in this.Drones)
        {
          foreach (var line in drone.CommandesPartielles.SelectMany(c => c.Value))
          {
            line.TourAvantLivraison--;
          }
        }

        Grid.TourCourrant++;
      } while (Grid.TourCourrant < Grid.NbTours);
    }

    private void AttributLesLivraisons()
    {
      // Pour chaque entrepôt
      //   Evaluation du coût d'une commande
      // Pour chaque commande
      //   sélection des meilleurs instructions
      foreach (var entrepot in Entrepots)
      {
        var listeCost = new List<OrderCost>();
        var currentStock = entrepot.CloneRepartitionProduit();

        foreach (var order in Commandes.Where(item => item.TourCompletion == 0))
        {
          OrderCost oc = new OrderCost();
          oc.Produits = new List<OrderLine>();
          foreach (OrderLine ol in order.Lignes.Where(item => !item.EstLivree))
          {
            oc.Produits.Add(new OrderLine()
            {
              Produit = ol.Produit,
              QteCommandee = ol.QteCommandee,
              QteLivree = ol.QteLivree,
              IdCommande = ol.IdCommande
            });
          }

          oc.CompletionProduct = order.Lignes.Sum(p => Math.Min(p.QteCommandee, currentStock[p.Produit])) / order.Lignes.Sum(p => p.QteCommandee);
          oc.DroneCost = this.Drones.Where(d => !d.EnVol).Min(d => entrepot.CalculeDistance(d));
          oc.CostOrder = entrepot.CalculeDistance(order);
          oc.OrderID = order.Id;
          listeCost.Add(oc);
        }
        listeCost.Sort();

        foreach (OrderCost oc in listeCost)
        {
          Drone avion = this.Drones.Where(d => !d.EnVol).FirstOrDefault(x => x.Id == oc.DroneID);
          if (oc.Produits.Sum(x => x.Poids) <= avion.PoidsCourant)
          {
            var order = this.Commandes.FirstOrDefault(c => c.Id == oc.OrderID);
            var lignesOrder = order.Lignes.Select(x => new OrderLineEnLivraison { IdCommande = x.IdCommande, Produit = x.Produit, QteCommandee = x.QteCommandee, QteLivree = x.QteLivree }).ToList();

            avion.CommandesPartielles.Add(order, lignesOrder);
          }
          else
          {
            List<OrderLineEnLivraison> l = new List<OrderLineEnLivraison>();
            foreach (OrderLine ol in oc.Produits.Where(item => !item.EstLivree))
            {
              l.Add(new OrderLineEnLivraison { IdCommande = ol.IdCommande, Produit = ol.Produit, QteCommandee = ol.QteCommandee, QteLivree = ol.QteLivree });
              if (l.Sum(x => x.Poids) > avion.PoidsCourant)
              {
                l.RemoveAt(l.Count - 1);
                break;
              }
            }

            var order = this.Commandes.FirstOrDefault(c => c.Id == oc.OrderID);
            avion.CommandesPartielles.Add(order, l);
          }

          foreach (KeyValuePair<Order, List<OrderLineEnLivraison>> item in avion.CommandesPartielles)
          {
            foreach (OrderLineEnLivraison ligne in item.Value)
            {
              var instruction = new Command() { Drone = avion, Produit = ligne.Produit, IdOrder = item.Key.Id, TypeOrdre = CommandType.Load, QteLivree = ligne.QteCommandee - ligne.QteLivree };
              this.OrdresDrones.Add(instruction);
              ligne.TourAvantLivraison = avion.CalculeDistance(item.Key.X, item.Key.Y) + 1;
            }
          }
        }
      }
    }
  }
}
