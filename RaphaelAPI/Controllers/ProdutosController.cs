using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaphaelAPI.Data;
using RaphaelAPI.Models;
using RaphaelAPI.DTO;

namespace RaphaelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProdutosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        // Lista nao detalhada, retorna ProdutoDTO
        [HttpGet]
        public async Task<ActionResult<List<ProdutoDTO>>> ListarProdutos()
        {
            List<Produto> lista = await _context.produto.ToListAsync();
            List<ProdutoDTO> listaDTO = new List<ProdutoDTO>();
            foreach (Produto i in lista)
            {
                listaDTO.Add(i.ProdutoToDTO());
            }

            return listaDTO;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> DetalharProduto(int id)
        {
            var produto = await _context.produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // POST: api/Produtos
        // O usuario posta ProdutoDTO, o banco guarda Produto!!!
        [HttpPost]
        public async Task<ActionResult<Produto>> AdicionarProduto(ProdutoDTO produto)
        {
            var produtoAdicionado = new Produto(produto);
            _context.produto.Add(produtoAdicionado);
            await _context.SaveChangesAsync();

            //Se sucesso, retorna uma chamada a DetalharProduto com o Produto adicionado.
            return CreatedAtAction("DetalharProduto", new { id = produtoAdicionado.Id }, produtoAdicionado);
        }

        // PUT: api/Produtos/5
        //[HttpPut("{id}")]
        public async Task<IActionResult> ModificarProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            var produto = await _context.produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.produto.Any(e => e.Id == id);
        }
    }
}
