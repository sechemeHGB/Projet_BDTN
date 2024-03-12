namespace Projet_BDTN.Models
{
    public class Console
    {
        public int Id { get; set; }
        public ICollection<Vente> Ventes { get; set; }
        public string Name { get; set; }
        public string Constructors {  get; set; }
    }
}
