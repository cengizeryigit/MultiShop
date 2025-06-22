using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using System.ComponentModel;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query="Insert Into Coupons (Code, Rate, IsActive, ValidDate) Values (@Code, @Rate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createDiscountCouponDto.Code);
            parameters.Add("@Rate", createDiscountCouponDto.Rate);
            parameters.Add("@IsActive", createDiscountCouponDto.IsActive);
            parameters.Add("@ValidDate", createDiscountCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "SELECT CouponID, Code, Rate, IsActive, ValidDate FROM Coupons";
            
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "SELECT CouponID, Code, Rate, IsActive, ValidDate FROM Coupons WHERE CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);

            using (var connection = _context.CreateConnection())
            {
               var values = await connection.QueryFirstOrDefaultAsync<GetByIDDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", updateDiscountCouponDto.Code);
            parameters.Add("@Rate", updateDiscountCouponDto.Rate);
            parameters.Add("@IsActive", updateDiscountCouponDto.IsActive);
            parameters.Add("@ValidDate", updateDiscountCouponDto.ValidDate);
            parameters.Add("@CouponID", updateDiscountCouponDto.CouponID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
