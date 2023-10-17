using Carting.DAL.Models;

namespace Carting.DAL.Contracts
{
	public interface ICartingRepository
	{
		List<CartItem> GetCartItems(string cartKey);
		void AddCartItem(string cartKey, CartItem cartItem);
		void DeleteCartItem(string cartKey, int cartItemId);
	}
}
