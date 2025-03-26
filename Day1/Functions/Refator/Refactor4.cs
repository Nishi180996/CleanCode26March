using System;
using System.Linq;

public class Temperature
{
    public double Value { get; }
    private const double MinTempe = 34;
    private const double MaxTemp = 42;

    public Temperature(double value)
    {
        if (value < MinTemp || value > MaxTemp)
            throw new ArgumentException("Invalid temperature");
        Value = value;
    }
}

public class BloodPressure
{
    public int Systolic { get; }
    public int Diastolic { get; }

    private const int MinSystolic = 70;
    private const int MaxSystolic = 200;
    private const int MinDiastolic = 40;
    private const int MaxDiastolic = 120;

    public BloodPressure(int systolic, int diastolic)
    {
        if (systolic < MinSystolic || systolic > MaxSystolic)
            throw new ArgumentException("Invalid systolic BP");
        if (diastolic < MinDiastolic || diastolic > MaxDiastolic)
            throw new ArgumentException("Invalid diastolic BP");
        if (diastolic > systolic)
            throw new ArgumentException("Diastolic cannot exceed systolic");

        Systolic = systolic;
        Diastolic = diastolic;
    }
}

public class HeartRate
{
    public int Value { get; }
    private const int minHeartRate = 40;

    public HeartRate(int value, int age)
    {
        int maxHeartRate = 220 - age;
        if (value < minHeartRate || value > maxHeartRate * 1.2)
            throw new ArgumentException($"Heart rate invalid for age {age}");

        Value = value;
    }
}

public class BloodType
{
    private static readonly string[] ValidBloodTypes = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
    public string Type { get; }

    public BloodType(string type)
    {
        if (!ValidBloodTypes.Contains(type))
            throw new ArgumentException("Invalid blood type");
        Type = type;
    }
}

public class LastMeal
{
    public DateTime LastMealTime { get; }

    public LastMeal(DateTime lastMealTime)
    {
        LastMealTime = lastMealTime;
    }

    public bool IsRecentMeal() => (DateTime.Now - LastMealTime).TotalHours < 2;
}

public class PatientVitals
{
    public int PatientId { get; }
    public int Age { get; }
    public Temperature Temperature { get; }
    public BloodPressure BloodPressure { get; }
    public HeartRate HeartRate { get; }
    public BloodType BloodType { get; }
    public LastMeal LastMeal { get; }

    public PatientVitals(int patientId, int age, Temperature temperature, BloodPressure bloodPressure,
        HeartRate heartRate, BloodType bloodType, LastMeal lastMeal)
    {
        PatientId = patientId;
        Age = age;
        Temperature = temperature;
        BloodPressure = bloodPressure;
        HeartRate = heartRate;
        BloodType = bloodType;
        LastMeal = lastMeal;
    }
}

public class PatientVitalsService
{
    public void RecordVitals(PatientVitals vitals)
    {
        if (vitals.LastMeal.IsRecentMeal() && vitals.BloodPressure.Diastolic > 90)
        {
            TriggerAlert("Elevated postprandial blood pressure");
        }

        Console.WriteLine("Vitals recorded successfully!");
    }

    private void TriggerAlert(string message)
    {
        Console.WriteLine($"ALERT: {message}");
    }
}
