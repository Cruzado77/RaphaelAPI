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

        public List<CompraDTO> ProdutosToDTOList (List<Compra> compras)
        {
            List<CompraDTO> result = new List<CompraDTO>();
            foreach(Compra c in compras)
            {
                result.Add(new CompraDTO(c));
            }
            return result;
        }
    }
}
