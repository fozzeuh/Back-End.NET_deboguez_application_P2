using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// La classe Panier
    /// </summary>
    public class Panier : IPanier
    {
        private List<LignePanier> _panier = new List<LignePanier>();

        /// <summary>
        /// Propriété en lecture seule pour affichage seulement
        /// </summary>
        public IEnumerable<LignePanier> Lignes => GetListeDesLignesDuPanier();

        /// <summary>
        /// Retour la liste des lignes du panier
        /// </summary>
        /// <returns></returns>
        private List<LignePanier> GetListeDesLignesDuPanier()
        {
            return _panier;
        }

        /// <summary>
        /// Ajoute un produit dans le panier ou incrémente sa quantité dans le panier si déjà présent
        /// </summary>//
        public void AjouterElement(Produit produit, int quantite)
        {
            var panier = GetListeDesLignesDuPanier();
            var ligne = panier.FirstOrDefault(p => p.Produit.Id == produit.Id);
            if (ligne != null)
            {
                ligne.Quantite += quantite;
            }
            else
            {
                panier.Add(new LignePanier { Quantite = quantite, Produit = produit });
            }
        }

        /// <summary>
        /// Supprimer un produit du panier
        /// </summary>
        public void SupprimerLigne(Produit produit) =>
            GetListeDesLignesDuPanier().RemoveAll(l => l.Produit.Id == produit.Id);

        /// <summary>
        /// Récupère la valeur totale du panier
        /// </summary>
        public double GetValeurTotale()
        {
            var lignePaniers = GetListeDesLignesDuPanier();
            double totale = 0.0;

            foreach (LignePanier lignePanier in lignePaniers)
            {
                totale += lignePanier.Produit.Prix * lignePanier.Quantite;
            }

            return totale;
        }

        /// <summary>
        /// Récupère la valeur moyenne du panier
        /// </summary>
        public double GetValeurMoyenne()
        {
            var lignePaniers = GetListeDesLignesDuPanier();
            if (lignePaniers.Count == 0)
            {
                return 0.0;
            }

            int quantite = 0;
            double totale = 0.0;

            foreach (var lignePanier in lignePaniers)
            {
                quantite += lignePanier.Quantite;
                totale += lignePanier.Produit.Prix * lignePanier.Quantite;
            }

            return totale / quantite;
        }

        /// <summary>
        /// Cherche un produit donné dans le panier et le retourne si trouvé
        /// </summary>
        public Produit TrouveProduitDansLesLignesDuPanier(int idProduit)
        {
            // Version simple détaillé
            var liste = GetListeDesLignesDuPanier();
            var lignePanier = liste.FirstOrDefault(lignePanier => lignePanier.Produit.Id == idProduit);
            if(lignePanier == null)
            {
                return null;
	        }
            else 
	        {
                return lignePanier.Produit;
	        }

            // Version simple simplifié
            return GetListeDesLignesDuPanier().FirstOrDefault(lignePanier => lignePanier.Produit.Id == idProduit)?.Produit;

            // Version longue
            Produit produitTrouve = null;
            foreach (var lignePanier2 in GetListeDesLignesDuPanier())
            {
                if(lignePanier2.Produit.Id == idProduit)
                {
                    produitTrouve = lignePanier2.Produit;
                    break;
		        }
            }

            return produitTrouve;
        }

        /// <summary>
        /// Retourne une ligne de panier à partir de son indice
        /// </summary>
        public LignePanier GetLignePanierParIndice(int indice)
        {
            return Lignes.ToArray()[indice];
        }

        /// <summary>
        /// Vide un panier de tous ses produits
        /// </summary>
        public void Vider()
        {
            List<LignePanier> lignePaniers = GetListeDesLignesDuPanier();
            lignePaniers.Clear();
        }
    }

    public class LignePanier
    {
        public int CommandeLigneId { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
    }
}
