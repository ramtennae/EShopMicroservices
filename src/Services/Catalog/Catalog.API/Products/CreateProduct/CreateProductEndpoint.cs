using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.CreateProduct;
    public record CreateProductRequest(Guid Id,
                                       string Name,
                                       List<string> Category,
                                       string Description,
                                       string ImageFile,
                                       decimal Price);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
                {
                    CreateProductCommand command = request.Adapt<CreateProductCommand>();
                    CreateProductResult result = await sender.Send(command);
                    CreateProductResult response = result.Adapt<CreateProductResult>();
                    return Results.Created($"/products/{response.Id}", response);
                })
               .WithName("CreateProduct")
               .Produces<CreateProductResponse>(StatusCodes.Status201Created)
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .WithSummary("Create Product")
               .WithDescription("Create Product");
        }
}
