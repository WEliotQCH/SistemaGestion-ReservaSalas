namespace SistemaReservasSalas.Domain.Exceptions;

public class ReservationConflictException : DomainException
{
    public ReservationConflictException()
        : base("La sala ya se encuentra reservada en el horario seleccionado.")
    {
    }
}