using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.DTOs;
using API.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Interface;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using System;
namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }


         [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
         var thing = _context.Users.Find(-2);
         if (thing == null) return NotFound();
         return Ok(thing);

        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

            // try
            // {
                var thing = _context.Users.Find(-2);

                var thingToReturn = thing.ToString();

                return thingToReturn;

            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, "Computer say no!");

            // }
            
        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }


    }
}