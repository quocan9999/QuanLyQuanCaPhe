using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyQuanCaPhe
{
    /// <summary>
    /// Lớp DataProvider sử dụng Singleton pattern để quản lý kết nối cơ sở dữ liệu
    /// Đảm bảo chỉ có một kết nối duy nhất trong toàn bộ ứng dụng
    /// </summary>
    public sealed class DataProvider
    {
        private static readonly object lockObject = new object();
        private static DataProvider instance;
        private readonly string connectionString;

        // Constructor private để đảm bảo Singleton pattern
        private DataProvider()
        {
            connectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = QuanLyCaPhe; Integrated Security = True; TrustServerCertificate = True";
        }

        /// <summary>
        /// Thuộc tính để lấy instance duy nhất của DataProvider
        /// </summary>
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DataProvider();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Tạo và trả về SqlConnection mới
        /// </summary>
        /// <returns>SqlConnection object</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Kiểm tra kết nối cơ sở dữ liệu
        /// </summary>
        /// <returns>True nếu kết nối thành công, False nếu thất bại</returns>
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SQL và trả về số dòng bị ảnh hưởng (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">Câu lệnh SQL</param>
        /// <param name="parameters">Tham số SQL (tùy chọn)</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thực thi câu lệnh SQL: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SQL và trả về giá trị đơn (COUNT, SUM, etc.)
        /// </summary>
        /// <param name="query">Câu lệnh SQL</param>
        /// <param name="parameters">Tham số SQL (tùy chọn)</param>
        /// <returns>Giá trị đơn từ cơ sở dữ liệu</returns>
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thực thi câu lệnh SQL: {ex.Message}", ex);
            }
        }
        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về DataTable
        /// </summary>
        /// <param name="query">Câu lệnh SQL SELECT</param>
        /// <param name="parameters">Tham số SQL (tùy chọn)</param>
        /// <returns>DataTable chứa kết quả</returns>
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thực thi câu lệnh SQL: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về SqlDataReader (cần dispose manual)
        /// </summary>
        /// <param name="query">Câu lệnh SQL SELECT</param>
        /// <param name="parameters">Tham số SQL (tùy chọn)</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null)
        {
            try
            {
                var connection = GetConnection();
                connection.Open();
                var command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                // CommandBehavior.CloseConnection đảm bảo connection đóng khi reader được dispose
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thực thi câu lệnh SQL: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lấy connection string hiện tại
        /// </summary>
        public string ConnectionString => connectionString;
    }
}