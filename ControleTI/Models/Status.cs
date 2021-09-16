using System.ComponentModel.DataAnnotations;


namespace ControleTI.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Display(Name ="Status")]
        public string StatusNome { get; set; }
    }
}
