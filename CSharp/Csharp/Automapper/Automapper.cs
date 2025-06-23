
namespace Csharp.Automapper;
using AutoMapper;

public class Address
{
    public string City { get; set; }
} // Mapping Nested Objects / Flattening
class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Address Address { get; set; } // Nested Object
}

class UserDto
{
    public string Name { get; set; }
    public int Age { get; set; }

    public string City { get; set; } // Flattened property from Address
}
class Automapper
{
    public static void notMain()
    {
        User user = new User
        {
            Name = "John Doe",
            Age = 30
        };

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>()
            .ForMember(dest => dest.Age, opt => opt.Condition(src => src.Age > 0))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City));
            // .AfterMap((src, dest) => dest.MappedAt = DateTime.Now); Before mapping, you can add custom logic to the mapping process
            // User -> source
            // UserDto -> destination
            // CreateMap<User, UserDto>() creates a mapping between User and UserDto
            // It automatically maps properties with the same name , with public properties only
            // cfg.CreateMap<User, UserDto>().reverseMap(); 
            // This creates a reverse mapping from UserDto to User -> useful when data is recieved from an API

            // CreateMap<UpdateUserDto, User>()
            // .ForAllMembers(opt => opt.Condition((src, dest, srcVal) => srcVal != null)); -> dont map null values
        });

        var mapper = config.CreateMapper();
        UserDto dto = mapper.Map<UserDto>(user);

    }

}

// Mapping Collections
public class OrderItem
{
    public string Product { get; set; }
    public int Quantity { get; set; }
}

public class Order
{
    public List<OrderItem> Items { get; set; }
}

public class OrderItemDto
{
    public string Product { get; set; }
    public int Quantity { get; set; }
}

public class OrderDto
{
    public List<OrderItemDto> Items { get; set; }
}