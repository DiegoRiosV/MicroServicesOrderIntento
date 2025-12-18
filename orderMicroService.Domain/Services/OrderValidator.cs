using System.Collections.Generic;
using orderMicroService.Domain.Entities;
namespace orderMicroService.Domain.Services
{
    public class OrderValidator : IValidator<Order>
    {
        public Result Validate(Order entity)
        {
            var errors = new List<string>();


            ValidateTotal(entity.Total, errors);

            return errors.Count == 0
                ? Result.Success()
                : Result.Failure(errors);
        }
        private void ValidateTotal(decimal? total, List<string> errors)
        {

            if (total <= 0)
            {
                errors.Add("Total debe ser mayo a cero.");
            }
            if (decimal.Round(total.Value, 2) != total.Value)
            {
                errors.Add("El total solo puede tener hasta dos decimales");
            }
        }
    }
}