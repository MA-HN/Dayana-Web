﻿using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Filters;

namespace Dayana.Shared.Persistence.Models.Identity.Requests;
public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class GetUserByFilterRequest : PaginationFilter
{
    protected GetUserByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetUserByFilterRequest()
    {
    }

    public string? Keyword { get; set; }
    public string? Email { get; set; }
    public List<UserState>? States { get; set; }
    public UserSortBy? SortBy { get; set; }
}

public class UpdateUserPasswordRequest
{
    public string NewPassword { get; set; }
    public string LastPassword { get; set; }
}

public class UpdateUserRequest
{
    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class UpdateUserRolesRequest
{
    public IEnumerable<string> RoleEids { get; set; }
}