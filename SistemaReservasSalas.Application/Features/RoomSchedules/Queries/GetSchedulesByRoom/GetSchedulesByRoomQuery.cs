using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.RoomSchedules.Queries.GetSchedulesByRoom;

public record GetSchedulesByRoomQuery(
    int RoomId
) : IRequest<List<ScheduleDto>>;