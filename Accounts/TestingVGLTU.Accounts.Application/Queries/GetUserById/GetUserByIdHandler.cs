using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestingVGLTU.Core.Abstractions;
using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.Accounts.Application.Queries.GetUserById;

public class GetUserByIdHandler : IQueryHandler<UserDto?, GetUserByIdQuery>
{
    private readonly IReadAccountDbContext _readDbContext;
    private readonly ILogger<GetUserByIdHandler> _logger;


    public GetUserByIdHandler(
        IReadAccountDbContext readDbContext,
        ILogger<GetUserByIdHandler> logger)
    {
        _readDbContext = readDbContext;
        _logger = logger;
    }

    public async Task<UserDto?> Handle(
        GetUserByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var user = await _readDbContext.Users
            .Include(u => u.Student)
            .Include(u => u.Teacher)
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        _logger.LogInformation("Get user by id {Id}", query.Id);

        if (user is null)
            return null;

        var userDto = new UserDto
        {
            Id = user.Id,
            Login = user.Login.Value ?? "",
            Name = user.FullName.FirstName,
            Surname = user.FullName.Surname,
            Patronymic = user.FullName.Patronymic ?? "",
            Student = user.Student is not null
                ? new StudentDto
                {
                    GroupId = user.Student.GroupId
                }
                : null,
            Teacher = user.Teacher is not null
                ? new TeacherDto() : null,
        };
        
        return userDto;
    }
}