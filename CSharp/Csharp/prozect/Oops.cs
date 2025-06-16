

class Oops{

private int age;

public int Age
{
    get { return age; }
    set
    {
        if (value >= 0)
            age = value;
        else
            throw new ArgumentException("Age can't be negative");
    }
}
}

class Woops
{
    void Maid()
    {
        Oops oops = new Oops();
        oops.Age = 30; // Setting a valid age
    }
}