using ImcAPI.Enums;

namespace ImcAPI.Models
{
    public class BMI
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public HeightUnitEnum HeightUnit { get; set; }
        public WeightUnitEnum WeightUnit { get; set; }
    }
}
