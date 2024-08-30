using CAIT.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WedStore.Const;
using WedStore.Models;

namespace WedStore.Repositories
{
    public class InfoOrderRes
    {
        public static bool InfoOrder_Create(InfoOrder infoOrder)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_Create", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InfoOrderID", infoOrder.InfoOrderID);
                        command.Parameters.AddWithValue("@OrderID", infoOrder.OrderID);
                        command.Parameters.AddWithValue("@Name", infoOrder.Name);
                        command.Parameters.AddWithValue("@Email", infoOrder.Email);
                        command.Parameters.AddWithValue("@Phone", infoOrder.Phone);
                        command.Parameters.AddWithValue("@Address", infoOrder.Address);
                        command.Parameters.AddWithValue("@TotalPrice", infoOrder.TotalPrice);
                        command.Parameters.AddWithValue("@Status", infoOrder.Status);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
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
        }

        public static bool InfoOrder_create(InfoOrder infoOrder)
        {
            string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_Create", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InfoOrderID", infoOrder.InfoOrderID);
                        command.Parameters.AddWithValue("@OrderID", infoOrder.OrderID);
                        command.Parameters.AddWithValue("@Name", infoOrder.Name);
                        command.Parameters.AddWithValue("@Email", infoOrder.Email);
                        command.Parameters.AddWithValue("@Phone", infoOrder.Phone);
                        command.Parameters.AddWithValue("@Address", infoOrder.Address);
                        command.Parameters.AddWithValue("@TotalPrice", infoOrder.TotalPrice);
                        command.Parameters.AddWithValue("@Status", infoOrder.Status);

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

        public static InfoOrder InfoOrder_GetInfoOrdersWithID(string id)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_GetInfoOrdersWithID", connection))
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
                                return new InfoOrder
                                {
                                    InfoOrderID = dr["InfoOrderID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Phone = dr["Phone"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    TotalPrice = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) ? 0 : int.Parse(dr["TotalPrice"].ToString()),
                                    Status = string.IsNullOrEmpty(dr["Status"].ToString()) ? 0 : int.Parse(dr["Status"].ToString())
                                };
                            }
                            return null;
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
        }
        public static InfoOrder InfoOrder_GetInfoOrdersWithOrderID(string id)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_GetInfoOrderWithOrderID", connection))
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
                                return new InfoOrder
                                {
                                    InfoOrderID = dr["InfoOrderID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Phone = dr["Phone"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    TotalPrice = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) ? 0 : int.Parse(dr["TotalPrice"].ToString()),
                                    Status = string.IsNullOrEmpty(dr["Status"].ToString()) ? 0 : int.Parse(dr["Status"].ToString())
                                };
                            }
                            return null;
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
        }
        public static List<InfoOrder> InfoOrder_GetInfoOrderWithEmail(string email)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_GetInfoOrderWithEmail", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            List<InfoOrder> lstInfoOrder = new List<InfoOrder>();
                            foreach (DataRow dr in result.Rows)
                            {
                                lstInfoOrder.Add(new InfoOrder
                                {
                                    InfoOrderID = dr["InfoOrderID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Phone = dr["Phone"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    TotalPrice = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) ? 0 : int.Parse(dr["TotalPrice"].ToString()),
                                    Status = string.IsNullOrEmpty(dr["Status"].ToString()) ? 0 : int.Parse(dr["Status"].ToString())
                                });
                            }
                            return lstInfoOrder;
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
        }
        public static List<InfoOrder> InfoOrder_GetAll()
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            List<InfoOrder> lstInfoOrder = new List<InfoOrder>();
                            foreach (DataRow dr in result.Rows)
                            {
                                lstInfoOrder.Add(new InfoOrder
                                {
                                    InfoOrderID = dr["InfoOrderID"].ToString(),
                                    OrderID = dr["OrderID"].ToString(),
                                    Name = dr["Name"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Phone = dr["Phone"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    TotalPrice = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) ? 0 : int.Parse(dr["TotalPrice"].ToString()),
                                    Status = string.IsNullOrEmpty(dr["Status"].ToString()) ? 0 : int.Parse(dr["Status"].ToString())
                                });
                            }
                            return lstInfoOrder;
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
        }
        public static bool InfoOrder_Delete(string infoOrderID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InfoOrderID", infoOrderID);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
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
        }
        public static bool InfoOrder_Update(InfoOrder infoOrder)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InfoOrder_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@InfoOrderID", infoOrder.InfoOrderID);
                        command.Parameters.AddWithValue("@OrderID", infoOrder.OrderID);
                        command.Parameters.AddWithValue("@Name", infoOrder.Name);
                        command.Parameters.AddWithValue("@Email", infoOrder.Email);
                        command.Parameters.AddWithValue("@Phone", infoOrder.Phone);
                        command.Parameters.AddWithValue("@Address", infoOrder.Address);
                        command.Parameters.AddWithValue("@TotalPrice", infoOrder.TotalPrice);
                        command.Parameters.AddWithValue("@Status", infoOrder.Status);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
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
        }

    }
}
