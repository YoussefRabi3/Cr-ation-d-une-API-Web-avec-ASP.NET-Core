namespace API.models
{
    public class Salarie
    {
        public int id { get; set; }
        public int salaire { get; set; }
        public string nom { get; set; }

        public int departementId { get; set; }
        public Departement? departement { get; set; }





    }
}
