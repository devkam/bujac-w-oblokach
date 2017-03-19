using AutoMapper;
using CCT.Domain.Domain;
using CCT.Infrastructure.DTO;

namespace CCT.Infrastructure
{
    public static class AutoMapperConfig
    {
        public static void CreateMap()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Plaintext, PlaintextDTO>();
            });
        }
    }
}
