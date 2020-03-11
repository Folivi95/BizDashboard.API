using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizDashboard.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly ApiContext ctx;

        public ServerController(ApiContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = this.ctx.Servers.OrderBy(s => s.Id).ToList();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult Get(int id)
        {
            var response = this.ctx.Servers.Find(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Message(int id, [FromBody] ServerMessage message)
        {
            var server = this.ctx.Servers.Find(id);

            if (server == null)
            {
                return NotFound();
            }

            if (message.Payload == "activate")
            {
                server.IsOnline = true;
                
            }

            if (message.Payload == "deactivate")
            {
                server.IsOnline = false;
            }

            this.ctx.SaveChanges();
            return new NoContentResult();
        }
    }
}