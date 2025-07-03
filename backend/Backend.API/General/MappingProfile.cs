using AutoMapper;
using Backend.Contracts.DTO_s.Category;
using Backend.Contracts.DTO_s.Product;
using Backend.Models;

namespace Backend.API.General;

public class MappingProfile : Profile
{
 public MappingProfile()   
 {
     // Define your mappings here
     // Example:
     // CreateMap<SourceModel, DestinationModel>();
     // CreateMap<CreateSourceDto, SourceModel>();
     // CreateMap<UpdateSourceDto, SourceModel>();
     
     // Category
    CreateMap<CategoryEntity, ReadCategoryDto>();
    CreateMap<CreateCategoryDto, CategoryEntity>();
    
    // Product
    CreateMap<ProductEntity, ReadProductDto>()
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
    CreateMap<CreateProductDto, ProductEntity>()
        .ForMember(dest => dest.Category,
            opt => opt.MapFrom(src => new CategoryEntity { Id = src.CategoryId })); // Assuming Category is set separately
 }
}