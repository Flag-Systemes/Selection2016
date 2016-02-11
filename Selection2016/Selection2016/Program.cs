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
      Grid grid1;
      List<Drone> drones1;
      List<Warehouse> entrepots1;
      List<Order> commandes1;
      List<Product> produits1;
    }

    public void LectureFichier(List<string> input, out Grid grid, out List<Drone> drones, out List<Warehouse> entrepots, out List<Order> commandes, out List<Product> produits)
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
      for(int i = 0; i< ligne[0]; i++)
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

      ligneCourante++;
    }
  }
}
