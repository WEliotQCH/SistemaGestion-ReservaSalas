using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Reservations.Queries.GetReservations;

public record GetReservationsQuery
    : IRequest<List<ReservationDto>>;