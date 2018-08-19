using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interface;
using ApplicationCore.Service;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        //public AccountsController(UserManager<IdentityUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        //{
        //    _userManager = userManager;
        //    _mapper = mapper;
        //    _appDbContext = appDbContext;
        //}

        public AccountsController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IMapper mapper)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        // POST api/accounts
        [HttpPost("register")]
        public async Task<IActionResult> Post(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}