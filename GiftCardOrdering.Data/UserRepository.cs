using GiftCardOrdering.Domain;
using System.Data.SqlClient;

namespace GiftCardOrdering.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (FullName, Email, Phone, Address, CreatedAt) VALUES (@FullName, @Email, @Phone, @Address, @CreatedAt); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                conn.Open();
                user.UserID = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public User GetUserById(int userId)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserID = (int)reader["UserID"],
                            FullName = (string)reader["FullName"],
                            Email = (string)reader["Email"],
                            Phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : null,
                            Address = (string)reader["Address"],
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        };
                    }
                }
            }
            return user;
        }

        // Add methods for Update and Delete as needed
    }
}