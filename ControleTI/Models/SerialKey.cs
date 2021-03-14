using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTI.Models
{
    public class SerialKey
    {
        [Key, Column(Order = 0)]
        public int SoftwareId { get; set; }
        [Key, Column(Order = 1)]
        public String Key { get; set; }
        public Software Software { get; set; }

        public SerialKey(string key, Software software)
        {
            Key = key;
            Software = software;
        }

        public SerialKey()
        {
        }
    }
}
