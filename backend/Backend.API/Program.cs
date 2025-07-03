using AutoMapper;
using Backend.API.Domain.Category.Commands;
using Backend.API.Domain.Category.Queries;
using Backend.API.Domain.Product.Commands;
using Backend.API.Domain.Product.Queries;
using Backend.Models;
using Backend.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Logger
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Database
builder.Services.AddDbContext<ProductManagementDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetSection("DatabaseConnectionString").Value);
});

// Http
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ### APP ###
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Products
app.MapGet("/products", async (IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the query
    var products = await mediator.Send(new GetAllProductsQuery()
    {
        ReadOnly = true
    });

    // Mapping the products to DTOs if necessary
    var mappedProducts = mapper.Map<IEnumerable<Backend.Contracts.DTO_s.Product.ReadProductDto>>(products);

    return Results.Ok(mappedProducts);
});


app.MapGet("/products/{id:guid}", async ([FromRoute] Guid id, IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the query
    var products = await mediator.Send(new GetProductByIdQuery()
    {
        ProductId = id,
        ReadOnly = true
    });

    // Mapping the products to DTOs if necessary
    var mappedProducts = mapper.Map<IEnumerable<Backend.Contracts.DTO_s.Product.ReadProductDto>>(products);

    return Results.Ok(mappedProducts);
});


app.MapPost("/products", async (Backend.Contracts.DTO_s.Product.CreateProductDto dto, IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the command
    var product = await mediator.Send(new CreateProductCommand(mapper.Map<ProductEntity>(dto)));

    // Mapping the created product to DTOs if necessary
    var mappedProduct = mapper.Map<Backend.Contracts.DTO_s.Product.ReadProductDto>(product);

    return Results.Created($"/products/{mappedProduct.Id}", mappedProduct);
});


app.MapDelete("/products/{id:guid}", async ([FromRoute] Guid id, IMediator mediator) =>
{
    // Using MediatR to handle the command
    await mediator.Send(new DeleteProductCommand(id));

    return Results.NoContent();
});

// Categories
app.MapGet("/categories/all", async (IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the query
    var categories = await mediator.Send(new GetAllCategoriesQuery()
    {
        ReadOnly = true
    });

    // Mapping the categories to DTOs if necessary
    var mappedCategories = mapper.Map<IEnumerable<Backend.Contracts.DTO_s.Category.ReadCategoryDto>>(categories);

    return Results.Ok(mappedCategories);
});

app.MapGet("/categories/{id:guid}", async ([FromRoute] Guid id, IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the query
    var category = await mediator.Send(new GetCategoryByIdQuery()
    {
        CategoryId = id,
        ReadOnly = true
    });

    // Mapping the category to DTOs if necessary
    var mappedCategory = mapper.Map<Backend.Contracts.DTO_s.Category.ReadCategoryDto>(category);

    return Results.Ok(mappedCategory);
});

app.MapPost("/categories", async (Backend.Contracts.DTO_s.Category.CreateCategoryDto dto, IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the command
    var category = await mediator.Send(new CreateCategoryCommand(mapper.Map<CategoryEntity>(dto)));

    // Mapping the created category to DTOs if necessary
    var mappedCategory = mapper.Map<Backend.Contracts.DTO_s.Category.ReadCategoryDto>(category);

    return Results.Created($"/categories/{mappedCategory.Id}", mappedCategory);
});

app.MapPut("/categories/{id:guid}", async ([FromRoute] Guid id, Backend.Contracts.DTO_s.Category.UpdateCategoryDto dto, IMediator mediator, IMapper mapper) =>
{
    // Using MediatR to handle the command
    var category = await mediator.Send(new UpdateCategoryCommand(mapper.Map<CategoryEntity>(dto)));

    // Mapping the updated category to DTOs if necessary
    var mappedCategory = mapper.Map<Backend.Contracts.DTO_s.Category.ReadCategoryDto>(category);

    return Results.Ok(mappedCategory);
});

app.MapDelete("/categories/{id:guid}", async ([FromRoute] Guid id, IMediator mediator) =>
{
    // Using MediatR to handle the command
    await mediator.Send(new DeleteCategoryCommand(id));

    return Results.NoContent();
});

app.Run();