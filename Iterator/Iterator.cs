// this code, wroted with .net6
// این کد با دات نت 6 نوشته شده است
// 

using System.Collections;

namespace Iterator;
// آیتریتور یک الگوی طراحی هست که به ما کمک میکنه تا روی اعضای مختلف بک مجموعه پیچیده (جداول هش، درخت ها، پشته ها، صف ها و..) پیمایش کنیم و هیچ یک از اطلاعات داخلی آنها را واکشی نکینم
// Iterator is a behavioral design pattern that allows sequential traversal through a complex data structure without exposing its internal details.
// به بیان واضح تر، تمام ساختار های مجموعه ای (لیستها، یکشنریها(جداول هش) آرایه ها و...) در زبان های برنامه نویسی از چیزی مشابه استفاده می کنند.
// هروقت بخواهیم بین چند عضو متوالی جا به جا شویم، همچین ساختاری را نیاز داریم
// میشه گفت که یه ساختار تکامل یافته و بهینه شه از لیست پیوندیه که به تمام بخش های پروژه تعمیم یافته
abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();


    public abstract int Index(); // اندیس عضوی که روش هست رو برمیگردونه | Returns the index of element

    public abstract object Current(); // مقدار عضوی که روش هست رو برمیگردونه | Returns the value of element

    // این از کلاس والد پیاده سازی شده
    public abstract bool MoveNext(); // میره روی عضو بعدی | Go to next element

    public abstract void Reset(); // آیتریتور رو به اولین عضو برمیگردونه | Rewinds treators to the first element
}

abstract class IteratorAggregate : IEnumerable
{
    // Returns an Iterator or another IteratorAggregate for the implementing object.
    // یک شئ آیتریتور برمیگرداند که بشود از آن ارثبری کرد
    public abstract IEnumerator GetEnumerator();
}

// فندانسیون اصلی اینجاست !
// این کلاسِ ما تمام الگوریتم های پیمایش روی اعضا رو پیاده میکنه
// Concrete Iterators implement various traversal algorithms. These classes
// store the current traversal position at all times.
class CatsIterator : Iterator
    // قراره روی مجموعه ای از گربه ها حرکت کننم
{
    private CatsCollection _collection;

    // Stores the current traversal position. An iterator may have a lot of
    // other fields for storing iteration state, especially when it is
    // supposed to work with a particular kind of collection.
    // اندیس اون عنصری که بهش رسیدیم رو ذخیره می کنه
    private int _position = -1;
    // درواقع یک آیتریتور میتونه یه عالمه فیلد برای ذخیره کردن وضعیت حرکت کردنش روی اعضا باشه
    // مخصوصا وقتی قرار باشه روی مجموعه های خاص کار کنیم!

    // این برای اینه که مشخص بشه از آخرین عضو مجموعه به اولش بیایم یا نه
    // چیز واجبی نیست فقط آوردمش برای اینکه بگم منم بلدم 😂😂
    private bool _reverse = false;

    public CatsIterator(CatsCollection collection, bool reverse = false)
    {
        this._collection = collection;
        this._reverse = reverse;

        // در حالت عادی مکان ما برای شروع پیمایش از اول مجموعه هست ولی
        // اگه قرار بود از آخر به اول مجموعه بریم، اونوقت مکان ما واسه شروع باید آخرین عضو باشه
        if (reverse)
        {
            this._position = collection.getItems().Count;
        }
    }

    public override object Current()
    {
        return this._collection.getItems()[_position];
    }

    public override int Index()
    {
        return this._position;
    }

    public override bool MoveNext()
    {
        int updatedPosition = this._position + (this._reverse ? -1 : 1);

        if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
        {
            this._position = updatedPosition;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset()
    {
        this._position = this._reverse ? this._collection.getItems().Count - 1 : 0;
    }
}

// Concrete Collections provide one or several methods for retrieving fresh
// iterator instances, compatible with the collection class.
// این کلاس برای اینه که متد هایی ارائه کنیم تا با ساختار دیزاین پترنمون کار کنه!
// در واقع چندین متد برای بازیابی نمونه های تکرار شونده و سازگار با کلاس مجموعه
class CatsCollection : IteratorAggregate
{
    List<string> _collection = new List<string>();

    bool _direction = false;

    public void ReverseDirection()
    {
        _direction = !_direction;
    }

    public List<string> getItems()
    {
        return _collection;
    }

    public void AddItem(string item)
    {
        this._collection.Add(item);
    }

    public override IEnumerator GetEnumerator()
    {
        return new CatsIterator(this, _direction);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // The client code may or may not know about the Concrete Iterator
        // or Collection classes, depending on the level of indirection you
        // want to keep in your program.

        // بسته به معماری شما، کد کلاینت میتونه در مورد کلاس مجموعه ای که ساختیم چیزی بدونه یا چیزی ندونه 

        var collection = new CatsCollection();
        collection.AddItem("Tom");
        collection.AddItem("Fredo");
        collection.AddItem("Simons");

        Console.WriteLine("Straight traversal:");

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("\nReverse traversal:");

        collection.ReverseDirection();

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }
}