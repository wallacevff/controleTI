using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ControleTI.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Display(Name = "Status")]
        public string StatusNome { get; set; }
        public IEnumerable<Dispositivo> Dispositivos { get; set; }

        public Status() { }

        public Status(int statusId, string statusNome)
        {
            StatusId = statusId;
            StatusNome = statusNome;
        }
    }
}
