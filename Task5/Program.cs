using System;
using Task5.Models;

namespace Task5;

internal class Program
{
    static void Main()
    {
        var phone = new Phone(Guid.NewGuid(), "Work phone", "Nokia", "Android", 128);
        var phoneClone1 = phone.MyClone();
        var phoneClone2 = (Phone)((ICloneable)phone).Clone();

        Print("Phone", phone, phoneClone1, phoneClone2);

        var laptop = new Laptop(Guid.NewGuid(), "Home laptop", "Dell", "i7", 32);
        var laptopClone1 = laptop.MyClone();
        var laptopClone2 = (Laptop)((ICloneable)laptop).Clone();

        Print("Laptop", laptop, laptopClone1, laptopClone2);
    }

    static void Print<T>(string label, T original, T clone1, T clone2) where T : class
    {
        Console.WriteLine(label);
        Console.WriteLine(ReferenceEquals(original, clone1));
        Console.WriteLine(ReferenceEquals(original, clone2));
        Console.WriteLine(original);
        Console.WriteLine(clone1);
        Console.WriteLine(clone2);
        Console.WriteLine();
    }
}
