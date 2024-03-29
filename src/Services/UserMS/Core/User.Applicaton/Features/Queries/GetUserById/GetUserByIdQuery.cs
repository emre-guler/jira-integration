﻿using MediatR;
using User.Applicaton.Intefaces.Repositories;
using User.Applicaton.ViewModels;
using User.Applicaton.Wrappers;

namespace User.Applicaton.Features.Queries.GetUserById;

public record GetUserByIdQuery : IRequest<ServiceResponse<UserViewModel>>
{
    public required Guid Id { get; init; }
}