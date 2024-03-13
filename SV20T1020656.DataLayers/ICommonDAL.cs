using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1020656.DataLayers
{
    /// <summary>
    /// Mô tả phép xử lý chung
    /// </summary>
    
    public interface ICommonDAL<T> where T : class
    {
        /// <summary>Tìm kiếm và lấy danh sách dữ liệu dưới dạng phân trang</summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang ( bằng 0 nếu không phân trang )</param>
        /// <param name="searchValue">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu )</param>
        /// <returns></returns>
        IList<T> List(int page = 1, int pageSize = 0, string searchValue= "");


        /// <summary>Đếm số dòng dữ liệu tìm được</summary>
        /// <param name="searhValue">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu )</param>
        /// <returns></returns>
        int Count(string searchValue = "");


        /// <summary>Bổ dung dữ liệu vào cơ sở dữ liệu. Hàm trả về ID của dữ liệu được bổ dung, trả về 0 nếu việc bổ sung không thành công</summary>
        /// <param name="data">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu )</param>
        /// <returns></returns>
        int Add(T data);


        /// <summary>Cập nhật dữ liệu</summary>
        /// <param name="data">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu ) </param>
        /// <returns></returns>
        bool Update(T data);

        /// <summary>Xoá dữ liệu dựa trên id</summary>
        /// <param name="id">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu )</param>
        /// <returns></returns>
        bool Delete(int id);


        /// <summary>Lấy một bản ghi dựa vào id ( trả về null nếu không tồn tại )</summary>
        /// <param name="id">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu )</param>
        /// <returns></returns>
        T? Get(int id);


        /// <summary>Kiểm tra xem bảng ghi có mã id đang có được sử dụng hay không</summary>
        /// <param name="id">Giá trị cần tìm kiếm ( chuỗi rỗng nếu lấy toàn bộ dữ liệu )</param>
        /// <returns></returns>
        bool IsUsed(int id);
    }
}
