using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Cette classe fourni les services pour gérer les produits
    /// </summary>
    public class ProduitService : IProduitService
    {
        private readonly IProduitRepository _produitRepository;
        private readonly ICommandeRepository _commandeRepository;

        public ProduitService(IProduitRepository produitRepository, ICommandeRepository commandeRepository)
        {
            _produitRepository = produitRepository;
            _commandeRepository = commandeRepository;
        }

        /// <summary>
        /// Récupère tous les produits depuis l'inventaire
        /// </summary>
        public Produit[] GetTousLesProduits()
        {
            // TODO changer le type de retour de array à List<T> et propager les changements
            // dans l'application
            return _produitRepository.GetTousLesProduits();
        }

        /// <summary>
        /// Récupère un produit depuis l'inventaire à partir de son id
        /// </summary>
        public Produit GetProduitParId(int id)
        {
            return _produitRepository.GetTousLesProduits().FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Met à jour les quantités restantes pour chaque produit dans l'inventaire en fonction des quantités commandées
        /// </summary>
        public void MetAJourLesQuantitesDuPanier(Panier panier)
        {
            // TODO implementer la méthode
            // met à jour l'inventaire de produit en utilisant la méthode _produitRepository.MetAJourLaQuantiteDunProduit().
        }
    }
}
