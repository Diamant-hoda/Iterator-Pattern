// Aggregate Interface
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}
