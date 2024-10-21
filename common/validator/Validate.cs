using System;

namespace common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class Validate : Attribute
    {
        #region "Constructor"

        public Validate(ValidationType validationMethod)
        {
            this.type = validationMethod;
        }

        #endregion

        #region "Public Members"

        public enum ValidationType
        {
            Email,
            String,
            Number,
            Date,
            ReferenceId,
            MobileNo,
            TelNo
        }

        private ValidationType type;

        public ValidationType Validation
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string ErrorMessage { get; set; }
        public string RegExPattern { get; set; }

        #endregion
    }
}
