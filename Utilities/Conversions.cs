using ImcAPI.Enums;

namespace ImcAPI.Utilities
{
    public class Conversions
    {
        public static double ConvertToMeters(double value, HeightUnitEnum unit)
        {
          switch (unit)
            {
                 case HeightUnitEnum.Centimeters:
                    return value / 100;
                case HeightUnitEnum.Feet:
                    return value * 0.3048;
                case HeightUnitEnum.Inches:
                    return value * 0.0254;
                default:
                    return value;
            }
        }

        public static double ConvertToKilograms(double value, WeightUnitEnum unit)
        {
            switch (unit)
            {
                case WeightUnitEnum.Pounds:
                  return value * 0.453592;
                default:
                return value;
            }
        }

        public static double ConvertToInches(double value, HeightUnitEnum unit)
        {
            switch (unit)
            {
                case HeightUnitEnum.Centimeters:
                    return value * 0.393701; 
                case HeightUnitEnum.Meters:
                    return value * 39.3701; 
                case HeightUnitEnum.Feet:
                    return value * 12.0;
                case HeightUnitEnum.Inches:
                    return value;
                default:
                    throw new ArgumentException("Invalid height unit");
            }
        }

        public static double ConvertToPounds(double value, WeightUnitEnum unit)
        {
            switch (unit)
            {
                case WeightUnitEnum.Kilograms:
                    return value * 2.20462;
                case WeightUnitEnum.Pounds:
                    return value; 
                default:
                    throw new ArgumentException("Invalid weight unit");
            }
        }
    }
}
