using MediatR;

namespace SistemaReservasSalas.Application.Features.Rooms.Commands.DeactivateRoom;

public record DeactivateRoomCommand(int Id)
    : IRequest<bool>;