using MediatR;
using SistemaReservasSalas.Domain.Entities;
using SistemaReservasSalas.Domain.Exceptions;
using SistemaReservasSalas.Domain.Interfaces.IRepositories;

namespace SistemaReservasSalas.Application.Features.Reservations.Commands.CreateReservation;

public class CreateReservationHandler
    : IRequestHandler<CreateReservationCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationHandler(
        IUserRepository userRepository,
        IRoomRepository roomRepository,
        IReservationRepository reservationRepository)
    {
        _userRepository = userRepository;
        _roomRepository = roomRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<int> Handle(
        CreateReservationCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new DomainException("El usuario no existe.");

        var room = await _roomRepository.GetByIdAsync(request.RoomId);

        if (room is null)
            throw new DomainException("La sala no existe.");

        var existsConflict =
            await _reservationRepository.ExistsConflictAsync(
                request.RoomId,
                request.Date,
                request.StartTime,
                request.EndTime);

        if (existsConflict)
            throw new ReservationConflictException();

        var reservation = new Reservation(
            request.UserId,
            request.RoomId,
            request.Date,
            request.StartTime,
            request.EndTime,
            request.Reason);

        await _reservationRepository.AddAsync(reservation);

        return reservation.Id;
    }
}