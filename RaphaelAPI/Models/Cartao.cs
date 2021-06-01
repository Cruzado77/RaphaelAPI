using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaphaelAPI.Models
{
    public class Cartao
    {
        public string Id { get; set; }
        public string data_expiracao { get; set; }
        public string bandeira { get; set; }
        public string cvv { get; set; }
        public string titular { get; set; }
    }
}
