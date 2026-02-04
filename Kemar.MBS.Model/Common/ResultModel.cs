namespace Kemar.MBS.Model.Common
{
    public class ResultModel
    {
        public ResultCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static ResultModel Success(object data = null, string message = "Success")
        {
            return new ResultModel { StatusCode = ResultCode.Success, Data = data, Message = message };
        }

        public static ResultModel Created(object data = null, string message = "Created Successfully")
        {
            return new ResultModel { StatusCode = ResultCode.SuccessfullyCreated, Data = data, Message = message };
        }

        public static ResultModel Updated(object data = null, string message = "Updated Successfully")
        {
            return new ResultModel { StatusCode = ResultCode.SuccessfullyUpdated, Data = data, Message = message };
        }

        public static ResultModel NotFound(string message = "Not Found")
        {
            return new ResultModel { StatusCode = ResultCode.RecordNotFound, Message = message };
        }

        public static ResultModel Duplicate(string message = "Duplicate Record")
        {
            return new ResultModel { StatusCode = ResultCode.DuplicateRecord, Message = message };
        }

        public static ResultModel Invalid(string message = "Invalid Request")
        {
            return new ResultModel { StatusCode = ResultCode.Invalid, Message = message };
        }

        public static ResultModel Error(string message = "Exception Thrown")
        {
            return new ResultModel { StatusCode = ResultCode.ExceptionThrown, Message = message };
        }

        public static ResultModel Unauthorized(string message = "Unauthorized")
        {
            return new ResultModel { StatusCode = ResultCode.Unauthorized, Message = message, Data = null};
        }
    }
}
