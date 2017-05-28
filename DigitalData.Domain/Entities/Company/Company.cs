using DigitalData.Domain.Entities.User;

namespace DigitalData.Domain.Entities.Company
{
    public class CompanyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }

        public Item.ItemEntity Item{ get; set; }

        public ClientUser Client { get; set; }
    }
}
