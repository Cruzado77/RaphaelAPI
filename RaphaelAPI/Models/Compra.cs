/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using System;
using RaphaelAPI.DTO;

namespace RaphaelAPI.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int produto_Id { get; set; }
        public Cartao cartao { get; set; }
        public float valor { get; set; }
        public int qtde_comprada { get; set; }

        public CompraDTO CompraToDTO ()
        {
            return new CompraDTO(this);
        }

        //Produto por referencia, modificação em qtde_estoque, data_last e valor_last
        public int RealizarCompra(ref Produto produto)
        {
            if(qtde_comprada <= produto.qtde_estoque)
            {
                produto.qtde_estoque -= qtde_comprada;
                valor = produto.valor_unitario * qtde_comprada;
                produto.valor_last = valor;
                //Data Atual
                produto.data_last = DateTime.Now;
            }
            else
            {
                return -1;
            }

            return 0;
        }

        public bool IsInvalid()
        {
            return (cartao == null) || (qtde_comprada <= 0) || cartao.IsInvalid();
        }
    }
}
