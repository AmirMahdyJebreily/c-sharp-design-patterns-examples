namespace Prototype;

// دیزاین پترن پروتوتایپ برای ایجاد یک شی تکراری یا شبیه سازی از شی فعلی به منظور افزایش عملکرد استفاده می شود. این الگو زمانی استفاده می شود که ایجاد یک شی دیگر پرهزینه یا پیچیده باشد.
// Prototype design pattern is used to create a duplicate object or clone of the current object to enhance performance. This pattern is used when the creation of an object is costly or complex.

class Programmer
{
    public string Name { get; set; }


    // این با استفاده از متدی که صدا زده شده، یک کپی از کل کلاس گرفته و برمیگرداند تا بشود از کلاس یک کلون جدید ساخت بطوری که اگر مقادیر و داده ها را در یک کلاس تغییر دهیم، در کلاس دیگر چیزی تغییر نکند. (کلاس، رفرنس تایپ است)
    // This takes and returns a copy of the entire class using the called method so that a new clone of the class can be made so that if we change the values and data in one class, nothing will change in the other class. (class is a reference type)
    public Programmer GetClone()
    {
        return (Programmer)this.MemberwiseClone();
    }
}

class UseProgrammer
{
    public void Main(string[] args)
    {
        /*
         For this, we first create an instance of the main class and clone the other instance from the previous instance
         برای این کار، ابتدا یک نمونه از کلاس اصلی میسازیم و نمونه دیگر را از روی نمونه قبلی کلون میکنیم
         */
        var person1 = new Programmer() { Name = "Amir" };
        var person2 = person1.GetClone(); // person2.Name now is "Amir" | نام پرسون2 امیر است

        person2.Name = "Ali";

        // now person2.Name is "Ali" but person1.Name is also "Amir"
        // حالا مقدار اسم در پرسون2 برابر با علی است ولی در پرسون 1 همچنان برابر با امیر است.
    }
}
