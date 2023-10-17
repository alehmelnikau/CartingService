using Carting.BLL.Models;

namespace Carting.BLL.Contracts
{
	public interface ICartingService
	{
		List<CartItem> GetCartItems(string cartKey);
		void AddCartItem(string cartKey, CartItem cartItem);
		void DeleteCartItem(string cartKey, int cartItemId);
	}
}
