using CAIT.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WedStore.Const;

namespace WedStore.Repositories
{
    public class OrderItemRes
    {
        private int Discount;
        private int OrderId;
        private string ItemID;
        private string OrderID;
        private string BookID;
        private int Quantity;
        private int TotalPrice;

        public static bool CreateOrderItem(OrderItem orderItem)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderItem_Create", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ItemID", orderItem.ItemID);
                        command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                        command.Parameters.AddWithValue("@BookID", orderItem.BookID);
                        command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                        command.Parameters.AddWithValue("@TotalPrice", orderItem.TotalPrice);
                        command.Parameters.AddWithValue("@Discount", orderItem.Discount);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }
        public static bool UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                string connectionString = "Server=DESKTOP-BVMOLV3;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderItem_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ItemID", orderItem.ItemID);
                        command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                        command.Parameters.AddWithValue("@BookID", orderItem.BookID);
                        command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                        command.Parameters.AddWithValue("@TotalPrice", orderItem.TotalPrice);
                        command.Parameters.AddWithValue("@Discount", orderItem.Discount);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }
        public static bool DeleteOrderItem(string id)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderItem_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }
        private static string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";

        public static List<OrderItem> GetInfoOrdersWithOrderID(string orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetInfoOrdersWithOrderID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", orderID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            foreach (DataRow dr in result.Rows)
                            {
                                orderItems.Add(new OrderItem
                                {
                                    ItemID = dr["ItemID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    BookID = dr["BookID"].ToString(),
                                    Quantity = dr["Quantity"] != DBNull.Value ? Convert.ToInt32(dr["Quantity"]) : 0,
                                    TotalPrice = dr["TotalPrice"] != DBNull.Value ? Convert.ToInt32(dr["TotalPrice"]) : 0,
                                    Discount = dr["Discount"] != DBNull.Value ? Convert.ToInt32(dr["Discount"]) : 0
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                throw;
            }

            return orderItems; // Trả về danh sách OrderItem
        }
        public static bool deleteOrderItem(string itemID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderItem_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ItemID", itemID);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }

        public static List<OrderItem> GetOrderItemsWithOrderID(string orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetOrderItemsWithOrderID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", orderID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            foreach (DataRow dr in result.Rows)
                            {
                                orderItems.Add(new OrderItem
                                {
                                    ItemID = dr["ItemID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    BookID = dr["BookID"].ToString(),
                                    Quantity = dr["Quantity"] != DBNull.Value ? Convert.ToInt32(dr["Quantity"]) : 0,
                                    TotalPrice = dr["TotalPrice"] != DBNull.Value ? Convert.ToInt32(dr["TotalPrice"]) : 0,
                                    Discount = dr["Discount"] != DBNull.Value ? Convert.ToInt32(dr["Discount"]) : 0
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                throw;
            }

            return orderItems; // Trả về danh sách OrderItem (không phải đối tượng OrderItem)
        }


        public static OrderItem GetOrderItemWithID(string id)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderItem_GetOrderItemWithID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", id);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                DataRow dr = result.Rows[0];
                                return new OrderItem
                                {
                                    ItemID = dr["ItemID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    BookID = dr["BookID"].ToString(),
                                    Quantity = string.IsNullOrEmpty(dr["Quantity"].ToString()) ? 0 : int.Parse(dr["Quantity"].ToString()),
                                    TotalPrice = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) ? 0 : int.Parse(dr["TotalPrice"].ToString()),
                                    Discount = string.IsNullOrEmpty(dr["Discount"].ToString()) ? 0 : int.Parse(dr["Discount"].ToString())
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return null;
            }
        }
        public static OrderItem GetOrderItemWithOrderIDBookID(string orderID, string bookID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("OrderItem_GetOrderItemWithOrderIDBookID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", orderID);
                        command.Parameters.AddWithValue("@BookID", bookID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                DataRow dr = result.Rows[0];
                                return new OrderItem
                                {
                                    ItemID = dr["ItemID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    BookID = dr["BookID"].ToString(),
                                    Quantity = string.IsNullOrEmpty(dr["Quantity"].ToString()) ? 0 : int.Parse(dr["Quantity"].ToString()),
                                    TotalPrice = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) ? 0 : int.Parse(dr["TotalPrice"].ToString()),
                                    Discount = string.IsNullOrEmpty(dr["Discount"].ToString()) ? 0 : int.Parse(dr["Discount"].ToString())
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return null;
            }
        }



    }
}
