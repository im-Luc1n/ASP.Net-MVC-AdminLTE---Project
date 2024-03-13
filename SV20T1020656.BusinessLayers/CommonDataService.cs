using SV20T1020656.DataLayers;
using SV20T1020656.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV20T1020656.DataLayers.SQLServer;



namespace SV20T1020656.BusinessLayers
{
    /// <summary>
    /// Cung cấp các chức năng xử lý dữ liệu
    /// (Tỉnh thành / Khách hàng / Nhà cung cấp / Loại hàng / Người giao hàng / Nhân viên)
    /// </summary>
    public static class CommonDataService
    {
        private static readonly ICommonDAL<Customer> customerDB;
        private static readonly ICommonDAL<Province> provinceDB;
        private static readonly ICommonDAL<Category> categoryDB;
        private static readonly ICommonDAL<Employee> employeeDB;
        private static readonly ICommonDAL<Shipper>  shipperDB;
        private static readonly ICommonDAL<Supplier> supplierDB;

        static CommonDataService()
        {
            string connectionString = Configuration.ConnectionString;
            customerDB = new CustomerDAL(connectionString);
            provinceDB = new ProvinceDAL(connectionString);
            categoryDB = new CategoryDAL(connectionString);
            employeeDB = new EmployeeDAL(connectionString);
            shipperDB  = new ShipperDAL(connectionString);
            supplierDB = new SupplierDAL(connectionString);
        }

        /// <summary>
        /// Danh sách các tỉnh thành
        /// </summary>
        /// <returns></returns>
        public static List<Province> ListOfProvinces()
        {     
            return provinceDB.List().ToList();
        }


        /// <summary>
        /// Tìm kiếm và lấy danh sách khách hàng
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(out int rowCount,int page =1, int pageSize = 0, string searchValue="") 
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin một khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int id)
        {
            return customerDB.Get(id);
        }
        /// <summary>
        ///  Bổ sung khách hàng mới
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer customer)
        {
           return customerDB.Add(customer);
        }
        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer customer)
        {
            return customerDB.Update(customer);
        }
        /// <summary>
        ///  Xoá khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int id) 
        {
            if (customerDB.IsUsed(id))
                return false;
            return customerDB.Delete(id);
        }
        /// <summary>
        ///  Kiểm tra tài khoản có mã id có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsedCustomer(int id)
        {
            return customerDB.IsUsed(id);
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhà cung cấp
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin một nhà cung cấp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int id)
        {
            return supplierDB.Get(id);
        }
        /// <summary>
        ///  Bổ sung nhà cung cấp mới
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier supplier)
        {
            return supplierDB.Add(supplier);
        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier supplier)
        {
            return supplierDB.Update(supplier);
        }
        /// <summary>
        ///  Xoá nhà cung cấp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int id)
        {
            if (supplierDB.IsUsed(id))
                return false;
            return supplierDB.Delete(id);
        }
        /// <summary>
        ///  Kiểm tra nhà cung cấp có mã id có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsedSupplier(int id)
        {
            return supplierDB.IsUsed(id);
        }


        /// <summary>
        /// Tìm kiếm và lấy danh sách người giao hàng
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin một người giao hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int id)
        {
            return shipperDB.Get(id);
        }
        /// <summary>
        ///  Bổ sung người giao hàng mới
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper shipper)
        {
            return shipperDB.Add(shipper);
        }
        /// <summary>
        /// Cập nhật người giao hàng
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper shipper)
        {
            return shipperDB.Update(shipper);
        }
        /// <summary>
        ///  Xoá người giao hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int id)
        {
            if (shipperDB.IsUsed(id))
                return false;
            return shipperDB.Delete(id);
        }
        /// <summary>
        ///  Kiểm tra người giao hàng có mã id có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsedShipper(int id)
        {
            return shipperDB.IsUsed(id);
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách nhân viên
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin một nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int id)
        {
            return employeeDB.Get(id);
        }
        /// <summary>
        ///  Bổ sung người nhân viên mới
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee employee)
        {
            return employeeDB.Add(employee);
        }
        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee employee)
        {
            return employeeDB.Update(employee);
        }
        /// <summary>
        ///  Xoá nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int id)
        {
            if (employeeDB.IsUsed(id))
                return false;
            return employeeDB.Delete(id);
        }
        /// <summary>
        ///  Kiểm tra nhân viên có mã id có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsedEmployee(int id)
        {
            return employeeDB.IsUsed(id);
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách loại hàng
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Category> ListOfCategorys(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Lấy thông tin một loại hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Category GetCategory(int id)
        {
            return categoryDB.Get(id);
        }
        /// <summary>
        ///  Bổ sung người loại hàng mới
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static int AddCategory(Category category)
        {
            return categoryDB.Add(category);
        }
        /// <summary>
        /// Cập nhật loại hàng
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category category)
        {
            return categoryDB.Update(category);
        }
        /// <summary>
        ///  Xoá loại hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int id)
        {
            if (categoryDB.IsUsed(id))
                return false;
            return categoryDB.Delete(id);
        }
        /// <summary>
        ///  Kiểm tra loại hàng có mã id có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsedCategory(int id)
        {
            return categoryDB.IsUsed(id);
        }
    }
}
