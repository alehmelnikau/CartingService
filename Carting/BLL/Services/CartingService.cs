using AutoMapper;
using Carting.BLL.Contracts;
using Carting.BLL.Models;
using Carting.DAL.Contracts;

namespace Carting.BLL.Services
{
	public class CartingService : ICartingService
	{
		private readonly ICartingRepository cartingRepository;
		private readonly IMapper mapper;

		public CartingService(ICartingRepository cartingRepository, IMapper mapper)
		{
			this.cartingRepository = cartingRepository;
			this.mapper = mapper;
		}

		public List<CartItem> GetCartItems(string cartKey)
		{
			return mapper.Map<List<CartItem>>(cartingRepository.GetCartItems(cartKey));
		}

		public void AddCartItem(string cartKey, CartItem cartItem)
		{
			cartingRepository.AddCartItem(cartKey, mapper.Map<DAL.Models.CartItem>(cartItem));
		}

		public void DeleteCartItem(string cartKey, int cartItemId)
		{
			cartingRepository.DeleteCartItem(cartKey, cartItemId);
		}
	}
}
