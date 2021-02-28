namespace dotnetex.shared.Errors
{
    public class APIError
    {
        public System.DateTime timestamp { get; set; } = System.DateTime.Now;
        public int status_code { get; set; } = 500;
        public string message { get; set; } = "";

        public APIError()
        {
        }
        public APIError(int status_code, string message)
        {
            this.status_code = status_code;
            this.message = message;
        }
    }
}