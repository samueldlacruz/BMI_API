using ImcAPI.Enums;

namespace ImcAPI.Models
{
    public class BMICalculatorRequest
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public HeightUnitEnum HeightUnit { get; set; }
        public WeightUnitEnum WeightUnit { get; set; }
        public MeasurementSystemEnum MeasurementSystem { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
