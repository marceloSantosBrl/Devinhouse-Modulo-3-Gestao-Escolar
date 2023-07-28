using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Models;

namespace GestaoEscolar_M3S01.Mappings;

public interface IUserMapping
{
    public User UserRequestToEntity(UserRequest request);
}