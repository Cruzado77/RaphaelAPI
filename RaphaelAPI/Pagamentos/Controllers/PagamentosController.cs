/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using Microsoft.AspNetCore.Mvc;
using RaphaelAPI.Models;
using RaphaelAPI.Pagamentos.Models;

namespace RaphaelAPI.Pagamentos.Controllers
{

    [Route("api/pagamento/compras")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        [HttpPost]
        public Pagamento FazerPagamento(Compra compra)
        {
            if(compra.valor > 100)
            {
                return new Pagamento(compra.valor,"APROVADO");
            }
            else
            {
                return new Pagamento(compra.valor, "REJEITADO");
            }
        }
    }
}
