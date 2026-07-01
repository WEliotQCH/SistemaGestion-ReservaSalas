using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Users.Queries.GetUsers;

public record GetUsersQuery : IRequest<List<UserDto>>;