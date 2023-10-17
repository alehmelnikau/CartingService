namespace Carting.WebApi.Models
{
	public class Cart
	{
		public string Key { get; set; }

		public List<CartItem> Items { get; set; } = default!;
	}
}
