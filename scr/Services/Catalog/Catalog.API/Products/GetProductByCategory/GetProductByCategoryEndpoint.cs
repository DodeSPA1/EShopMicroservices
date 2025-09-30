namespace Catalog.API.Products.GetProductByCategory
{
    public record  GetProductByCategoryQueryResponse(IEnumerable<Product> Products)  ;
    public class GetProductByCategoryEndpoint
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryQueryResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductsByCategory")
            .Produces<GetProductByCategoryQueryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Category")
            .WithDescription("Get Products By Category");
        }

    }
}
