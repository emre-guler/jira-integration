using FluentValidation;
using User.Applicaton.Extensions;

namespace User.Applicaton.Features.Queries.GetAllUsers;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
        RuleFor(x => x.PageSize)
            .GreaterThan(1)
            .WithError("pagesize_must_bigger", "Page size must be greater than 1!")
            .LessThan(51)
            .WithError("pagesize_must_smaller", "Page size must be less than 51!");
    }
}