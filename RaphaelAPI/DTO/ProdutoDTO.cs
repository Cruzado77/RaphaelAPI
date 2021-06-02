/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

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

        public bool IsInvalid()
        {
            return (nome == null) || (valor_unitario <= 0);
        }
    }
}
