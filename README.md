# BMI Calculator API

This is a simple API for calculating Body Mass Index (BMI) with support for both query parameters and JSON body.

## Endpoints

### Calculate BMI (Body Mass Index)

#### Query Version

**Endpoint:** `GET /bmi-calculator`

**Parameters:**
- `height` (double): Height value.
- `weight` (double): Weight value.
- `heightUnit` (enum): Height unit (e.g., Centimeters, Inches).
- `weightUnit` (enum): Weight unit (e.g., Kilograms, Pounds).
- `measurementSystem` (enum): Measurement system (e.g., Metric, US).
- `age` (int): Age of the individual.
- `gender` (enum): Gender (e.g., Male, Female).

**Example Request:**
```hs
GET /bmi-calculator?height=170&weight=70&heightUnit=Centimeters&weightUnit=Kilograms&measurementSystem=Metric&age=25&gender=Male
```

**Example Response:**
```json
{
  "BMI": 24.2,
  "Status": "Normal"
}
```
#### Body Version

**Endpoint:** `GET /bmi-calculator`

Body:
```json
{
  "Height": 170,
  "Weight": 70,
  "HeightUnit": "Centimeters",
  "WeightUnit": "Kilograms",
  "MeasurementSystem": "Metric",
  "Age": 25,
  "Gender": "Male"
}
```

**Example Response:**
```json
{
  "BMI": 24.2,
  "Status": "Normal"
}
```

