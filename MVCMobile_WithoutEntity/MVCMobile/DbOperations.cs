using Microsoft.Data.SqlClient;
using MVCMobile.Models;

namespace MVCMobile
{
    public class DbOperations
    {
        SqlConnection cn = new SqlConnection();

        public DbOperations()
        {
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Technology;Integrated Security=True;";

        }

        public List<Mobile> getAllDetails()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Mobiles";

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Mobile> list = new List<Mobile>();
            while (dr.Read())
            {
                list.Add(new Mobile
                {
                    MobileId = (int)dr["MobileId"],
                    Name = (string)dr["Name"],
                    Brand = (string)dr["Brand"],
                    Price = (int)dr["Price"]
                });
            }
            return list;
        }

        public Mobile getSingleDetails(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Mobiles where MobileId=@MobileId";
            cmd.Parameters.AddWithValue("@MobileId", id);

            cn.Open();

            Mobile mob = null;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                mob = new Mobile
                {
                    MobileId = (int)dr["MobileId"],
                    Name = (string)dr["Name"],
                    Brand = (string)dr["Brand"],
                    Price = (int)dr["Price"]
                };
            }
            return mob;
        }

        public void CreateMobile(Mobile mob)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Mobiles values(@MobileId, @Name, @Brand, @Price)";
            cmd.Parameters.AddWithValue("@MobileId", mob.MobileId);
            cmd.Parameters.AddWithValue("@Name", mob.Name);
            cmd.Parameters.AddWithValue("@Brand", mob.Brand);
            cmd.Parameters.AddWithValue("@Price", mob.Price);
            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void editMobile(Mobile mob)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Mobiles set Name=@Name,Brand=@Brand,Price=@Price  where MobileId=@MobileId";
            cmd.Parameters.AddWithValue("@MobileId", mob.MobileId);
            cmd.Parameters.AddWithValue("@Name", mob.Name);
            cmd.Parameters.AddWithValue("@Brand", mob.Brand);
            cmd.Parameters.AddWithValue("@Price", mob.Price);
            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void deleteMobile(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from Mobiles where MobileId=@MobileId";
            cmd.Parameters.AddWithValue("@MobileId", id);
            cn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
