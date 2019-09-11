namespace MyMap.Business.Model
{
    public class BusinessResult<T> : BusinessResult
    {
        public static BusinessResult<T> Success(T returnValue)
        {
            return new BusinessResult<T>(returnValue);
        }

        public new static BusinessResult<T> Success()
        {   
            return new BusinessResult<T>();
        }

        protected BusinessResult()
        {
            IsValid = true;
            ReturnValue = default(T);
        }

        protected BusinessResult(T returnValue)
        {
            IsValid = true;
            ReturnValue = returnValue;
        }

        public BusinessResult(string errorField, string message) : base(errorField, message)
        {
        }
    }
}