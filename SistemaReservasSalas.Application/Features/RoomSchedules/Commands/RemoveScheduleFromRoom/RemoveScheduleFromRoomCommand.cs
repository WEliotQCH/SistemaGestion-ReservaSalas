using MediatR;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Commands.RemoveScheduleFromRoom;

public record RemoveScheduleFromRoomCommand(
    int RoomId,
    int ScheduleId
) : IRequest<bool>;