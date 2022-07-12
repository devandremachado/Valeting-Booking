using Valeting.Shared.DomainObjects;

namespace Valeting.Domain.Core.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        { }

        public Customer(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public void Update(string name, string phone)
        {
            Name = name;
            Phone = phone;

            SetUpdatedAt();
        }
    }
}
