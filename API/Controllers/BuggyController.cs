using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Entities;

namespace API
{
    public class BuggyController: BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext cotext)
        {
            _context = cotext;
        }

        [Authorize]

        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret texr";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing =_context.Users.Find(-1);

            if (thing ==null) return NotFound();

            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
                var thing =_context.Users.Find(-1);

                var thingToReturn = thing.ToString();

                return thingToReturn;
                       
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest();
        }
    }
}