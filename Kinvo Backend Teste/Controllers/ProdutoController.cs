using Application.Commands.Produtos;
using Application.Queries.Produto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kinvo_Backend_Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto([FromBody] NovoProdutoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos()
        {
            ListarTodosProdutosQuery query = new();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
