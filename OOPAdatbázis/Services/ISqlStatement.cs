using System.Collections.Generic;

namespace OOPAdatbázis.Services
{
    internal interface ISqlStatement
    {
        List<object> GetAllData(string dbName);

        object GetById(int id);

        object AddNewItem(object newRecord);

        object DeleteItem(int id);

        object UpdateItem(object modifiedItem);
    }
}
