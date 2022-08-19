﻿using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Commands.Users;

public class UpdateUserRolesCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateUserRolesCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public IEnumerable<int> RoleIds { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}