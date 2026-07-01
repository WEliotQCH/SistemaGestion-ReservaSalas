using MediatR;

namespace SistemaReservasSalas.Application.Features.Reservations.Commands.CancelReservation;

public record CancelReservationCommand(int Id)
    : IRequest<bool>;