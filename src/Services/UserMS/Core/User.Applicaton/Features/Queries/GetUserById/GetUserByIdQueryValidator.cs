using FluentValidation;
using User.Applicaton.Exceptions;
using User.Applicaton.Extensions;
using User.Applicaton.Helpers;

namespace User.Applicaton.Features.Queries.GetUserById;
public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .Must(GuidHelper.IsGuid)
            .WithError("id_invalid", "Id must be valid!");
    }
}