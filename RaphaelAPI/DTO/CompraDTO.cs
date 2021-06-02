/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using System.Collections.Generic;
using RaphaelAPI.Models;

namespace RaphaelAPI.DTO
{
    public class CompraDTO
    {
        public int Id { get; set; }
        public int produto_Id { get; set; }
        public float valor { get; set; }

        public CompraDTO() { }

        public CompraDTO(Compra compra)
        {
            Id = compra.Id;
            produto_Id = compra.produto_Id;
            valor = compra.valor;
        }
    }
}
