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
    public class BookTypeRes
    {
        public static List<BookType> GetAllType()
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
                    using (SqlCommand command = new SqlCommand("Book_GetAllType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Tạo đối tượng SqlDataAdapter để đưa dữ liệu vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để lưu kết quả truy vấn
                            DataTable result = new DataTable();

                            // Điền dữ liệu vào DataTable
                            adapter.Fill(result);

                            // Chuyển đổi DataTable thành danh sách các đối tượng BookType
                            List<BookType> lstBookType = new List<BookType>();

                            if (result.Rows.Count > 0)
                            {
                                foreach (DataRow dr in result.Rows)
                                {
                                    BookType bookType = new BookType
                                    {
                                        BookTypeID = dr["BookTypeID"].ToString(),
                                        BookTypeName = dr["BookTypeName"].ToString(),
                                    };

                                    lstBookType.Add(bookType);
                                }
                            }

                            return lstBookType;
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


        public static BookType BookTypeWithID(string ID)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Book_BookTypeWithID", connection))
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
                                BookType bookType = new BookType
                                {
                                    // Assuming BookType has these properties, replace with actual properties if different
                                    BookTypeID = dr["BookTypeID"].ToString(),
                                    
                                };
                                return bookType;
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

            return null;
        }


    }
}
