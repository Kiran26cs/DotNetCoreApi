using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppModels.ConfigModels
{
    public class JWTConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
