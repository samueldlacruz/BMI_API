using ImcAPI.Enums;
using ImcAPI.Utilities;

namespace ImcAPI.Services
{
    public class BMICalculator
    {
        public (double, string) CalculateBMI(double height, double weight, HeightUnitEnum heightUnit, WeightUnitEnum weightUnit, MeasurementSystemEnum measurementSystem, int age, GenderEnum gender)
        {
            // Convert to metric or US units based on the specified system
            if (measurementSystem == MeasurementSystemEnum.Metric)
            {
                height = Conversions.ConvertToMeters(height, heightUnit);
                weight = Conversions.ConvertToKilograms(weight, weightUnit);
            }
            else if (measurementSystem == MeasurementSystemEnum.US)
            {
                height = Conversions.ConvertToInches(height, heightUnit);
                weight = Conversions.ConvertToPounds(weight, weightUnit);
            }

            // Calculate BMI
            double bmi = weight / (height * height);

            // Get BMI status
            string bmiStatus = GetBMIStatus(bmi, age, gender);

            return (bmi, bmiStatus);
        }

        private string GetBMIStatus(double bmi, int age, GenderEnum gender)
        {
            if (age < 18)
                return "Classification not applicable for individuals under 18 years";

            // Determine BMI status based on gender-specific categories
            if (gender == GenderEnum.Male)
            {
                return GetBMIStatusForMale(bmi);
            }
            else if (gender == GenderEnum.Female)
            {
                return GetBMIStatusForFemale(bmi);
            }

            return "Invalid gender";
        }

        private string GetBMIStatusForMale(double bmi)
        {
            // Determine BMI status based on categories for males
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi >= 18.5 && bmi < 24.9)
                return "Normal";
            else if (bmi >= 25 && bmi < 29.9)
                return "Overweight";
            else if (bmi >= 30 && bmi < 34.9)
                return "Obesity Class 1";
            else if (bmi >= 35 && bmi < 39.9)
                return "Obesity Class 2";
            else
                return "Obesity Class 3";
        }

        private string GetBMIStatusForFemale(double bmi)
        {
            // Determine BMI status based on categories for females
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi >= 18.5 && bmi < 23.9)
                return "Normal";
            else if (bmi >= 24 && bmi < 28.9)
                return "Overweight";
            else if (bmi >= 29 && bmi < 34.9)
                return "Obesity Class 1";
            else if (bmi >= 35 && bmi < 39.9)
                return "Obesity Class 2";
            else
                return "Obesity Class 3";
        }
    }
}
