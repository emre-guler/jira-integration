using FluentValidation;
using User.Applicaton.Exceptions;

namespace User.Applicaton.Extensions;

public static class FluentValidationExtensions
{
    public static void ThrowExceptionIfNotValid<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, dynamic customError)
    {
        throw new UserException(customError);
    }
}