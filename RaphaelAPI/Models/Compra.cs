using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaphaelAPI.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int produto_Id { get; set; }
        public Produto produto { get; set; }
        public string cartao_Id { get; set; } 
        public Cartao cartao { get; set; }
        public float valor { get; set; }
    }
}
