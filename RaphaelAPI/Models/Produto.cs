using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaphaelAPI.DTO;

namespace RaphaelAPI.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string nome { get; set; }
        public float valor_unitario { get; set; }
        public int qtde_estoque { get; set; }
        public Nullable<DateTime> data_last { get; set; }
        public float valor_last { get; set; }

        public ProdutoDTO ProdutoToDTO ()
        {
            return new ProdutoDTO(this);
        }
    }
}
