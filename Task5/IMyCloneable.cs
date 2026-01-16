namespace Task5;

public interface IMyCloneable<out T>
{
    T MyClone();
}
