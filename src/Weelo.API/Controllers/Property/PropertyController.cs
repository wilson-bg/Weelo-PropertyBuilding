using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weelo.API.Filters;
using Weelo.Core.DTOs;
using Weelo.Core.Interfaces;

namespace Weelo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePropertyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(await _propertyService.InsertAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePropertyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(await _propertyService.UpdateAsync(request));
        }

        [HttpGet("Filter")]
        public IActionResult GetAll([FromQuery] PropertyFilterModel filter)
        {
            if (!filter.IsValid())
            {
                return BadRequest(filter.Errors);
            }

            var properties = this._propertyService.GetAll(
                    owner: filter.Owner,
                    address: filter.Address,
                    minPrice: filter.MinPrice,
                    maxPrice: filter.MaxPrice,
                    pageIndex: filter.PageIndex,
                    pageSize: filter.PageSize);

            return Ok(properties);

        }

        [HttpPut("Price")]
        public IActionResult Put(UpdatePropertyPriceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(_propertyService.UpdatePriceAsync(request).Result);

        }

        [HttpPost("Image")]
        public async Task<IActionResult> Pos([FromForm] CreatePropertyImageRequest request, IFormFile file)
        {
            // WB => pendiente optimizar 
            if (file == null)
            {
                this.ModelState.AddModelError("file", "La imagen es requeridad");
                return BadRequest(ModelState);
            }

            if (!file.ContentType.Contains("image"))
            {
                this.ModelState.AddModelError("file", "La imagen es requeridad");
                return BadRequest(ModelState);
            }

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                request.File = ms.ToArray();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }
            var result = await _propertyService.InsertImageAsync(request);
            return Ok(result);
        }

    }
}
