using System.ComponentModel.DataAnnotations;

namespace TriVagas.Services.Requests
{
    public class CreateCompanyRequest
    {
        [Required(ErrorMessage = "Required Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required CityId")]
        public int CityId { get; set; }
        public string LinkedIn { get; set; }
    }
}
