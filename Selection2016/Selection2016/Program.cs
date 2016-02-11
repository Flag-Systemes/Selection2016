using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selection2016.Data;
using Selection2016.Utils;

namespace Selection2016
{
  class Program
  {
    static void Main(string[] args)
    {
      Grid grid0;
      List<Drone> drones0;
      List<Warehouse> entrepots0;
      List<Order> commandes0;
      List<Product> produits0;
      LectureFichier(FileUtils.In0, out grid0, out drones0, out entrepots0, out commandes0, out produits0);
    }

    public static void LectureFichier(List<string> input, out Grid grid, out List<Drone> drones, out List<Warehouse> entrepots, out List<Order> commandes, out List<Product> produits)
    {
      int ligneCourante = 0;
      List<int> ligne;
      grid = new Grid();
      drones = new List<Drone>();
      entrepots = new List<Warehouse>();
      commandes = new List<Order>();
      produits = new List<Product>();

      // Ligne 1
      ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
      grid.NbLignes = ligne[0];
      grid.NbColonnes = ligne[1];
      for (int i = 0; i < ligne[2]; i++)
      {
        drones.Add(new Drone());
      }
      grid.NbTours = ligne[3];
      grid.PoidsMax = ligne[4];
      ligneCourante++;

      // Ligne 2
      ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
      for (int i = 0; i < ligne[0]; i++)
      {
        produits.Add(new Product());
      }
      ligneCourante++;

      // Ligne 3
      ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
      for (int i = 0; i < ligne.Count; i++)
      {
        produits[i].Type = i;
        produits[i].Poids = ligne[i];
      }
      ligneCourante++;

      // Ligne 4
      ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
      for (int i = 0; i < ligne[0]; i++)
      {
        entrepots.Add(new Warehouse());
      }
      ligneCourante++;

      // Lignes entrepots
      foreach (Warehouse entrepot in entrepots)
      {
        ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
        entrepot.X = ligne[0];
        entrepot.Y = ligne[1];
        entrepot.RepartitionProduit = new Dictionary<Product, int>();
        ligneCourante++;
        ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
        for (int i = 0; i < ligne.Count; i++)
        {
          entrepot.RepartitionProduit.Add(produits[i], ligne[i]);
        }
        ligneCourante++;
      }

      foreach (Drone drone in drones)
      {
        drone.X = entrepots[0].X;
        drone.Y = entrepots[0].Y;
      }

      // Ligne 5
      ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
      for (int i = 0; i < ligne[0]; i++)
      {
        commandes.Add(new Order());
      }
      ligneCourante++;

      // Lignes commandes
      foreach (Order commande in commandes)
      {
        ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
        commande.X = ligne[0];
        commande.Y = ligne[1];
        commande.Lignes = new List<OrderLine>();
        ligneCourante++;
        // On saute cette ligne
        ligneCourante++;
        ligne = FileUtils.Split<int>(input[ligneCourante], ' ');
        foreach (int item in ligne)
        {
          Product prod = produits[item];
          if (!commande.Lignes.Any(odligne => odligne.Produit == prod))
          {
            commande.Lignes.Add(new OrderLine() { Produit = prod, QteCommandee = 0, QteLivree = 0 });
          }
          commande.Lignes.First(odligne => odligne.Produit == prod).QteCommandee++;
        }
        ligneCourante++;
      }
    }
  }
}
