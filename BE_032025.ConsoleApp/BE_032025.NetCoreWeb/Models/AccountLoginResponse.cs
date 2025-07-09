namespace BE_032025.NetCoreWeb.Models
{
    public class ReturnData
    {
        public int ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
    }

    public class AccountLoginResponse : ReturnData
    {
        public int AccountID { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? token { get; set; }

        public string? resfeshToken { get; set; }
    }
}
