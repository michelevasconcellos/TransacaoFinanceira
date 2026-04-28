using Microsoft.AspNetCore.Mvc;
using TransacaoFinanceira.Services;
using TransacaoFinanceira.Api.Models;

namespace TransacaoFinanceira.Api.Controllers
{
    [ApiController]
    [Route("api/transacoes")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransferenciaService _service;

        public TransacaoController(ITransferenciaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Transferir(TransferenciaRequest request)
        {
            _service.Transferir(
                request.CorrelationId,
                request.ContaOrigem,
                request.ContaDestino,
                request.Valor
            );

            return Ok();
        }
    }
}