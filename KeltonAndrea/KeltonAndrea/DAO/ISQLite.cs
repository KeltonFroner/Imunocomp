using SQLite.Net;

namespace KeltonAndrea.DAO
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
