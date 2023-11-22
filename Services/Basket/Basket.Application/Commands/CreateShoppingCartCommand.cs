using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Entity;
using MediatR;

namespace Basket.Application.Commands;

public class CreateShoppingCartCommand : IRequest<ShoppingCartResponse>
{
    public CreateShoppingCartCommand(string userName, List<ShoppingCartItem> items)
    {
        UserName = userName;
        Items = items;
    }
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; }
    
}