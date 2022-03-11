using Atarraya.Tests.One.Constants;

namespace Atarraya.Tests.One.Interface.Rejections
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