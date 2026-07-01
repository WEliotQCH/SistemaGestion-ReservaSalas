using MediatR;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Commands.AssignScheduleToRoom;

public record AssignScheduleToRoomCommand(
    int RoomId,
    int ScheduleId
) : IRequest<bool>;