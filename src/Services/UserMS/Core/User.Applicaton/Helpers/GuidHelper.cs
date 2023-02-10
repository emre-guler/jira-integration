namespace User.Applicaton.Helpers;

public static class GuidHelper
{
    public static bool IsGuid(Guid value)
    {
        return Guid.TryParse(value.ToString(), out Guid result);
    }
}