public interface ICachedFactory<T>
{
    Task<T> CreateAsync(string type);
}
