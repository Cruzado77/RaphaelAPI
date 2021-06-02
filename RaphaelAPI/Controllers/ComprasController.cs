/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaphaelAPI.Data;
using RaphaelAPI.Models;
using RaphaelAPI.Pagamentos.Models;

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
            try
            {
                //Validar dados de compra e cartao de credito
                if(compra.IsInvalid())
                {
                    throw new ArgumentException();
                }
                Produto produto = await _context.produto.FindAsync(compra.produto_Id);
                if (produto == null)
                {
                    return StatusCode(412);
                }

                //Calcula compra
                if (compra.RealizarCompra(ref produto) != 0)
                {
                    return BadRequest();
                }

                HttpClient client = new HttpClient();
                //Faz uma chamada a API Pagamentos
                HttpResponseMessage response = await client.
                    PostAsJsonAsync("https://localhost:8080/api/pagamento/compras/", compra);

                response.EnsureSuccessStatusCode();

                // Le JSON retornado da API para pagamento
                Pagamento pagamento = await response.Content.ReadAsAsync<Pagamento>();


                if (pagamento.estado == "APROVADO")
                {
                    //Modifica produto ou exclui se não houver mais em estoque
                    if (produto.qtde_estoque == 0)
                    {
                        _context.Remove(produto);
                    }
                    else
                    {
                        _context.Entry(produto).State = EntityState.Modified;
                    }

                    //Adiciona apenas compra, sem entidades relacionadas!
                    _context.Entry(compra).State = EntityState.Added;

                    //Adiciona cartao se necessario
                    if (await _context.cartao.FindAsync(compra.cartao.numero) == null)
                    {
                        _context.cartao.Add(compra.cartao);
                    }

                    await _context.SaveChangesAsync();

                    return compra;
                }
            }
            catch(ArgumentException)
            {
                return StatusCode(412);
            }

            return BadRequest();
        }
    }
}
