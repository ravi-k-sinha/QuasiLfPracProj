using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Message.Service;
using Microsoft.AspNetCore.Mvc;

namespace Message.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IMessageService Service;

        public MessageController(IMessageService service)
        {
            this.Service = service;
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
            return Ok(await Service.Get(messageId));
        }

        [HttpGet("all")]
        [Produces("application/json", Type = typeof(IMessageDetail[]))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Service.GetAll());
        }

        [HttpPost()]
        [Consumes("application/json")]
        public async Task<IActionResult> AddMessage([FromBody] MessageDetail message)
        {
            return Ok(await Service.Add(message));
        }
    }
}
