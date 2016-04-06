namespace GroupDocsComparisonMvcDemo.Response
{
    public enum ResponseCode
    {
        Ok,
        Failed,
        InvalidCall,
        InvalidMethod,
        InvalidUser,
        InvalidKey,
        QuotaExceeded,
        StorageLimitExceeded,
        FileSizeExceeded,
        AccountClosed,
        Unauthorized,
        PasswordMismatch,
        PasswordNotSet
    }
}