using Application.Commands.Aplicacoes;
using Application.Commands.Resgates;
using Application.Queries.Movimentacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kinvo_Backend_Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("RealizarAplicacao")]
        public async Task<IActionResult> RealizarAplicacao([FromBody] NovaAplicacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        [HttpPost]
        [Route("RealizarResgate")]
        public async Task<IActionResult> RealizarResgate([FromBody] NovoResgateCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("ListarMovimentacoes/Produto/{id}")]
        public async Task<IActionResult> ListarMovimentacoes(Guid id)
        {
            var result = await _mediator.Send(new ListarMovimentacoesPorProdutoQuery(id));

            return Ok(result);
        }
    }
}
