using Basket.Application.Responses;
using Basket.Entity;
using MediatR;

namespace Basket.Application.Commands;

public class CreateShoppingCartCommand : IRequest<ShoppingCartResponse>
{
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; }

    public CreateShoppingCartCommand(string UserName, List<ShoppingCartItem> Items)
    {
    }
}