namespace Adapter;

// آداپتور یک الگوی طراحی است که به شما کمک می کند تا میان دو شئ کاملا غیر همسان، داده جا به جا کنید و این اشیاء با هم ارتباط داشته باشند.
// An adapter is a design pattern that helps you move data between two completely dissimilar objects and communicate with each other.



// بهترین مثالی که پیدا کردم مربوط به شارژ لپتاپ بود. 
// The best example I found was related to laptop charging.
public class Voltage
{
    // ولتاژ برق شهری
    // City voltage
    public virtual int _Voltage => 120;

    // اتصال دوشاخه به پریز برق شهری 
    // Connecting the plug to the city power outlet
    public int ConncetPlug() => _Voltage;
}

// آداپتور که برق 120 ولت شهری رو به برق 22 ولت مناسب لپتاپ سازگار میکنه
// The adapter that adapts the 120 V city electricity to the 22 V electricity suitable for laptops
public class LaptopChargerAdaptor : Voltage
{
    // سازگار کردن برق شهری به برق مورد نیاز لپ تاپ برای شارژ
    // Adapting the city electricity to the electricity needed by the laptop for charging
    public override int _Voltage => 22;
}

// لپ تاپ که می خواهد از کلاس ولتاژ استفاده کند اما این دو شئ با هم سازگار نیستند
// Laptop that wants to use the voltage class, but these two things are not compatible
public class Laptop
{
    public int ChargePercent { get; set; }
    public void Charge(int voltage)
    {
        if (voltage == 22)
        {
            ChargePercent = 100;
        }
        else
        {
            // خراب شدن
            // destroy
        }
    }
}



// Use the Adapter : 
public static class Program
{
    static void Main(string[] args)
    {
        Voltage voltage = new LaptopChargerAdaptor();
        Laptop laptop = new Laptop();


        /*
         اتصال دوشاخه به پریز در حالت عادی (بدون آداپتور)
         باعث خراب شدن لپتاپ می شود اما با متصل کردن آداپتور به پریز،
         ولتاژ مناسب شارژ لپتاپ را بدست می آوریم.
         
         Connecting the plug to the outlet in normal mode (without the adapter)
         will damage the laptop, but by connecting the adapter to the outlet,
         we get the proper voltage for charging the laptop.
        */

        laptop.Charge(voltage.ConncetPlug());

    }
}