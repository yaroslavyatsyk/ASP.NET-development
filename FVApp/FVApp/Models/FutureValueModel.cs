using System.ComponentModel.DataAnnotations;

namespace FVApp.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Should be valid present value")]
        public decimal? PresentValue { get; set; }

        [Required(ErrorMessage = "Should be year")]
        [Range(1,10, ErrorMessage = "Can not be zero or greater than 10")]
        public int? Period { get; set; }

        [Required(ErrorMessage = "Should be valid interest rate")]
        [Range (0,100,ErrorMessage = "Can not be negative or greater than 100")]
        public decimal? InterestRate { get; set; }

        public decimal CalculateFV()
        {
            if (InterestRate.HasValue && PresentValue.HasValue && Period.HasValue)
            {
                

                decimal futureValue = 0m;

                for (int i = 0; i < Period; i++)
                {
                    futureValue = (futureValue + PresentValue.Value) * (1 + InterestRate.Value);
                }
                return futureValue;
            }
            else
            {
                return 0;
            }
        }

    }
}
