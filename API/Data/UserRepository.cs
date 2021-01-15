using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Data;
using API.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;

        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
            // .Select(user => new MemberDto
            // {
            //     Id = user.Id,
            //     Username = user.UserName
            // }
            // ).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMemberesAsync()
        {
          return await _context.Users
          .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
          .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await this._context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {


            return await _context.Users
            .Include(p => p.Photos)
            .ToListAsync();
            // return await this._context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}