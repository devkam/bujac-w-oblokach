using System.ComponentModel.DataAnnotations;

namespace CCT.Web.API.Models
{
    public class PlaintextModel
    {
        [Required, MinLength(1), MaxLength(2048)]
        public string Content { get; set; }
    }
}