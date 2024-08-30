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
    public class BookRes
    {
        public static List<Book> GetAll()
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);
                            List<Book> lstResult = new List<Book>();

                            if (result.Rows.Count > 0)
                            {
                                foreach (DataRow dr in result.Rows)
                                {
                                    Book book = new Book
                                    {
                                        BookID = dr["BookID"].ToString(),
                                        BookName = dr["BookName"].ToString(),
                                        BookTypeID = dr["BookTypeID"].ToString(),
                                        Author = dr["Author"].ToString(),
                                        Nxb = dr["Nxb"].ToString(),
                                        Description = dr["Description"].ToString(),
                                        Image = dr["Image"].ToString(),
                                        Price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString()),
                                        Quantity = string.IsNullOrEmpty(dr["Quantity"].ToString()) ? 0 : int.Parse(dr["Quantity"].ToString()),
                                        OrderedQuantity = string.IsNullOrEmpty(dr["OrderedQuantity"].ToString()) ? 0 : int.Parse(dr["OrderedQuantity"].ToString())
                                    };

                                    lstResult.Add(book);
                                }
                            }
                            return lstResult;
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



        public static List<Book> GetBookWithSelling()
        {
            try
            {
                // Cấu hình chuỗi kết nối SQL
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";

                // Tạo đối tượng SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand("Book_BookWithSelling", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Tạo đối tượng SqlDataAdapter để đưa dữ liệu vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để lưu kết quả truy vấn
                            DataTable result = new DataTable();

                            // Điền dữ liệu vào DataTable
                            adapter.Fill(result);

                            // Chuyển đổi DataTable thành danh sách các đối tượng Book
                            List<Book> lstResult = new List<Book>();

                            if (result.Rows.Count > 0)
                            {
                                foreach (DataRow dr in result.Rows)
                                {
                                    Book book = new Book
                                    {
                                        BookID = dr["BookID"].ToString(),
                                        BookName = dr["BookName"].ToString(),
                                        BookTypeID = dr["BookTypeID"].ToString(),
                                        Author = dr["Author"].ToString(),
                                        Nxb = dr["Nxb"].ToString(),
                                        Description = dr["Description"].ToString(),
                                        Image = dr["Image"].ToString(),
                                        Price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString()),
                                        Quantity = string.IsNullOrEmpty(dr["Quantity"].ToString()) ? 0 : int.Parse(dr["Quantity"].ToString()),
                                        OrderedQuantity = string.IsNullOrEmpty(dr["OrderedQuantity"].ToString()) ? 0 : int.Parse(dr["OrderedQuantity"].ToString())
                                    };

                                    lstResult.Add(book);
                                }
                            }

                            return lstResult;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Xử lý lỗi SQL
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                throw; // Ném lại lỗi để xử lý ở nơi khác nếu cần
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                Console.WriteLine("General Error: " + ex.Message);
                throw; // Ném lại lỗi để xử lý ở nơi khác nếu cần
            }
        }

        public static List<Book> GetTypeList(string ID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_GetTypeList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);
                            List<Book> lstResult = new List<Book>();

                            if (result.Rows.Count > 0)
                            {
                                foreach (DataRow dr in result.Rows)
                                {
                                    Book book = new Book
                                    {
                                        BookID = dr["BookID"] != DBNull.Value ? dr["BookID"].ToString() : string.Empty,
                                        BookName = dr["BookName"] != DBNull.Value ? dr["BookName"].ToString() : string.Empty,
                                        BookTypeID = dr["BookTypeID"] != DBNull.Value ? dr["BookTypeID"].ToString() : string.Empty,
                                        Author = dr["Author"] != DBNull.Value ? dr["Author"].ToString() : string.Empty,
                                        Nxb = dr["Nxb"] != DBNull.Value ? dr["Nxb"].ToString() : string.Empty,
                                        Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : string.Empty,
                                        Image = dr["Image"] != DBNull.Value ? dr["Image"].ToString() : string.Empty,
                                        Quantity = dr["Quantity"] != DBNull.Value ? Convert.ToInt32(dr["Quantity"]) : 0,
                                        OrderedQuantity = dr["OrderedQuantity"] != DBNull.Value ? Convert.ToInt32(dr["OrderedQuantity"]) : 0
                                    };
                                    lstResult.Add(book);
                                }
                            }
                            return lstResult;
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
        public static Book BookWithID(string ID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_BookWithID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                DataRow dr = result.Rows[0];
                                Book book = new Book
                                {
                                    BookID = dr["BookID"].ToString(),
                                    BookName = dr["BookName"].ToString(),
                                    BookTypeID = dr["BookTypeID"].ToString(),
                                    Author = dr["Author"].ToString(),
                                    Nxb = dr["Nxb"].ToString(),
                                    Description = dr["Description"].ToString(),
                                    Image = dr["Image"].ToString(),
                                    Price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString()),
                                    Quantity = string.IsNullOrEmpty(dr["Quantity"].ToString()) ? 0 : int.Parse(dr["Quantity"].ToString()),
                                    OrderedQuantity = string.IsNullOrEmpty(dr["OrderedQuantity"].ToString()) ? 0 : int.Parse(dr["OrderedQuantity"].ToString())
                                };
                                return book;
                            }
                        }
                    }
                }
                return null;
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
        public static int Book_Count()
        {
            return GetAll().Count;  // Ensure GetAll() is refactored to use SqlConnection
        }
        public static bool Book_CreateBook(Book book)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_CreateBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", book.BookID);
                        command.Parameters.AddWithValue("@BookName", book.BookName);
                        command.Parameters.AddWithValue("@BookTypeID", book.BookTypeID);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@Nxb", book.Nxb);
                        command.Parameters.AddWithValue("@Description", book.Description);
                        command.Parameters.AddWithValue("@Image", book.Image);
                        command.Parameters.AddWithValue("@Price", book.Price);
                        command.Parameters.AddWithValue("@Quantity", book.Quantity);
                        command.Parameters.AddWithValue("@OrderedQuantity", book.OrderedQuantity);

                        command.ExecuteNonQuery();
                        return true;
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
        public static bool Book_Update(Book book)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", book.BookID);
                        command.Parameters.AddWithValue("@BookName", book.BookName);
                        command.Parameters.AddWithValue("@BookTypeID", book.BookTypeID);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@Nxb", book.Nxb);
                        command.Parameters.AddWithValue("@Description", book.Description);
                        command.Parameters.AddWithValue("@Image", book.Image);
                        command.Parameters.AddWithValue("@Price", book.Price);
                        command.Parameters.AddWithValue("@Quantity", book.Quantity);
                        command.Parameters.AddWithValue("@OrderedQuantity", book.OrderedQuantity);

                        command.ExecuteNonQuery();
                        return true;
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
        public static bool Book_Delete(string ID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);

                        command.ExecuteNonQuery();
                        return true;
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
