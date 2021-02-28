namespace dotnetex.shared.Errors
{
    public class APIError
    {
        private int status_code = 500;
        private string message = "";

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