using System.Data;
using System.Data.SqlClient;

namespace WpfHomeAppliance.DataModel
    {
    internal class Category:Brand
        {
        public string CatId
            {
            get; set;
            }
        public string CategoryName
            {
            get; set;
            }
        public override void Add()
            {
            var query = $"INSERT INTO category(Category) VALUES(@name)";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@name" , this.CategoryName);
                command.ExecuteNonQuery();
                }
            }
        public override void Delete()
            {
            var query = $"DELETE FROM category WHERE CatId= @id";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id" , this.CatId);
                command.ExecuteNonQuery();
                }
            }
        public override void Update()
            {
            var query = $"Update category SET Category =@name WHERE CatId=@id";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@name" , this.CategoryName);
                command.Parameters.AddWithValue("@id" , this.CatId);
                command.ExecuteNonQuery();
                }
            }
        public DataTable GetCategory()
            {
            _table = new DataTable();
            var query = $"SELECT CatId, Category FROM category";
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                SqlDataReader sdr = command.ExecuteReader();
                _table.Load(sdr);
                return _table;
                }
            }
        }
    }
