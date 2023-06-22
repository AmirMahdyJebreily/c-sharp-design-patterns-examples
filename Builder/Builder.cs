namespace Builder;

// کلاس اصلی که میخواهیم از روی آن نمونه های مختلف بسازیم.
// The main class from which we want to create different examples.
public class Pet
{
    public string Name
    {
        get;
        set;
    }
    public string Head
    {
        get;
        set;
    }
    public string Limbs
    {
        get;
        set;
    }
    public string Body
    {
        get;
        set;
    }
    public string Legs
    {
        get;
        set;
    }
}

// این یک اینترفیس است که برای تعریف تمام مراحل مورد نیاز برای ایجاد یک کلاس استفاده می شود.
// This is an interface which is used to define all the steps required to create a class.
public interface IPetBuilder
{
    void SetName();
    void SetHead();
    void SetLimbs();
    void SetBody();
    void SetLegs();
    Pet GetPet();
}

#region Builders | کلاس های بیلدر

public class PetA_Builder : IPetBuilder
{
    Pet Pet = new Pet();
    public void SetName()
    {
        Pet.Name = "Jessi";
    }
    public void SetHead()
    {
        Pet.Head = "1";
    }
    public void SetLimbs()
    {
        Pet.Limbs = "4";
    }
    public void SetBody()
    {
        Pet.Body = "Plastic";
    }
    public void SetLegs()
    {
        Pet.Legs = "2";
    }
    public Pet GetPet()
    {
        return Pet;
    }
}

public class PetB_Builder : IPetBuilder
{
    Pet Pet = new Pet();
    public void SetName()
    {
        Pet.Name = "Gary";
    }
    public void SetHead()
    {
        Pet.Head = "1";
    }
    public void SetLimbs()
    {
        Pet.Limbs = "4";
    }
    public void SetBody()
    {
        Pet.Body = "Steel";
    }
    public void SetLegs()
    {
        Pet.Legs = "4";
    }
    public Pet GetPet()
    {
        return Pet;
    }
}

#endregion

public class PetCreator
{
    private IPetBuilder _PetBuilder;
    public PetCreator(IPetBuilder PetBuilder)
    {
        _PetBuilder = PetBuilder;
    }
    public void CreatePet()
    {
        _PetBuilder.SetName();
        _PetBuilder.SetHead();
        _PetBuilder.SetLimbs();
        _PetBuilder.SetBody();
        _PetBuilder.SetLegs();
    }
    public Pet GetPet()
    {
        return _PetBuilder.GetPet();
    }
}