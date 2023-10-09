public interface ICachedFactory<T>
{
    T Create(string type);
}
