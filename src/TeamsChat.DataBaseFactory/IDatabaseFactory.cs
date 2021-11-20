
namespace TeamsChat.DatabaseInterface
{
    public interface IDatabaseFactory
    {
        T GetDb<T>();
    }
}
