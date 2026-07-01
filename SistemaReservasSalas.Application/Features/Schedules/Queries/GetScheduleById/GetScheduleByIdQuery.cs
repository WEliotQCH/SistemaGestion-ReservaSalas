using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Schedules.Queries.GetScheduleById;

public record GetScheduleByIdQuery(int Id)
    : IRequest<ScheduleDto?>;