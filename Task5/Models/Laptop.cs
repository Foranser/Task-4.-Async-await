using System;
using Task5;

namespace Task5.Models;

public sealed class Laptop : Device, IMyCloneable<Laptop>, ICloneable
{
    public string Cpu { get; }
    public int RamGb { get; }

    public Laptop(Guid id, string title, string brand, string cpu, int ramGb)
        : base(id, title, brand)
    {
        Cpu = cpu;
        RamGb = ramGb;
    }

    private Laptop(Laptop other) : base(other)
    {
        Cpu = other.Cpu;
        RamGb = other.RamGb;
    }

    public new Laptop MyClone() => new Laptop(this);

    object ICloneable.Clone() => MyClone();

    public override string ToString() => $"{base.ToString()}, CPU={Cpu}, RamGb={RamGb}";
}
