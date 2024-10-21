namespace common
{
    public class ValidationResult
    {
        #region "Constructor"

        public ValidationResult(bool success)
        {
            this.Success = success;
        }

        public ValidationResult(bool success, string message, string property)
        {
            this.Success = success;
            this.Message = message;
            this.Property = property;
        }

        #endregion

        #region "Public Members"

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Property { get; set; }

        #endregion
    }
}
