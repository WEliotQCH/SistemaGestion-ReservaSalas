using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Queries.GetRoomsBySchedule;

public record GetRoomsByScheduleQuery(
    int ScheduleId
) : IRequest<List<RoomDto>>;