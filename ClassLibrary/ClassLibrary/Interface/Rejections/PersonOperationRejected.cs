
using ClassLibrary.Constants;

namespace ClassLibrary.Interface.Rejections
{
    public class PersonOperationRejected : OperationResult
    {
        public PersonErrorCode ErrorCode { get; set; }
        public PersonOperationRejected(PersonErrorCode errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}