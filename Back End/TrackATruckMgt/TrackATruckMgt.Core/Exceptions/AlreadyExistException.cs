

using static TrackATruckMgt.Core.Utility.Constants;

namespace TrackATruckMgt.Core.Exceptions
{
    public class AlreadyExistException : BaseException
    {
        public AlreadyExistException(string message) : base(message)
        {
            Code = ResponseCodes.AlreadyExist;
            httpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        public AlreadyExistException(string message, string[] errors) : base(message)
        {
            Code = ResponseCodes.AlreadyExist; ;
            httpStatusCode = System.Net.HttpStatusCode.BadRequest;
            Errors = errors;
        }
    }
}
