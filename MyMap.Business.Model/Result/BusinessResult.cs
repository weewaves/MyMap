namespace MyMap.Business.Model
{
    public class BusinessResult
    {
        public static BusinessResult Success()
        {
            return new BusinessResult();
        }

        public static BusinessResult Success(object returnValue)
        {
            return new BusinessResult(returnValue);
        }

        public static BusinessResult Error(string errorField, string message)
        {
            return new BusinessResult(errorField, message);
        }

        protected BusinessResult()
        {
            IsValid = true;
        }

        protected BusinessResult(object returnValue)
        {
            IsValid = true;
            ReturnValue = returnValue;
        }

        protected BusinessResult(string errorField, string message)
        {
            IsValid = false;
            ErrorField = errorField;
            Message = message;
        }

        public bool IsValid { get; protected set; }

        public string ErrorField { get; protected set; }

        public string Message { get; protected set; }

        public object ReturnValue { get; protected set; }
    }
}