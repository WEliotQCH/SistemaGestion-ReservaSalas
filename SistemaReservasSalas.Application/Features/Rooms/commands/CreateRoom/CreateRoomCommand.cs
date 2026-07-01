using MediatR;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string Name,
    string Location,
    int Capacity,
    string? Description
) : IRequest<int>;