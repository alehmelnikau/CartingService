using Carting.DAL.Models;
using Carting.DAL.Contracts;
using LiteDB;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Carting.DAL.Services
{
	public class CartingRepository : ICartingRepository
	{
		private readonly string connectionString;

		public CartingRepository(string connectionString)
		{
			//connectionString = @"Data/MyData.db";
			this.connectionString = connectionString;
		}

		public List<CartItem> GetCartItems(string cartKey)
		{
			using var db = new LiteDatabase(connectionString);

			var cartsCollection = db.GetCollection<Cart>("carts");

			var cart = cartsCollection.FindOne(x => x.Key == cartKey);

			return cart?.Items;

			//return new CartItem[] { new CartItem(), new CartItem() };
		}

		public void AddCartItem(string cartKey, CartItem cartItem)
		{
			using var db = new LiteDatabase(connectionString);

			var cartsCollection = db.GetCollection<Cart>("carts");

			var cart = cartsCollection.FindOne(x => x.Key == cartKey);

			if(cart is not null) //Add item to existing cart
			{
				if (cart!.Items is null)
				{
					cart.Items = new List<CartItem>();
				}

				cart.Items.Add(cartItem);

				cartsCollection.Update(cart);
			}
			else // Create new cart with new item
			{
				cart = new Cart
				{
					Key = cartKey,
					Items = new List<CartItem> { cartItem }
				};

				cartsCollection.Insert(cart);
			}
		}

		public void DeleteCartItem(string cartKey, int cartItemId)
		{
			using var db = new LiteDatabase(connectionString);

			var cartsCollection = db.GetCollection<Cart>("carts");

			var cart = cartsCollection.FindOne(x => x.Key == cartKey);

			if (cart != null && cart.Items != null)
			{
				cart.Items.RemoveAll(x => x.Id == cartItemId);

				cartsCollection.Update(cart);
			}
		}
	}
}
