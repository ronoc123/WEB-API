using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_Udemy.Dtos.Character;

namespace WEB_API_Udemy.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();

        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);

        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}