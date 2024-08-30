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
    public class OrdersRes
    {

        public static bool createOrders(Orders orders)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Orders_Create", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", orders.OrderID);
                        command.Parameters.AddWithValue("@UserName", orders.UserName);
                        command.Parameters.AddWithValue("@OrderPrice", orders.OrderPrice);
                        command.Parameters.AddWithValue("@OrderStatus", orders.OrderStatus);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
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
        public static List<Orders> GetOrdersUser(string userName)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            List<Orders> lstResult = new List<Orders>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Orders_GetOrdersUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            foreach (DataRow dr in result.Rows)
                            {
                                Orders orders = new Orders
                                {
                                    OrderID = dr["OrderID"].ToString(),
                                    UserName = dr["UserName"].ToString(),
                                    OrderPrice = string.IsNullOrEmpty(dr["OrderPrice"].ToString()) ? 0 : int.Parse(dr["OrderPrice"].ToString()),
                                    OrderStatus = string.IsNullOrEmpty(dr["OrderStatus"].ToString()) ? 0 : int.Parse(dr["OrderStatus"].ToString())
                                };
                                lstResult.Add(orders);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }

            return lstResult;
        }
        public static Orders GetOrdersUserOnStatus(string userName, int status)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Orders_GetOrdersUserOnStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Status", status);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                DataRow dr = result.Rows[0];
                                Orders orders = new Orders
                                {
                                    OrderID = dr["OrderID"].ToString(),
                                    UserName = dr["UserName"].ToString(),
                                    OrderPrice = string.IsNullOrEmpty(dr["OrderPrice"].ToString()) ? 0 : int.Parse(dr["OrderPrice"].ToString()),
                                    OrderStatus = string.IsNullOrEmpty(dr["OrderStatus"].ToString()) ? 0 : int.Parse(dr["OrderStatus"].ToString())
                                };
                                return orders;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }

            return null;
        }
        public static Orders GetOrdersWithID(string id)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Orders_GetOrdersWithID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", id);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                DataRow dr = result.Rows[0];
                                Orders orders = new Orders
                                {
                                    OrderID = dr["OrderID"].ToString(),
                                    UserName = dr["UserName"].ToString(),
                                    OrderPrice = string.IsNullOrEmpty(dr["OrderPrice"].ToString()) ? 0 : int.Parse(dr["OrderPrice"].ToString()),
                                    OrderStatus = string.IsNullOrEmpty(dr["OrderStatus"].ToString()) ? 0 : int.Parse(dr["OrderStatus"].ToString())
                                };
                                return orders;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }

            return null;
        }
        public static bool checkOrders(string userName)
        {
            Orders orders = GetOrdersUserOnStatus(userName, 1);
            if (orders == null)
            {
                Orders newOrder = new Orders();
                Random rnd = new Random();
                int id = rnd.Next(100000, 999999);

                while (GetOrdersWithID(id.ToString()) != null)
                {
                    id = rnd.Next(100000, 999999);
                }

                newOrder.OrderID = id.ToString();
                newOrder.UserName = userName;
                newOrder.OrderPrice = 0;
                newOrder.OrderStatus = 1; // Ready order

                return createOrders(newOrder);
            }

            return true;
        }
        public static bool Orders_Update(Orders orders)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Orders_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", orders.OrderID);
                        command.Parameters.AddWithValue("@UserName", orders.UserName);
                        command.Parameters.AddWithValue("@OrderPrice", orders.OrderPrice);
                        command.Parameters.AddWithValue("@OrderStatus", orders.OrderStatus);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
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
        public static bool Orders_Delete(string OrderID)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Orders_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
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

    }
}
