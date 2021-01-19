namespace MarkOne.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
}