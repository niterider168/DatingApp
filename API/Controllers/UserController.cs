using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {

        // private readonly DataContext _context;

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this._mapper = mapper;

            _userRepository = userRepository;
            // _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //     var users = await _userRepository.GetUsersAsync();
            // return Ok(await _userRepository.GetUsersAsync());
            // return await _context.Users.ToListAsync();

            // var users = await _userRepository.GetUsersAsync();

            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            // return Ok(usersToReturn);

            var users = await _userRepository.GetMemberesAsync();

            return Ok(users);
        }

        //api/users/3
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            // return await _context.Users.FindAsync(id);
               return await _userRepository.GetMemberAsync(username);
            // var user = await _userRepository.GetUserByUsernameAsync(username);

            // return _mapper.Map<MemberDto>(user);
         }


    }
}