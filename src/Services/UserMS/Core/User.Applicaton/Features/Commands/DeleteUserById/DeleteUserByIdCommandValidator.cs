using FluentValidation;
using User.Applicaton.Extensions;
using User.Applicaton.Helpers;

namespace User.Applicaton.Features.Commands.DeleteUserById;

public class DeleteUserByIdCommandValidator : AbstractValidator<DeleteUserByIdCommand>
{
    public DeleteUserByIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .Must(GuidHelper.IsGuid)
            .WithError("id_invalid", "Id must be valid!");
    }
}

