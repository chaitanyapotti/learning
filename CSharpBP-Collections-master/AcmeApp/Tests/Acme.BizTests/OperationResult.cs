namespace Acme.Biz.Tests
{
    internal class OperationResult<T>
    {
        private bool success;
        private string message;

        public OperationResult(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}