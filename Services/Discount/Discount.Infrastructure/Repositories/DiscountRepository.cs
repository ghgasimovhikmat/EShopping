using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories;


public class DiscountRepository: IDiscountRepository
{
    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private readonly IConfiguration _configuration;
    
    public async Task<Coupon> GetDiscount(string productName)
    {
        await using var connection =
            new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("select * from Coupon where ProductName=@ProductName", new { ProductName = productName });
        if (coupon == null)
            return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Available" };
        return coupon;
    }

    public async Task<bool> CreateCoupon(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var affected = await connection.ExecuteAsync
        ("insert into Coupon (ProductName, Description, Amount) values (@ProductName,@Description, @Amount)",
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
        if (affected == 0) 
            return false;
        return true;
    }

    public async Task<bool> UpdateCoupon(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var affected = await connection.ExecuteAsync
        ("update Coupon set ProductName=@ProductName, Description=@Description, Amount=@Amount where Id=@Id",
            new
            {
                ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount,
                Id = coupon.Id
            });
        if (affected == 0) 
            return false;
        return true;
    }

    public async Task<bool> DeleteCoupon(string productName)
    {  
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var affected = await connection.ExecuteAsync
        ("delete from Coupon  where ProductName=@ProductName",
            new
            {
                ProductName =productName
            });
        if (affected == 0) 
            return false;
        return true;
    }
}