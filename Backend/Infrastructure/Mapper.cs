using AutoMapper;
using backend.Infrastructure.Profiles;

namespace backend.Infrastructure
{
    public static class Mapper
    {
        public static IMapper GetMapperInstance() => MapperCreator
        .CreateConfiguration()
        .CreateMapper();
    }

    public static class MapperCreator
    {
        public static MapperConfiguration CreateConfiguration() =>
            new (mc =>
            {
                mc.AddProfile<UserProfile>();
            });
    }
}
