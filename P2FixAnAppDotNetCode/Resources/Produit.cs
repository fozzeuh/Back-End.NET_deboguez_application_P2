namespace P2FixAnAppDotNetCode.Models
{
    public class Produit
    {
        public Produit(int id, int stock, double prix, string nom, string description)
        {
            Id = id;
            Stock = stock;
            Prix = prix;
            Nom = nom;
            Description = description;
        }

        public int Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public int Stock { get; set; }

        public double Prix { get; set; }
    }
}
