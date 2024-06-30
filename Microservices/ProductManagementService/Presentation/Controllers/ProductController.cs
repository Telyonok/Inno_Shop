using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementService.Application.DTOs;
using ProductManagementService.Application.Products.Commands.CreateProduct;
using ProductManagementService.Application.Products.Commands.DeleteProduct;
using ProductManagementService.Application.Products.Commands.UpdateProduct;
using ProductManagementService.Application.Products.Queries.GetAllProducts;
using ProductManagementService.Application.Products.Queries.GetProductById;
using ProductManagementService.Application.Products.Queries.GetProductsByFilter;

namespace ProductManagementService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery
            {
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProductsByFilter([FromQuery] GetProductsByFilterDTO getProductsByFilterDTO)
        {
            var query = _mapper.Map<GetProductsByFilterQuery>(getProductsByFilterDTO);

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductDTO createProductDTO)
        {
            var command = _mapper.Map<CreateProductCommand>(createProductDTO);

            //command.UserId = UserId;

            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO updateProductDTO)
        {
            var command = _mapper.Map<UpdateProductCommand>(updateProductDTO);

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
