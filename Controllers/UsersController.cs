﻿using AutoMapper;
using DatingAppAPI.Data;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace DatingAppAPI.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")] // GET /api/users
    public class UsersController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

   
        [HttpGet]
        public async Task< ActionResult<IEnumerable<MemberDto>>> GetUsers() 
        { 
            var users = await _userRepository.GetMembersAsync();
           
            return Ok(users);
           
        
        }
        


        [HttpGet("{username}")]
        public async Task< ActionResult<MemberDto>> GetUser(string username) 
        {

             return await _userRepository.GetMemberAsync(username);
           
        }
    }
}
