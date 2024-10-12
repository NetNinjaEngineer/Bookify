using Bookify.Entities.OrderAggregate;
using Bookify.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShippingTypesController : ControllerBase
{
	private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepository;

	public ShippingTypesController(IGenericRepository<DeliveryMethod> deliveryMethodRepository)
	{
		_deliveryMethodRepository = deliveryMethodRepository;
	}

	[HttpGet("{shippingTypeId}")]
	public async Task<IActionResult> GetSpecificShippingType(int shippingTypeId)
	{
		var deliveryMethod = await _deliveryMethodRepository.GetByIdAsync(shippingTypeId);
		if (deliveryMethod == null)
			return NotFound();
		return Ok(deliveryMethod);
	}
}
