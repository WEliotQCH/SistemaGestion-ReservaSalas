using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Schedules.Queries.GetSchedules;

public record GetSchedulesQuery
    : IRequest<List<ScheduleDto>>;