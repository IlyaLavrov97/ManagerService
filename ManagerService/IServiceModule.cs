using MyMoneyManager.Infrastucture.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ManagerService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceModule" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceModule
    {
        [OperationContract]
        void AddItemToDb(DtoObject item);

        [OperationContract]
        void DeleteItemFromDb(DtoObject item);

        [OperationContract]
        void EditItemInDb(DtoObject item);

        [OperationContract]
        List<DtoObject> GetItemsFromDb(int requestId, DateTime time1, DateTime time2, double value1, double value2, string comment, byte expType);


    }
}
