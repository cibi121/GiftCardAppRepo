using GiftCardOrdering.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardOrdering.Data
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Orders (UserID, DeliveryOptionID, DeliveryAddress, TotalAmount, CreditCardSurcharge, OrderDate) VALUES (@UserID, @DeliveryOptionID, @DeliveryAddress, @TotalAmount, @CreditCardSurcharge, @OrderDate); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@UserID", order.UserID);
                cmd.Parameters.AddWithValue("@DeliveryOptionID", order.DeliveryOptionID);
                cmd.Parameters.AddWithValue("@DeliveryAddress", order.DeliveryAddress);
                cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                cmd.Parameters.AddWithValue("@CreditCardSurcharge", order.CreditCardSurcharge);
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                conn.Open();
                order.OrderID = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Order GetOrderById(int orderId)
        {
            Order order = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE OrderID = @OrderID", conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            UserID = (int)reader["UserID"],
                            DeliveryOptionID = (int)reader["DeliveryOptionID"],
                            DeliveryAddress = (string)reader["DeliveryAddress"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            CreditCardSurcharge = (decimal)reader["CreditCardSurcharge"],
                            OrderDate = (DateTime)reader["OrderDate"]
                        };
                    }
                }
            }
            return order;
        }

        // Add methods for Update and Delete as needed
    }
}
