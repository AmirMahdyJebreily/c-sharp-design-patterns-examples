// This project created with .net 6.0
// این پروژه با دات نت 6 ساخنته شده است
namespace AbstractFactory;

// کلاس اصلی که بقیه کلاس ها از آن ارثبری میکنند
// The main class from which other classes inherit
public abstract class Food
{
    // ارزش غذایی
    internal int NutritionalValue;
    public string GetData()
    {
        return this.GetType().Name;
    }
    public int GetNutritionalValue()
    {
        return NutritionalValue;
    }
}


#region کلاس ها | Classes

#region غذا های گیاهی | Herbal Foods

// سالاد : ارزش غذایی بالا
class Salad : Food
{
    public Salad()
    {
        this.NutritionalValue = 5;
    }
}

// کدو سبز : ارزش غذایی بالا
class Zucchini : Food
{
    public Zucchini()
    {
        this.NutritionalValue = 60;
    }
}
#endregion

#region غذا های دریایی : Sea Foods
// سوشی : ارزش غذایی کم
class Sushi : Food
{
    public Sushi()
    {
        this.NutritionalValue = 50;
    }
}

// ماهی شکم پر : ارزش غذایی بالا
class StuffedFish : Food
{
    public StuffedFish()
    {
        this.NutritionalValue = 250;
    }
}
#endregion

#endregion

// کلاسی که از کلاس های فکتوری گروه بزرگ و گروه کوچک به ارث می رسد.
// The class that will be inherited from the Large Group and Small Group factory classes. 
abstract class AbstractFactory
{
    public abstract Food CreateHerbalFood();
    public abstract Food CreateSeaFood();
}


// Large Group and Small Group factory classes


// کلاس فکتوری مسئول ایجاد اشیاء خود است.
// The factory class responsible to create his own objects. 
class LargeGroupFactory : AbstractFactory // ارزش غذایی بالا
{
    // یک غذای گیاهی
    // A Herbal Food
    public override Food CreateHerbalFood()
    {
        return new Zucchini();
    }

    // یک غذای دریایی
    // A Sea Food
    public override Food CreateSeaFood()
    {
        return new StuffedFish();
    }
}
class SmallGroupFactory : AbstractFactory // ارزش غذایی کم
{
    // یک غذای گیاهی
    // A Herbal Food
    public override Food CreateHerbalFood()
    {
        return new Salad();
    }

    // یک غذای دریایی
    // A Sea Food
    public override Food CreateSeaFood()
    {
        return new Sushi();
    }
}
