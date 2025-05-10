using Microsoft.Extensions.Logging;
using PetFamily.Core.Models;
using System.Linq.Expressions;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;
using TestingVGLTU.Core.Extentions;
using User = TestingVGLTU.Accounts.Domain.Entity.User;

namespace TestingVGLTU.Accounts.Application.Queries.GerUserWithPagination;

public class GetUserWithPaginationHandler 
    : IQueryHandler<PagedList<UserDto>, GetUserWithPaginationQuery>
{
    private readonly IReadAccountDbContext _readDbContext;
    private readonly ILogger<GetUserWithPaginationHandler> _logger;


    public GetUserWithPaginationHandler(
        IReadAccountDbContext readDbContext,
        ILogger<GetUserWithPaginationHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<PagedList<UserDto>> Handle(
        GetUserWithPaginationQuery query,
        CancellationToken cancellationToken = default)
    {
        var userQuery = _readDbContext.Users;

       
        Expression <Func<User, object>> keySelector = query.SortBy?.ToLower() switch
        {
            "login" => x => x.Login,
            _ => x => x.Id.Value
        };

        userQuery = query.SortDirection?.ToLower() switch
        {
            "asc" => userQuery.OrderBy(keySelector),
            "desc" => userQuery.OrderByDescending(keySelector),
            _ => userQuery
        };

        var pagedList = await userQuery.ToPagedList(
            query.Page,
            query.PageSize,
            x => new UserDto
            {
                Id = x.Id,
                Login = x.Login.Value ?? "",
                Name = x.FullName.FirstName,
                Surname = x.FullName.Surname,
                Patronymic = x.FullName.Patronymic ?? ""
            },
            cancellationToken);

        _logger.LogInformation(
            "Get users with pagination and filtration. Page: {Page}, PageSize: {PageSize}, TotalCount: {TotalCount}",
            query.Page,
            query.PageSize,
            pagedList.TotalCount);

        return pagedList;
    }
}