using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Reservations.Queries.GetReservationById;

public record GetReservationByIdQuery(int Id)
    : IRequest<ReservationDto?>;