﻿using LoadDWVentas.Data.Context;
using LoadDWVentas.Data.Entities.DwVentas;
using LoadDWVentas.Data.Interfaces;
using LoadDWVentas.Data.Result;
using Microsoft.EntityFrameworkCore;

namespace LoadDimsDWH.Data.Services
{
    public class DataServiceDwOrders : IDataServiceDwOrders
    {
        private readonly NorthwindOrder _dbOrdersContext;
        private readonly NorwindContext _norwindContext;

        public DataServiceDwOrders(NorthwindOrder dbOrdersContext, NorwindContext northwindContext)
        {
            _dbOrdersContext = dbOrdersContext;
            _norwindContext = northwindContext;
        }

        public async Task<OperactionResult> LoadDwh()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                await LoadDimCustomer();
                await LoadDimEmployee();
                await LoadDimShippers();
                await LoadDimCategories();
                await LoadDimProduct();

                result.Success = true;
                result.Message = "All dimensions loaded successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading dimensions: {ex.Message}";
            }
            return result;
        }

        private async Task<OperactionResult> LoadDimCustomer()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                var customers = await _norwindContext.Customers.Select(cust => new DimCustomers
                {
                    CustomerID = cust.CustomerID,
                    CompanyName = cust.CompanyName,
                    ContactName = cust.ContactName,
                    ContactTitle = cust.ContactTitle,
                    Address = cust.Address,
                    City = cust.City,
                    Region = cust.Region,
                    PostalCode = cust.PostalCode,
                    Country = cust.Country,
                    Phone = cust.Phone,
                    Fax = cust.Fax
                }).AsNoTracking().ToListAsync();

                await _dbOrdersContext.DimCustomers.AddRangeAsync(customers);
                await _dbOrdersContext.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading Customers dimension: {ex.Message}";
            }
            return result;
        }

        private async Task<OperactionResult> LoadDimEmployee()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                var employees = await _norwindContext.Employees.Select(emp => new DimEmployees
                {
                    EmployeeID = emp.EmployeeId,
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Title = emp.Title,
                    TitleOfCourtesy = emp.TitleOfCourtesy,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Address = emp.Address,
                    City = emp.City,
                    Region = emp.Region,
                    PostalCode = emp.PostalCode,
                    Country = emp.Country,
                    HomePhone = emp.HomePhone,
                    Extension = emp.Extension,
                    Notes = emp.Notes,
                    ReportsTo = emp.ReportsTo,
                    PhotoPath = emp.PhotoPath
                }).AsNoTracking().ToListAsync();

                int[] employeeIds = employees.Select(e => e.EmployeeID).ToArray();

                await _dbOrdersContext.DimEmployees.Where(e => employeeIds.Contains(e.EmployeeID))
                                                   .AsNoTracking()
                                                   .ExecuteDeleteAsync();

                await _dbOrdersContext.DimEmployees.AddRangeAsync(employees);
                await _dbOrdersContext.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading Employee dimension: {ex.Message}";
            }
            return result;
        }

        private async Task<OperactionResult> LoadDimShippers()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                var shippers = await _norwindContext.Shippers.Select(ship => new DimShippers
                {
                    ShipperID = ship.ShipperID,
                    ShipperName = ship.CompanyName,
                    Phone = ship.Phone
                }).AsNoTracking().ToListAsync();

                int[] shipperIds = shippers.Select(s => s.ShipperID).ToArray();

                await _dbOrdersContext.DimShippers.Where(s => shipperIds.Contains(s.ShipperID))
                                                  .AsNoTracking()
                                                  .ExecuteDeleteAsync();

                await _dbOrdersContext.DimShippers.AddRangeAsync(shippers);
                await _dbOrdersContext.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading Shippers dimension: {ex.Message}";
            }
            return result;
        }

        private async Task<OperactionResult> LoadDimCategories()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                var categories = await _norwindContext.Categories.Select(cat => new DimCategories
                {
                    CategoryID = cat.CategoryID,
                    CategoryName = cat.CategoryName,
                    Description = cat.Description,
                    Picture = cat.Picture
                }).AsNoTracking().ToListAsync();

                int[] categoryIds = categories.Select(c => c.CategoryID).ToArray();

                await _dbOrdersContext.DimCategories.Where(c => categoryIds.Contains(c.CategoryID))
                                                    .AsNoTracking()
                                                    .ExecuteDeleteAsync();

                await _dbOrdersContext.DimCategories.AddRangeAsync(categories);
                await _dbOrdersContext.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading Categories dimension: {ex.Message}";
            }
            return result;
        }

        private async Task<OperactionResult> LoadDimProduct()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                var products = await _norwindContext.Products.Select(prod => new DimProducts
                {
                    ProductID = prod.ProductID,
                    ProductName = prod.ProductName,
                    SupplierID = prod.SupplierID,
                    CategoryID = prod.CategoryID,
                    QuantityPerUnit = prod.QuantityPerUnit,
                    UnitPrice = prod.UnitPrice,
                    UnitsInStock = prod.UnitsInStock,
                    UnitsOnOrder = prod.UnitsOnOrder,
                    ReorderLevel = prod.ReorderLevel,
                    Discontinued = prod.Discontinued
                }).AsNoTracking().ToListAsync();

                int[] productIds = products.Select(p => p.ProductID).ToArray();

                await _dbOrdersContext.DimProducts.Where(p => productIds.Contains(p.ProductID))
                                                  .AsNoTracking()
                                                  .ExecuteDeleteAsync();

                await _dbOrdersContext.DimProducts.AddRangeAsync(products);
                await _dbOrdersContext.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading Products dimension: {ex.Message}";
            }
            return result;
        }

        public async Task<OperactionResult> LoadDHW()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                await LoadDimCategories();
                await LoadDimCustomer();
                await LoadDimEmployee();
                await LoadDimProduct();
                await LoadDimShippers();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error cargando el DWH Ventas. {ex.Message}";
            }

            return result;
        }
    }
}
