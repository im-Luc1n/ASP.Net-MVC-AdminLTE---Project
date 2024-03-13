using Dapper;
using SV20T1020656.DomainModels;
using SV20T1020656.DataLayers.SQLServer;
using SV20T1020656.DataLayers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1020656.DataLayers.SQLServer
{
    public class ProductDAL : _BaseDAL, IProductDAL
    {
        public ProductDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Product data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(SELECT * FROM Products WHERE ProductName = @ProductName)
                                select -1
                            else
                                begin
                                    insert into Products(ProductName, ProductDescription, SupplierID, CategoryID, Unit, Price, Photo,IsSelling)
                                    values(@ProductName, @ProductDescription, @SupplierID, @CategoryID, @Unit, @Price, @Photo ,@IsSelling);

                                    select @@identity;
                                end";
                var parameters = new
                {
                    ProductName = data.ProductName ?? "",
                    ProductDescription = data.ProductDescription,
                    SupplierID = data.SupplierID,
                    CategoryID = data.CategoryID,
                    Unit = data.Unit ?? "",
                    Price = data.Price,
                    Photo = data.Photo ?? "",
                    IsSelling = data.IsSelling
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public long AddAttribute(ProductAttribute data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from ProductAttributes where AttributeName = @AttributeName)
                                select -1
                            else
                                begin
                                    insert into ProductAttributes(ProductID, AttributeName, AttributeValue, DisplayOrder)
                                    values(@ProductID, @AttributeName, @AttributeValue, @DisplayOrder);

                                    select @@identity;
                                end
                           ";
                var parameters = new
                {
                    ProductID = data.ProductID,
                    AttributeName = data.AttributeName ?? "",
                    AttributeValue = data.AttributeValue ?? "",
                    DisplayOrder = data.DisplayOrder

                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public long AddPhoto(ProductPhoto data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"INSERT INTO ProductPhotos (ProductID, Photo, Description, DisplayOrder,IsHidden)
                            VALUES (@ProductID, @Photo, @Description, @DisplayOrder,@IsHidden);
                           ";
                var parameters = new
                {
                    ProductID = data.ProductID,
                    Photo = data.Photo ?? "",
                    Description = data.Description ?? "",
                    DisplayOrder = data.DisplayOrder,
                    IsHidden = data.IsHidden

                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int Count(string searchValue = "", int CategoryID = 0, int SupplierID = 0, decimal minPrice = 0, decimal maxPrice = 0)
        {
            int count = 0;

            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (var connection = OpenConnection())
            {
                var sql = @"SELECT COUNT(*) FROM Products 
                            where   (@SearchValue = N'' or ProductName like @SearchValue)
                                and (@CategoryID = 0 or CategoryID = @CategoryID)
                                and (@SupplierID = 0 or SupplierId = @SupplierID)
                                and (Price >= @MinPrice)
                                and (@MaxPrice <= 0 or Price <= @MaxPrice)";

                var parameters = new
                {
                    searchValue = searchValue,
                    CategoryID = CategoryID,
                    SupplierID = SupplierID,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice

                };

                count = connection.ExecuteScalar<int>(sql, parameters, commandType: CommandType.Text);
                connection.Close();
            }

            return count;
        }

        public bool Delete(int productID)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Products where ProductID = @productID";
                var parameters = new
                {
                    ProductID = productID
                };
                //Thuc thi
                resutl = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return resutl;
        }

        public bool DeleteAttribute(long attributeID)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from ProductAttributes where AttributeID = @attributeID";
                var parameters = new
                {
                    AttributeID = attributeID
                };
                resutl = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return resutl;
        }

        public bool DeletePhoto(long photoID)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from ProductPhotos where PhotoID = @photoID";
                var parameters = new
                {
                    PhotoID = photoID
                };
                //Thuc thi
                resutl = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return resutl;
        }

        public Product Get(int productID)
        {
            Product? product = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Products where ProductID = @productID";
                var parameters = new
                {
                    ProductID = productID
                };
                //Thuc thi
                product = connection.QueryFirstOrDefault<Product>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return product;
        }

        public ProductAttribute? GetAttribute(long attributeID)
        {
            ProductAttribute? ProductAttribute = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from ProductAttributes where AttributeID = @attributeID";
                var parameters = new
                {
                    AttributeID = attributeID
                };
                //Thuc thi
                ProductAttribute = connection.QueryFirstOrDefault<ProductAttribute>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return ProductAttribute;
        }

        public ProductPhoto? GetPhoto(long photoID)
        {
            ProductPhoto? ProductPhoto = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from ProductPhotos where PhotoID = @photoID";
                var parameters = new
                {
                    PhotoID = photoID
                };
                //Thuc thi
                ProductPhoto = connection.QueryFirstOrDefault<ProductPhoto>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return ProductPhoto;
        }

        public bool InUsed(int productID)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from OrderDetails where ProductID = @productID)
                                select 1
                            else 
                                select 0";
                var parameters = new
                {
                    ProductID = productID
                };
                //Thuc thi
                resutl = connection.ExecuteScalar<bool>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return resutl;
        }

        public IList<Product> List(int page = 1, int pageSize = 0, string searchValue = " ", int categoryID = 0,
            int supplierID = 0, decimal minPrice = 0, decimal maxPrice = 0)
        {
            List<Product> list = new List<Product>();

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = "%" + searchValue + "%";
            }
            using (var connection = OpenConnection())
            {
                var sql = @"with cte as(
                            select  *,
                                    row_number() over(order by ProductName) as RowNumber
                            from    Products
                            where   (@SearchValue = N'' or ProductName like @SearchValue)
                                and (@CategoryID = 0 or CategoryID = @CategoryID)
                                and (@SupplierID = 0 or SupplierId = @SupplierID)
                                and (Price >= @MinPrice)
                                and (@MaxPrice <= 0 or Price <= @MaxPrice)
                        )
                        select * from cte
                        where   (@PageSize = 0)
                            or (RowNumber between (@Page - 1)*@PageSize + 1 and @Page * @PageSize)";
                var parameters = new
                {
                    page = page,
                    pageSize = pageSize,
                    searchValue = searchValue ?? "",
                    CategoryID = categoryID,
                    SupplierID = supplierID,
                    minPrice = minPrice,
                    maxPrice = maxPrice
                };
                list = connection.Query<Product>(sql, parameters, commandType: CommandType.Text).ToList();
                connection.Close();
            }
            return list;
        }

        public IList<ProductAttribute> ListAttributes(int productID)
        {
            List<ProductAttribute> list = new List<ProductAttribute>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from ProductAttributes where ProductID = @productID order by DisplayOrder";
                var parameters = new
                {
                    ProductID = productID,
                };
                list = connection.Query<ProductAttribute>(sql, parameters, commandType: CommandType.Text).ToList();
                connection.Close();
            }
            return list;
        }

        public IList<ProductPhoto> ListPhotos(int productID)
        {
            List<ProductPhoto> list = new List<ProductPhoto>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from ProductPhotos where ProductID = @productID order by DisplayOrder";
                var parameters = new
                {
                    ProductID = productID,
                };
                list = connection.Query<ProductPhoto>(sql, parameters, commandType: CommandType.Text).ToList();
                connection.Close();
            }
            return list;
        }

        public bool Update(Product data)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if not exists(SELECT * FROM Products WHERE ProductID <> @ProductID AND ProductName = @ProductName)
                        begin
                            update Products 
                              set ProductName = @ProductName,
                              ProductDescription = @ProductDescription,
                              SupplierID = @SupplierID,
                              CategoryID = @CategoryID,
                              Unit = @Unit,
                              Price=@Price,
                              Photo = @Photo,
                              IsSelling = @IsSelling
                              WHERE ProductID = @ProductID
                       end";
                var parameters = new
                {
                    ProductID = data.ProductID,
                    ProductName = data.ProductName ?? "",
                    ProductDescription = data.ProductDescription ?? "",
                    SupplierID = data.SupplierID,
                    CategoryID = data.CategoryID,
                    Unit = data.Unit ?? "",
                    Price = data.Price,
                    Photo = data.Photo ?? "",
                    IsSelling = data.IsSelling
                };
                //Thuc thi
                resutl = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return resutl;
        }

        public bool UpdateAttribute(ProductAttribute data)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if not exists(SELECT * FROM ProductAttributes WHERE AttributeID <> @AttributeID AND AttributeName = @AttributeName)
                        begin
                        update ProductAttributes 
                        SET
                        ProductID = @ProductID,
                        AttributeName = @AttributeName,
                        AttributeValue = @AttributeValue,
                        DisplayOrder = @DisplayOrder
 
                        WHERE AttributeID = @AttributeID
                       end";
                var parameters = new
                {
                    AttributeID = data.AttributeID,
                    ProductID = data.ProductID,
                    AttributeName = data.AttributeName ?? "",
                    AttributeValue = data.AttributeValue ?? "",
                    DisplayOrder = data.DisplayOrder,

                };//Thuc thi
                resutl = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return resutl;
        }


        public bool UpdatePhoto(ProductPhoto data)
        {
            bool resutl = false;
            using (var connection = OpenConnection())
            {
                var sql = @"UPDATE ProductPhotos 
                    SET ProductID = @ProductID,
                        Photo = @Photo,
                        Description = @Description,
                        DisplayOrder = @DisplayOrder,
                        IsHidden =@IsHidden
                    WHERE PhotoID = @PhotoID";
                var parameters = new
                {
                    PhotoID = data.PhotoID,
                    ProductID = data.ProductID,
                    Photo = data.Photo ?? "",
                    Description = data.Description ?? "",
                    DisplayOrder = data.DisplayOrder,
                    IsHidden = data.IsHidden,

                };
                //Thuc thi
                resutl = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return resutl;
        }
    }
}