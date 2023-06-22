// this project created with .net 6.0
// این پروژه با دات نت 6 ساخته شده است

namespace FactoryMethod;

// یک تایپ برای کلاس هایی که از انها یک نمونه میخواهیم
// A type for the classes from which we want an instance
public interface ICar
{
    // تعداد چرخ ها
    public int WheelsCount { get; set; }

    // سرعت
    public int MaxSpeed { get; set; }

    // اسم ماشین
    public static string CarName { get; }

}


#region کلاس ها | Classes
public class Pride : ICar
{
    public int WheelsCount { get; set; }
    public int MaxSpeed { get; set; }
    public static string CarName { get => "Pride"; }


    public Pride()
    {
        // چهار تا چرخ داره
        this.WheelsCount = 4;

        // نهایت سرعتش 180 
        this.MaxSpeed = 180; // KM/h
    }
}

public class Mercedes : ICar
{
    public int WheelsCount { get; set; }
    public int MaxSpeed { get; set; }
    public static string CarName { get => "Mercedes"; }


    public Mercedes()
    {
        // چهار تا چرخ داره
        this.WheelsCount = 4;

        // نهایت سرعتش 480
        this.MaxSpeed = 480; // KM/h
    }
}

public class BMW : ICar
{
    public int WheelsCount { get; set; }
    public int MaxSpeed { get; set; }
    public static string CarName { get => "BMW"; }

    public BMW()
    {
        // چهار تا چرخ داره
        this.WheelsCount = 4;

        // نهایت سرعت 450
        this.MaxSpeed = 450; // KM/h
    }
}
#endregion

// کلاس فکتوری که به ما یک نمونه از کلاس هایی که از اینترفیس ارثبری کرده اند می دهد
// The factory class that gives us an instance of the classes that inherit from the interface
public class CarFactory
{
    // Factory Method
    // این متد به ما یک نمونه از کلاس ها را بر اساس پراپرتی که مشخص کردیم میدهد
    // This method gives us an instance of the class based on the property we specified
    public static ICar getCar(string carName)
    {
        if (carName == Pride.CarName)
        {
            return new Pride();
        }
        else if (carName == Mercedes.CarName)
        {
            return new Mercedes();
        }
        else if (carName == BMW.CarName)
        {
            return new BMW();
        }

        return null;
    }
}
