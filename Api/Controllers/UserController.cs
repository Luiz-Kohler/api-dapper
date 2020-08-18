using Application.IServices;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("users")]
    public sealed class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
        {
            try
            {
                await _service.Create(request);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return BadRequest(new { (ex as BadRequestException).ErrorMessage });

                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<UserResponse> users = await _service.GetAll();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                UserResponse user = await _service.Get(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return NotFound();

                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                await _service.Update(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return NotFound();

                if (ex is BadRequestException)
                    return BadRequest((ex as BadRequestException).ErrorMessage);

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                    return NotFound();

                if (ex is BadRequestException)
                    return BadRequest((ex as BadRequestException).ErrorMessage);

                return StatusCode(500);
            }
        }
    }
}