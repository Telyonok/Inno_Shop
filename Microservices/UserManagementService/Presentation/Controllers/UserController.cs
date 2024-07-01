using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagementService.Application.DTOs;
using UserManagementService.Application.Users.Commands.CreateUser;
using UserManagementService.Application.Users.Commands.DeleteUser;
using UserManagementService.Application.Users.Commands.UpdateUser;
using UserManagementService.Application.Users.Queries.GetAllUsers;
using UserManagementService.Application.Users.Queries.GetUserById;

namespace UserManagementService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery
            {
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDTO);

            //command.UserId = UserId;

            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDTO);

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
