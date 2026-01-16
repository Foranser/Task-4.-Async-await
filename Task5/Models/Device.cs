using System;
using Task5;

namespace Task5.Models;

public class Device : Asset, IMyCloneable<Device>, ICloneable
{
    public string Brand { get; }

    public Device(Guid id, string title, string brand) : base(id, title)
    {
        Brand = brand;
    }

    protected Device(Device other) : base(other)
    {
        Brand = other.Brand;
    }

    public new Device MyClone() => new Device(this);

    object ICloneable.Clone() => MyClone();

    public override string ToString() => $"{base.ToString()}, Brand={Brand}";
}
