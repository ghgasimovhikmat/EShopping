using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByBrandHandler:IRequestHandler<GetProductByBrandQuery,IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByBrandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
    {
        var productByBrand = await _productRepository.GetProductByBrand(request.BrandName);

        var productResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(productByBrand);

        return productResponse;
    }
}