using System;
using Task5;

namespace Task5.Models;

public sealed class Phone : Device, IMyCloneable<Phone>, ICloneable
{
    public string OperatingSystem { get; }
    public int StorageGb { get; }

    public Phone(Guid id, string title, string brand, string operatingSystem, int storageGb)
        : base(id, title, brand)
    {
        OperatingSystem = operatingSystem;
        StorageGb = storageGb;
    }

    private Phone(Phone other) : base(other)
    {
        OperatingSystem = other.OperatingSystem;
        StorageGb = other.StorageGb;
    }

    public new Phone MyClone() => new Phone(this);

    object ICloneable.Clone() => MyClone();

    public override string ToString() => $"{base.ToString()}, OS={OperatingSystem}, StorageGb={StorageGb}";
}
