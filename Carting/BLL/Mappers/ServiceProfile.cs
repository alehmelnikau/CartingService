using AutoMapper;

namespace Carting.BLL.Mappers
{
	public class ServiceProfile : Profile
	{
		public ServiceProfile()
		{
			CreateMap<DAL.Models.CartItem, BLL.Models.CartItem>().ReverseMap();
		}
	}
}
