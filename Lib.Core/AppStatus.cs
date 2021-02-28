namespace Lib.Core
{
    public enum AppStatus
    {
        // Generic public statuses (0 ... 99)
        // ----------------------------------------------------
        Ok = 0,
        Error = 1,
        Timeout = 2,
        NotFound = 3,
        BadRequest = 4,
        Unauthorized = 5,
        AlreadyExist = 6,
        AlreadyUsed = 7,
        UpdateRequired = 8,
        Redirect = 9,
        PaymentRequired = 10,
        NotImplemented = 11,
        ServiceUnavailable = 12,
        TooManyRequests = 13,
        MissingRequiredProperty = 14,
        InvalidPropertyLength = 15,
        OperationAlreadyPerformed = 16,
        OperationNotPermitted = 17,
        ConstraintViolation = 18,
        Expired = 19,

        // Common public data statuses (100 ... 999)
        // ----------------------------------------------------
        InvalidEmail = 100,
        InvalidDocumentNumber = 101,
        InvalidPhone = 102,
        UnsupportedPhoneCountry = 103,
        InvalidDateTime = 104,
        
        // Generic client statuses (1.000 ... 1.999)
        // ----------------------------------------------------
        RouteNotFound = 1_000,
        InvalidWebApiResponse = 1_001,

        // Back-end debug status (2.000 ... 2.499)
        // ----------------------------------------------------
        EmbeddedResourceNotFound = 2_000,
        InvalidCast = 2_001,
        BadSerialization = 2_002,
        UnknownEnumValue = 2_003,
        EnumValueNotAllowed = 2_004,
        
        // Front-end debug status (2.500 ... 2.599)
        // ----------------------------------------------------
        
        // Infrastructure statuses (3.000 ... 3.499)
        // ----------------------------------------------------
        InsufficientStorage = 3_000,
        PermissionDenied = 3_001,
        PathNotFound = 3_002,
        InternetRequired = 3_003,

        // Gateway statuses (2.500 ... 2.599)
        // ----------------------------------------------------
        SmtpServerConnectionError = 3_500,
        PostgreServerConnectionError = 3_501,
        RedisServerConnectionError = 3_502,
        ElasticsearchServerConnectionError = 3_503,

        // Database statuses (3.600 ... 2.799)
        // ----------------------------------------------------
        DatabaseError = 3_600,
        NotNullViolation = 3_601,
        ForeignKeyViolation = 3_602,
        UniqueViolation = 3_603,
        ExclusionViolation = 3_604,

        // Application statuses (100.000 ... N)
        // ----------------------------------------------------
        // ...
    }
}