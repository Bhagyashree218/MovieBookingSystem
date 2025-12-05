namespace Kemar.MBS.Model.Common
{
    public enum ResultCode
    {
        Success = 200,
        SuccessfullyCreated = 201,
        SuccessfullyUpdated = 202,

        Invalid = 400,
        Unauthorized = 401,
        DuplicateRecord = 409,

        RecordNotFound = 404,
        NotAllowed = 403,

        ExceptionThrown = 500
    }
}
