using Carter;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint:ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, IMediator mediator) =>
            {
                var command = new CreateProductCommand(request.Name, request.Category, request.Description, request.ImageFile, request.Price);
                var result = await mediator.Send(command);
                return Results.Created($"/products/{result.Id}", new CreateProductResponse(result.Id));
            })
            .WithName("CreateProduct")
            .WithTags("Products");
        }
    }   
    {
    }
}
