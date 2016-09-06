using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyMoneyManager.Infrastucture.DataTransferObjects;

namespace ManagerService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceModule" в коде и файле конфигурации.
    public class ServiceModule : IServiceModule
    {

        private readonly DatabaseWorker _dataBaseWorker;
        private readonly Converter _converter;

        public ServiceModule()
        {
            _dataBaseWorker = new DatabaseWorker();
            _converter = new Converter();
        }

        public void AddItemToDb(DtoObject item)
        {
            if (item is ExpensesDto)
            {
                _dataBaseWorker.AddExpensesToDb(_converter.ConvertDtoToExpenses(item as ExpensesDto));
            }
        }

        public void DeleteItemFromDb(DtoObject item)
        {
            if (item is ExpensesDto)
            {
                _dataBaseWorker.DeleteExpensesFromDb(_converter.ConvertDtoToExpenses(item as ExpensesDto));
            }
        }

        public void EditItemInDb(DtoObject item)
        {
            if (item is ExpensesDto)
            {
                _dataBaseWorker.DeleteExpensesFromDb(_converter.ConvertDtoToExpenses(item as ExpensesDto));
                _dataBaseWorker.AddExpensesToDb(_converter.ConvertDtoToExpenses(item as ExpensesDto));
            }
        }

        public List<DtoObject> GetItemsFromDb(int requestId, DateTime time1, DateTime time2, double value1, double value2, string comment, byte expType)
        {
            List<DtoObject> lstOfDto = new List<DtoObject>();
            switch (requestId)
            {
                case 1:
                    {
                        var lstOfExp = _dataBaseWorker.GetExpensesFromDb(time1, time2, value1, value2, comment, expType);
                        foreach (var item in lstOfExp)
                        {
                            lstOfDto.Add(_converter.ConvertExpensesToDto(item));
                        }
                        break;
                    }
                default:
                    break;
            }
            return lstOfDto;
        }
    }
}
