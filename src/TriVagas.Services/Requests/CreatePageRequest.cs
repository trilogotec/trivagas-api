using System.ComponentModel.DataAnnotations;

namespace TriVagas.Services.Requests
{
    public class CreatePageRequest
    {
        [Required(ErrorMessage = "Required Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required LinkedIn")]
        public string LinkedIn { get; set; }
        [Required(ErrorMessage = "Required City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Required User")]
        public int UserId { get; set; }
    }
}