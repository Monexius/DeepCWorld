using System.Threading.Tasks;
using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp
{
    public interface IMySQlSyncInterface<T> where T : class
    {
        Task<DataL> MySQLConnection(Data[] data, DataL dataL);

    }
}
