﻿using SV20T1020656.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1020656.DataLayers
{
    public interface IProductDAL
    {
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
        IList<Product> List(int page = 1, int pageSize = 0, string searchValue = "", int categoryID = 0,int supplierID = 0,
                            decimal minPrice = 0, decimal maxPrice = 0);

        /// <summary>
        /// Đếm số lượng mặt hàng tìm kiếm
        /// </summary>
        /// <param name="searchValue">Tên mặt hàng cần tìm (chuỗi rỗng nếu không tìm kiếm)</param>
        /// <param name="categoryID">Mã loại hàng cần tìm (0 nếu không tìm theo loại hàng )</param>
        /// <param name="supplierID">Mã nhà cung cấp cần tìm (0 nếu không tìm theo nhà cung cấp )</param>
        /// <param name="minPrice">Mức giá nhỏ nhất trong khoản cần tìm </param>
        /// <param name="maxPrice">Mức giá lớn nhất trong khoản cần tìm  </param>
        /// <returns></returns>
        int Count(string searchValue = "", int categoryID = 0, int supplierID = 0,
                  decimal minPrice = 0, decimal maxPrice = 0);

        /// <summary>
        /// Thêm một mặt hàng mới
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Product data);

        /// <summary>
        /// Cập nhật một mặt hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Product data);

        /// <summary>
        /// Xoá mặt hàng theo mã hàng
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool Delete(int productID);

        /// <summary>
        /// Lấy thông tin mặt hàng theo mã hàng
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Product? Get(int productID);

        /// <summary>
        /// Kiểm tra mặt hàng có đơn liên quan hay không ?
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool InUsed(int productID);

        /// <summary>
        /// Lấy danh sách ảnh của mặt hàng theo thứ tự trong DisplayOrder
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        IList<ProductPhoto> ListPhotos(int productID);
        
        /// <summary>
        /// Bổ sung 1 ảnh mặt hàng ( Hàm trả về mã của ảnh được bổ sung)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        long AddPhoto(ProductPhoto data);

        /// <summary>
        ///  Cập nhật 1 ảnh 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdatePhoto(ProductPhoto data);

        /// <summary>
        /// Xoá ảnh của mặt hàng
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        bool DeletePhoto(long photoID);

        /// <summary>
        /// Lấy thông tin 1 ảnh dựa trên ID
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        ProductPhoto? GetPhoto(long photoID);


        /// <summary>
        /// Lấy danh sách thuộc tính của mặt hàng theo thứ tự trong DisplayOrder
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        IList<ProductAttribute> ListAttributes(int productID);

        /// <summary>
        /// Bổ sung 1 thuộc tính mặt hàng ( Hàm trả về mã của thuộc tính được bổ sung)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        long AddAttribute(ProductAttribute data);

        /// <summary>
        ///  Cập nhật 1 thuộc tính 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdateAttribute(ProductAttribute data);

        /// <summary>
        /// Xoá thuộc tính của mặt hàng
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        bool DeleteAttribute(long attributeID);

        /// <summary>
        /// Lấy thông tin 1 thuộc tính dựa trên ID
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        ProductAttribute? GetAttribute(long attributeID);

    }
}