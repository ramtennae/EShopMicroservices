using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{

    // note how we use our CQRS command abstractions instead of IRequest/IRequestHandler

    public record CreateProductCommand(string Name,
                                       List<string> Category,
                                       string Description,
                                       decimal Price,
                                       string ImageFile) : ICommand<CreateProductResult>
    {
    }

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create product entity from commmand object
            Product product = new Product
            {
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Name = command.Name,
                Price = command.Price,
            };

            // save to database
            //      TODO
            // return the result
            //      TODO actual guid, not random
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
