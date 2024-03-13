using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1020656.BusinessLayers
{   
    /// <summary>
    /// Khởi tạo, lưu trữ các thông tin cấu hình của BusinessLayer
    /// </summary>
    public static class Configuration
    {   
        /// <summary>
        /// Chuỗi kết nối thông số đến CSDL;
        /// </summary>
        public static string ConnectionString { get; set; } = "";

        /// <summary>
        /// Khởi tạo cấu hình cho BusinessLayer
        /// (Hàm này phải được gọi trước khi ứng dụng chạy)
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            Configuration.ConnectionString = connectionString;
        }
    }
}
