using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllBrandQuery:IRequest<IList<BrandResponse>>
{
    
}