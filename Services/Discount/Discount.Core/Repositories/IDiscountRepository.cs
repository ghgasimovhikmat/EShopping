using Discount.Core.Entities;

namespace Discount.Core.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscount(string productName);
    Task<bool> CreateCoupon(Coupon coupon);
    Task<bool> UpdateCoupon(Coupon coupon);
    Task<bool> DeleteCoupon(string productName);
}