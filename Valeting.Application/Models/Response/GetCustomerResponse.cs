namespace Valeting.Application.Models.Response
{
    public class GetCustomerResponse
    {
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
