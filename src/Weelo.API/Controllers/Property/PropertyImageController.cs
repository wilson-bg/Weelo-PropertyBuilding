//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Weelo.Core.DTOs;
//using Weelo.Core.Interfaces;

//namespace Weelo.API.Controllers.Property
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PropertyImageController : ControllerBase
//    {

//        private readonly IPropertyService _propertyService;

//        public PropertyImageController(IPropertyService propertyService)
//        {
//            _propertyService = propertyService;
//        }

//        [HttpPost]
//        public IActionResult Post(CreatePropertyImageRequest request)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(request);
//            }

//            _propertyService.InsertImageAsync(request);
//            return Ok();
//        }



//    }
//}
