﻿using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Models.Identity.Requests;
public class CreateRoleRequest
{
    public string Title { get; set; }
    public IList<string> PermissionEids { get; set; }
}

public record GetRolesByFilterRequest : DefaultPaginationFilter
{
    protected GetRolesByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetRolesByFilterRequest()
    {
    }
    public List<string>? PermissionEids { get; set; }
}

public class UpdateRoleRequest
{
    public string Title { get; set; }
    public IList<string> PermissionEids { get; set; }
}