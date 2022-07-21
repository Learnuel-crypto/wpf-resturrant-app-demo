using System.Data;
using System.Data.SqlClient;

namespace WpfHomeAppliance.DataModel
    {
    internal class Brand
        {
        public DataTable _table;
        public string BrandId
            {
            get; set;
            }
        public string BrandName
            {
            get; set;
            }
        public virtual void Add()
            {
            var query = $"INSERT INTO brand(Brand) VALUES(@name)";
           
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@name" , this.BrandName); 
                command.ExecuteNonQuery(); 
                }
            }
        public virtual void Delete()
            {
            var query = $"DELETE FROM brand WHERE BrandId= @id";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@id" , this.BrandId);
                command.ExecuteNonQuery();
                }
            }
        public virtual void Update()
            {
            var query = $"Update brand SET Brand = WHERE BrandId=@id";

            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@name" , this.BrandName);
                command.Parameters.AddWithValue("@id" , this.BrandId);
                command.ExecuteNonQuery();
                }
            }
        public DataTable GetBrand()
            {
            _table = new DataTable();
            var query = $"SELECT BrandId, Brand FROM brand";
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
