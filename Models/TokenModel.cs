using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TokenModel
    {
        [Required]
        public string Access { get; set; }
        [Required]
        public string Refresh { get; set; }
    }
}
