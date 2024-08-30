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
    public class AccountRes
    {
        public static List<Account> GetAll()
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_GetAll", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            List<Account> lstResult = new List<Account>();
                            if (result.Rows.Count > 0)
                            {
                                foreach (DataRow dr in result.Rows)
                                {
                                    Account account = new Account
                                    {
                                        UserName = dr["UserName"].ToString(),
                                        Password = dr["Password"].ToString(),
                                        FullName = dr["FullName"].ToString(),
                                        Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : int.Parse(dr["Age"].ToString()),
                                        Gender = string.IsNullOrEmpty(dr["Gender"].ToString()) ? 0 : int.Parse(dr["Gender"].ToString()),
                                        Address = dr["Address"].ToString(),
                                        Email = dr["Email"].ToString(),
                                        Phone = "0" + dr["Phone"].ToString(),
                                        Authority = string.IsNullOrEmpty(dr["Authority"].ToString()) ? 0 : int.Parse(dr["Authority"].ToString())
                                    };
                                    lstResult.Add(account);
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
        public static Account CheckLogin(string userName, string password)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_GetWithUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                var acc = new Account
                                {
                                    UserName = result.Rows[0]["UserName"].ToString(),
                                    Password = result.Rows[0]["Password"].ToString()
                                };

                                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, acc.Password);
                                if (isValidPassword)
                                {
                                    acc.FullName = result.Rows[0]["FullName"].ToString();
                                    acc.Authority = string.IsNullOrEmpty(result.Rows[0]["Authority"].ToString()) ? 0 : int.Parse(result.Rows[0]["Authority"].ToString());
                                    return acc;
                                }
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
        public static Account GetAccountWithUser(string userName)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_GetWithUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                var acc = new Account
                                {
                                    UserName = result.Rows[0]["UserName"].ToString(),
                                    FullName = result.Rows[0]["FullName"].ToString(),
                                    Age = string.IsNullOrEmpty(result.Rows[0]["Age"].ToString()) ? 0 : int.Parse(result.Rows[0]["Age"].ToString()),
                                    Gender = string.IsNullOrEmpty(result.Rows[0]["Gender"].ToString()) ? 0 : int.Parse(result.Rows[0]["Gender"].ToString()),
                                    Email = result.Rows[0]["Email"].ToString(),
                                    Address = result.Rows[0]["Address"].ToString(),
                                    Phone = "0" + result.Rows[0]["Phone"].ToString(),
                                    Authority = string.IsNullOrEmpty(result.Rows[0]["Authority"].ToString()) ? 0 : int.Parse(result.Rows[0]["Authority"].ToString())
                                };

                                return acc;
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

            return new Account();
        }
        public static Account GetAccountWithEmail(string email)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_GetWithEmail", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                            {
                                var acc = new Account
                                {
                                    FullName = result.Rows[0]["FullName"].ToString(),
                                    Email = result.Rows[0]["Email"].ToString(),
                                    Address = result.Rows[0]["Address"].ToString(),
                                    Phone = "0" + result.Rows[0]["Phone"].ToString()
                                };

                                return acc;
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

            return new Account();
        }
        public static bool Account_Create(Account account)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_Create", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", account.UserName);
                        command.Parameters.AddWithValue("@Password", account.Password);
                        command.Parameters.AddWithValue("@FullName", account.FullName);
                        command.Parameters.AddWithValue("@Age", account.Age);
                        command.Parameters.AddWithValue("@Gender", account.Gender);
                        command.Parameters.AddWithValue("@Address", account.Address);
                        command.Parameters.AddWithValue("@Email", account.Email);
                        command.Parameters.AddWithValue("@Phone", account.Phone);
                        command.Parameters.AddWithValue("@Authority", account.Authority);

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
        public static bool Account_Update(Account account)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", account.UserName);
                        command.Parameters.AddWithValue("@FullName", account.FullName);
                        command.Parameters.AddWithValue("@Age", account.Age);
                        command.Parameters.AddWithValue("@Gender", account.Gender);
                        command.Parameters.AddWithValue("@Address", account.Address);
                        command.Parameters.AddWithValue("@Email", account.Email);
                        command.Parameters.AddWithValue("@Phone", account.Phone);
                        command.Parameters.AddWithValue("@Authority", account.Authority);

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
        public static bool Account_Delete(string userName)
        {
            try
            {
                string connectionString = "Server=LAPTOP-TEUAUUAE;Database=QLSTORE;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Account_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", userName);

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
