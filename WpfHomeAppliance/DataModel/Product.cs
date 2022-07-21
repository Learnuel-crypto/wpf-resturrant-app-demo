using System.Data;
using System.Data.SqlClient;

namespace WpfHomeAppliance.DataModel
    {
    internal class Product:Category
        {

        public string ProId
            {
            get; set;
            }
        public string Name
            {
            get; set;
            }
        public int Quantity
            {
            get; set;
            }
        public decimal Price
            {
            get; set;
            }
        public void AddProduct()
            {
            var query = $"INSERT INTO product(Name,Quantity,Price,UserId,CatId,BrandId) VALUES(@name,@qty,@price,@userid,(SELECT CatId FROM category WHERE Category =@category),(SELECT BrandId FROM brand WHERE Brand =@brand))";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@name" , this.Name);
                command.Parameters.AddWithValue("@qty" , this.Quantity);
                command.Parameters.AddWithValue("@price" , this.Price);
                command.Parameters.AddWithValue("@userid" , User.Id);
                command.Parameters.AddWithValue("@category" , this.CategoryName);
                command.Parameters.AddWithValue("@brand" , this.BrandName);
                command.ExecuteNonQuery();
                }
            }
        public void UpdateProduct()
            {
            var query = $"UPDATE product SET Name =@name, Quantity =@qty, Price=@price, CatId=(SELECT CatId FROM category WHERE Category =@category), BrandId=(SELECT BrandId FROM brand WHERE Brand =@brand) WHERE ProId=proid";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@proid" , this.ProId);
                command.Parameters.AddWithValue("@name" , this.Name);
                command.Parameters.AddWithValue("@qty" , this.Quantity);
                command.Parameters.AddWithValue("@price" , this.Price);
                command.Parameters.AddWithValue("@userid" , User.Id);
                command.Parameters.AddWithValue("@category" , this.CategoryName);
                command.Parameters.AddWithValue("@brand" , this.BrandName);
                command.ExecuteNonQuery();
                }
            }

        public void DeleteProduct()
            {
            var query = $"DELETE FROM product WHERE ProId=@proid";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@proid" , this.ProId); 
                command.ExecuteNonQuery();
                }
            }
        public void UpdateQauntity()
            {
            var query = $"UPDATE product SET Quantity =@aty  WHERE ProId=proid"; 
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@proid" , this.ProId);
                command.Parameters.AddWithValue("@qty" , this.Quantity);
                command.ExecuteNonQuery();
                }
            }
        public DataTable GetProducts()
            {
            _table = new DataTable();
            var query = $"SELECT ProId,Name,c.Category,b.Brand,Quantity AS Qty, Price FROM brand b INNER JOIN product p ON p.BrandId =b.BrandId INNER JOIN category c ON p.CatId = c.CatId WHERE UserId=@userid";
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@userid" , User.Id);
                SqlDataReader sdr = command.ExecuteReader();
                _table.Load(sdr);
                return _table;
                }
            }
        public DataTable SearchProducts(string search)
            {
            _table = new DataTable();
            var query = $"SELECT ProId,Name,c.Category,b.Brand,Quantity AS Qty, Price FROM brand b INNER JOIN product p ON p.BrandId =b.BrandId INNER JOIN category c ON p.CatId = c.CatId WHERE Name LIKE '%'@search'%' AND UserId=@userid";
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@userid" , User.Id);
                command.Parameters.AddWithValue("@search" ,search);
                SqlDataReader sdr = command.ExecuteReader();
                _table.Load(sdr);
                return _table;
                }
            }
        }
    }
