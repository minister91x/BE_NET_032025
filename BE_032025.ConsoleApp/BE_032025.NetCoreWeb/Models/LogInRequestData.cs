namespace BE_032025.NetCoreWeb.Models
{
    public class LogInRequestData
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? DeviceID { get; set; } // Thêm DeviceID nếu cần thiết
    }
}
