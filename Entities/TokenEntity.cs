using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TokenEntity : BaseEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RemoteIpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool Used { get; set; }
    }
}
