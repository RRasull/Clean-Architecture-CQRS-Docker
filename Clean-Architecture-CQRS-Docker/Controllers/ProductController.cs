using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Response;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture_CQRS_Docker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ProductController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var query = new GetByIdProductQueryRequest() { Id = id };
                return Ok(await _mediatR.Send(query));
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
            
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllProductQueryRequest();
                return Ok(await _mediatR.Send(query));
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest requestModel)
        {
            try
            {
                CreateProductCommandResponse response = await _mediatR.Send(requestModel);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var query = new DeleteProductCommandRequest() { Id = id };
                return Ok(await _mediatR.Send(query));
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
