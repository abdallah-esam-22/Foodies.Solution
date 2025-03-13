using Foodies.APIs.Errors;
using Foodies.Core.Entities;
using Foodies.Core.IRepositories;
using Foodies.Core.Specifications;
using Foodies.Core.Specifications.Vendor_Specs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.APIs.Controllers
{
    public class VendorsController : BaseAPIController
    {
        private readonly IGenericRepository<Vendor> _vendorRepo;

        public VendorsController(IGenericRepository<Vendor> vendorRepo)
        {
            _vendorRepo = vendorRepo;
        }


        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<Vendor>>> GetVendors([FromQuery] VendorQueryParams queryParams)
        {
            //var vendors = await _vendorRepo.GetAllAsync();
            var specs = new VendorSpecs(queryParams);
            var vendors = await _vendorRepo.GetAllWithSpecsAsync(specs);

            return Ok(vendors);
        }

        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var specs = new BaseSpecs<Vendor>(V => V.Id == id);

            var vendor = await _vendorRepo.GetWithSpecsAsync(specs);

            if (vendor is null)
                return NotFound(new BaseErrorApiResponse(404));

            return Ok(vendor);
        }
    }
}
