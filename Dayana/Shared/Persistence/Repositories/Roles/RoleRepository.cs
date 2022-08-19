﻿using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Persistence.Extensions.Identity;
using Dayana.Shared.Persistence.Interfaces.Repositories;
using Dayana.Shared.Persistence.Models.Filters.Roles;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.Repositories.Roles;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    private readonly IQueryable<Role> _queryable;

    public RoleRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<Role>();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await _queryable
            .Include(x => x.RolePermission)
            .ThenInclude(x => x.Permission)
            .SingleOrDefaultAsync(x => x.Id == id) ?? new Role();
    }

    public async Task<List<Role>> GetRolesByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;

        query = query.AsNoTracking()
            .Include(x => x.RolePermission)
            .ThenInclude(x => x.Permission);

        // Filter by ids
        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        query = query.ApplySort(RoleSortBy.CreationDate);

        return await query.ToListAsync();
    }

    public async Task<List<Role>> GetRolesByFilterAsync(RoleFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        if (filter.Include != null)
        {
            if (filter.Include.Permission)
                query = query.Include(x => x.RolePermission)
                    .ThenInclude(x => x.Permission);

            if (filter.Include.UserRole)
                query = query.Include(x => x.UserRoles);
        }

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<int> CountRolesByFilterAsync(RoleFilter filter)
    {
        var query = _queryable;

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }
}