using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Rooms.Queries.GetRoomById;

public record GetRoomByIdQuery(int Id)
    : IRequest<RoomDto?>;