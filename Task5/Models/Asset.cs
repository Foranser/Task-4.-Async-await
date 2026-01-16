using System;
using Task5;

namespace Task5.Models;

public class Asset : IMyCloneable<Asset>, ICloneable
{
    public Guid Id { get; }
    public string Title { get; }

    public Asset(Guid id, string title)
    {
        Id = id;
        Title = title;
    }

    protected Asset(Asset other)
    {
        Id = other.Id;
        Title = other.Title;
    }

    public Asset MyClone() => new Asset(this);

    object ICloneable.Clone() => MyClone();

    public override string ToString() => $"{GetType().Name}: {Title} ({Id})";
}
