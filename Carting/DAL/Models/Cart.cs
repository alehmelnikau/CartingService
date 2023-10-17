namespace Carting.DAL.Models
{
	public class Cart
	{
		public int Id { get; set; }

		public string Key { get; set; }

		public List<CartItem> Items { get; set; } = default!;
	}
}
