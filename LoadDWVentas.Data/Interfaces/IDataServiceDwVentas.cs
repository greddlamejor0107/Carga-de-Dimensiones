using LoadDWVentas.Data.Result;

namespace LoadDWVentas.Data.Interfaces
{
    public interface IDataServiceDwOrders
    {
        Task<OperactionResult> LoadDHW();
    }
}
