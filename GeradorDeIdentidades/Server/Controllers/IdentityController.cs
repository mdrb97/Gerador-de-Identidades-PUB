using GeradorDeIdentidades.Services;
using GeradorDeIdentidades.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorDeIdentidades.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityGenService _identityGenService;
        public IdentityController(IIdentityGenService identityGenService)
        {
            _identityGenService = identityGenService;
        }

        [HttpGet]
        public IdentityModel Get()
        {
            return new IdentityModel
            {
                Name = _identityGenService.GenName(),
                CC = _identityGenService.GenCC(),
                Nif = _identityGenService.GenNif()
            };
        }
    }
}
