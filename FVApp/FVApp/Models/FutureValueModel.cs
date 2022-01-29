using System.ComponentModel.DataAnnotations;

namespace FVApp.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Should be valid present value")]
        public double? PresentValue { get; set; }

        [Required(ErrorMessage = "Should be year")]
        [Range(1,10, ErrorMessage = "Can not be zero or greater than 10")]
        public int? Period { get; set; }

        [Required(ErrorMessage = "Should be valid interest rate")]
        [Range (0,100,ErrorMessage = "Can not be negative or greater than 100")]
        public double? InterestRate { get; set; }

        public double CalculateFV()
        {
            if (InterestRate.HasValue && PresentValue.HasValue && Period.HasValue)
            {
                double result = 1;

                double value = (PresentValue.Value * (1.0 + InterestRate.Value));

                for (int i = 0; i < Period; i++)
                {
                    result *= value;
                }
                return result;
            }
            else
            {
                return 0;
            }
        }

    }
}
