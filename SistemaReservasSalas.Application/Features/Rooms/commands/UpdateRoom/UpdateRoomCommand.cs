using MediatR;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(
    int Id,
    string Name,
    string Location,
    int Capacity,
    string? Description
) : IRequest<bool>;