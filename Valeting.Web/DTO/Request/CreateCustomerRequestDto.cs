using System.ComponentModel.DataAnnotations;

namespace Valeting.Web.DTO.Request
{
    public class CreateCustomerRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}
