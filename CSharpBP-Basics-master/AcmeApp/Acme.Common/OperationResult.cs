namespace Acme.Common
{
    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    public class OperationResult
    {
        private OperationResult()
        {
        }

        private OperationResult(bool success, string message) : this()
        {
            this.Success = success;
            this.Message = message;
        }
        private static OperationResult myVar;

        public static OperationResult MyProperty
        {
            get
            {
                if (null == myVar)
                    myVar = new OperationResult();
                return myVar;
            }
            set { myVar = value; }
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
