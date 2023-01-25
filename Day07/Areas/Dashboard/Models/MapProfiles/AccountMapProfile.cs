using AutoMapper;
using Day07.Entities;

namespace Day07.Areas.Dashboard.Models.MapProfiles
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<CustomUser, AccountListItemViewModel>().ForMember(
                d => d.Fullname,
                s => s.MapFrom(src => $"{src.Firstname} {src.Middlename} {src.Lastname}")
                );
        }
    }
}
