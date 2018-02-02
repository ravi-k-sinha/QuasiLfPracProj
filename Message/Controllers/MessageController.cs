using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LendFoundry.Foundation.Logging;
using LendFoundry.Foundation.Services;
using Message.Service;
using Microsoft.AspNetCore.Mvc;

namespace Message.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : ExtendedController
    {
        private ILogger Logger { get; }
        private IMessageService Service;
        private static readonly NoContentResult NoContentResult = new NoContentResult();

        public MessageController(IMessageService service, ILogger logger)
        {
            this.Service = service;
            this.Logger = logger;
        }

        [HttpGet]
        public string Index()
        {
            return "Hello from Message Service";
        }

        [HttpGet("{messageId}")]
        [Produces("application/json", Type = typeof(IMessageDetail))]
        public async Task<IActionResult> Get(String messageId)
        {

            /* This is also possible, but whats the gain?
             return await this.ExecuteAsync(async () =>
                {
                    return this.Ok(await this.Service.Get(messageId));
                });
             */

            return Ok(await Service.Get(messageId));
        }

        [HttpGet("all")]
        [Produces("application/json", Type = typeof(IMessageDetail[]))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        [HttpPost()]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> AddMessage([FromBody] MessageDetail message)
        {
            return Ok("{ \"result\" : " + (await Service.Add(message)).ToString().ToLower() + '}');
        }

        [HttpGet("dummy")]
        [Produces("application/json", Type = typeof(List<string>))]
        public async Task<IActionResult> DummyUsers()
        {
            return Ok(await Service.DummyUsers());
        }
    }
}
