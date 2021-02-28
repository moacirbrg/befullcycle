namespace Lib.Core
{
    public static class AppStatusUtils
    {
        public static AppStatus ConvertToPublicStatus(AppStatus status)
        {
            switch (status)
            {
                case AppStatus.NotNullViolation: return AppStatus.BadRequest;
                case AppStatus.ForeignKeyViolation: return AppStatus.ConstraintViolation;
                case AppStatus.UniqueViolation: return AppStatus.AlreadyExist;
                case AppStatus.ExclusionViolation: return AppStatus.OperationNotPermitted;

                default:
                    int code = (int) status;
                    return code < 2000 ? status : AppStatus.Error;
            }
        }
    }
}