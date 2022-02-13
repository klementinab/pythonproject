using AutoMapper;

namespace FruitsTraceabilitySystem.Application.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapp()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());
            });
        }
    }
}
