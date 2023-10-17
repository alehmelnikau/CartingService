using AutoMapper;

namespace Carting.WebApi.Mappers
{
	public class ControllerProfile : Profile
	{
		public ControllerProfile()
		{
			CreateMap<BLL.Models.CartItem, WebApi.Models.CartItem>().ReverseMap();
		}
	}
}
