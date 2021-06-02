/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaphaelAPI.Data;
using RaphaelAPI.Models;

namespace RaphaelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ApiContext _context;

        public ComprasController(ApiContext context)
        {
            _context = context;
        }

        // POST: api/Compras
        [HttpPost]
        public async Task<ActionResult<Compra>> FazerCompra(Compra compra)
        {
            Produto produto = await _context.produto.FindAsync(compra.produto_Id);
            if(produto == null)
            {
                return NotFound();
            }

            if(compra.RealizarCompra(ref produto) != 0)
            {
                return BadRequest();
            }
            //Modifica produto
            _context.Entry(produto).State = EntityState.Modified;
            //Adiciona compra
            _context.compra.Add(compra);
            //Adiciona cartao
            _context.cartao.Add(compra.cartao);

            await _context.SaveChangesAsync();

            return compra;
        }

        private bool CompraExists(int id)
        {
            return _context.compra.Any(e => e.Id == id);
        }
    }
}
