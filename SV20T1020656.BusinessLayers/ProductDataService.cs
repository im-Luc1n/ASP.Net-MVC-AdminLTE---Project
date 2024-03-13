using SV20T1020656.DataLayers;
using SV20T1020656.DataLayers.SQLServer;
using SV20T1020656.DataLayers.SQLServer;
using SV20T1020656.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1020656.BusinessLayers
{
    public static class ProductDataService
    {
        private static readonly IProductDAL productDB;

        static ProductDataService()
        {
            productDB = new ProductDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách mặt hàng dưới dạng không phân trang
        /// </summary>
        /// <param name="searchValue">Tên mặt hàng cần tìm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<Product> ListOfProducts(string searchValue = "")
        {
            return productDB.List(0, 0, searchValue).ToList();
        }

        /// <summary>
        /// Tìm kiếm và lấy danh sách mặt hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Tên mặt hàng cần tìm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="categoryID">Mã loại hàng cần tìm (0 nếu không tìm theo loại hàng )</param>
        /// <param name="supplierID">Mã nhà cung cấp cần tìm (0 nếu không tìm theo nhà cung cấp )</param>
        /// <param name="minPrice">Mức giá nhỏ nhất trong khoản cần tìm </param>
        /// <param name="maxPrice">Mức giá lớn nhất trong khoản cần tìm  </param>
        /// <returns></returns>
        public static List<Product> ListOfProducts(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "", int categoryID = 0, int supplierID = 0,
                            decimal minPrice = 0, decimal maxPrice = 0)
        {
            rowCount = productDB.Count(searchValue);
            return productDB.List(page, pageSize, searchValue,categoryID,supplierID,minPrice,maxPrice).ToList();
        }

        /// <summary>
        /// Lấy thông tin một mặt hàng
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static Product? GetProduct(int productID)
        {
            return productDB.Get(productID);
        }
        /// <summary>
        ///  Bổ sung mặt hàng mới
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddProduct(Product data)
        {
            return productDB.Add(data);
        }
        /// <summary>
        /// Cập nhật mặt hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateProduct(Product data)
        {
            return productDB.Update(data);
        }
        /// <summary>
        ///  Xoá mặt hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteProduct(int productID)
        {
            if (productDB.InUsed(productID))
                return false;
            return productDB.Delete(productID);
        }
        /// <summary>
        ///  Kiểm tra tài khoản có mã id có dữ liệu liên quan hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool InUsedProduct(int productID)
        {
            return productDB.InUsed(productID);
        }

        //-------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Lấy danh sách ảnh dựa trên mã sản phẩm
        /// </summary>
        /// <param name="searchValue">Tên mặt hàng cần tìm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        public static List<ProductPhoto> ListPhotos(int productID)
        {           
            return productDB.ListPhotos(productID).ToList();
        }

        /// <summary>
        /// Lấy thông tin một ảnh
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static ProductPhoto? GetPhoto(long photoID)
        {
            return productDB.GetPhoto(photoID);
        }
        /// <summary>
        ///  Bổ sung ảnh mới
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static long AddPhoto(ProductPhoto data)
        {
            return productDB.AddPhoto(data);
        }
        /// <summary>
        /// Cập nhật một ảnh sản phẩm
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdatePhoto(ProductPhoto data)
        {
            return productDB.UpdatePhoto(data);
        }
        /// <summary>
        ///  Xoá ảnh
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePhoto(long photoID)
        {           
            return productDB.DeletePhoto(photoID);
        }

        //-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Trả về một dãy thuộc tính dựa trên mã sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static List<ProductAttribute> ListAttribute(int productID)
        {
            return productDB.ListAttributes(productID).ToList();
        }

        /// <summary>
        /// Lấy thông tin một thuộc tính
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static ProductAttribute? GetAttribute(int attributeID)
        {
            return productDB.GetAttribute(attributeID);
        }
        /// <summary>
        ///  Bổ sung thuộc tính mới
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static long AddAttribute(ProductAttribute data)
        {
            return productDB.AddAttribute(data);
        }
        /// <summary>
        /// Cập nhật thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateAttribute(ProductAttribute data)
        {
            return productDB.UpdateAttribute(data);
        }
        /// <summary>
        ///  Xoá thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public static bool DeleteAttribute(long attributeID)
        {
            return productDB.DeleteAttribute(attributeID);
        }
    }
}
