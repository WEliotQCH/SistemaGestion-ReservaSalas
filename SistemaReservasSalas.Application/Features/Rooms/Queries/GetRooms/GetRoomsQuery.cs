using MediatR;
using SistemaReservasSalas.Application.DTOs;

namespace SistemaReservasSalas.Application.Features.Rooms.Queries.GetRooms;

public record GetRoomsQuery
    : IRequest<List<RoomDto>>;