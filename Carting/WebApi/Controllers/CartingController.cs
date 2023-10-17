using AutoMapper;
using Carting.BLL.Contracts;
using Carting.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carting.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartingController : ControllerBase
	{
		private readonly ICartingService cartingService;
		private readonly IMapper mapper;

		public CartingController(ICartingService cartingService, IMapper mapper)
		{
			this.cartingService = cartingService;
			this.mapper = mapper;
		}

		// GET: api/<CartingController>
		[HttpGet("{cartKey}")]
		public List<CartItem> GetCartItems(string cartKey)
		{
			return mapper.Map<List<CartItem>>(cartingService.GetCartItems(cartKey));
		}

		// POST api/<CartingController>
		[HttpPost("{cartKey}")]
		public void Post(string cartKey, [FromBody] CartItem cartItem)
		{
			cartingService.AddCartItem(cartKey, mapper.Map<BLL.Models.CartItem>(cartItem));
		}

		// DELETE api/<CartingController>/5
		[HttpDelete("{cartKey}/{cartItemId}")]
		public void Delete(string cartKey, int cartItemId)
		{
			cartingService.DeleteCartItem(cartKey, cartItemId);
		}
	}
}
