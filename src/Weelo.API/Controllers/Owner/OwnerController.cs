using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Core.DTOs;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOwnerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(await _ownerService.InsertAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateOwnerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(await _ownerService.Update(request));
        }


        // GET project/{projectId?}
        //[HttpGet("{ownerId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok(_ownerRepository.TableNoTracking.Where(x=>x.IdOwner == ownerId));
            var rs = await _ownerService.GetAll();
            return Ok(rs);
        }

    }
}
