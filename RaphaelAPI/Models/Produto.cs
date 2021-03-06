/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using System;
using RaphaelAPI.DTO;

namespace RaphaelAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public float valor_unitario { get; set; }
        public int qtde_estoque { get; set; }
        public Nullable<DateTime> data_last { get; set; }
        public float valor_last { get; set; }


        public Produto()
        { }

        public Produto(ProdutoDTO produto)
        {
            nome = produto.nome;
            valor_unitario = produto.valor_unitario;
            qtde_estoque = produto.qtde_estoque;
        }
        //Converte Produto para ProdutoDTO
        public ProdutoDTO ProdutoToDTO ()
        {
            return new ProdutoDTO(this);
        }

    }
}
