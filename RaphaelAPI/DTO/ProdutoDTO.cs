using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaphaelAPI.Models;

namespace RaphaelAPI.DTO
{
    public class ProdutoDTO
    {
        public string nome { get; set; }
        public float valor_unitario { get; set; }
        public int qtde_estoque { get; set; }

        public ProdutoDTO()
        { }

        public ProdutoDTO(Produto produto)
        {
            nome = produto.nome;
            valor_unitario = produto.valor_unitario;
            qtde_estoque = produto.qtde_estoque;
        }

        public Produto DTOtoProduto ()
        {
            var produto = new Produto();
            produto.nome = nome;
            produto.valor_unitario = valor_unitario;
            produto.qtde_estoque = qtde_estoque;
            return produto;
        }
    }
}
