

using LoadDWVentas.Data.Context;
using LoadDWVentas.Data.Entities.DwVentas;
using LoadDWVentas.Data.Interfaces;
using LoadDWVentas.Data.Result;
using Microsoft.EntityFrameworkCore;

namespace LoadDWVentas.Data.Services
{
    public class DataServiceDwVentas : IDataServiceDwVentas
    {
        private readonly NorwindContext _norwindContext;
        private readonly DbSalesContext _salesContext;

        public DataServiceDwVentas(NorwindContext norwindContext,
                                   DbSalesContext salesContext)
        {
            _norwindContext = norwindContext;
            _salesContext = salesContext;
        }

        public async Task<OperactionResult> LoadDHW()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                await LoadDimEmployee();
                await LoadDimProductCategory();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el DWH Ventas. { ex.Message }";
            }

            return result;
        }

        private async Task<OperactionResult> LoadDimEmployee()
        {
            OperactionResult result = new OperactionResult();

            try
            {
                //Obtener los empleados de la base de datos de norwind.
                var employees = _norwindContext.Employees.AsNoTracking().Select(emp => new DimEmployee()
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeName = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToList();


                // Carga la dimension de empleados.
                await _salesContext.DimEmployees.AddRangeAsync(employees);

                await _salesContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando la dimension de empleado {ex.Message}";
            }


            return result;
        }

        private async Task<OperactionResult> LoadDimProductCategory()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                // Obtener las products categories de norwind //

                var productCategories = (from product in _norwindContext.Products
                                         join category in _norwindContext.Categories on product.CategoryId equals category.CategoryId
                                         select new DimProductCategory()
                                         {
                                             CategoryId = category.CategoryId,
                                             ProductName = product.ProductName,
                                             CategoryName = category.CategoryName,
                                             ProductId = product.ProductId
                                         }).AsNoTracking().ToList();

                
                // Carga la dimension de Products Categories.
                await _salesContext.DimProductCategories.AddRangeAsync(productCategories);
                await _salesContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimension de producto y categoria. {ex.Message}";
            }
            return result;
        }
    }
}
