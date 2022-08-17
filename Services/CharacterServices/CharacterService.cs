using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_API_Udemy.Data;
using WEB_API_Udemy.Dtos.Character;

namespace WEB_API_Udemy.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {

        public static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

     
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                Character character = await _context.Characters.FirstAsync(c => c.Id == id);

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                
            } 
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id); 
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);

            return serviceResponse; 
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
           var serviceResponse = new ServiceResponse<GetCharacterDto>();

           try{
           var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

            // creates a new character with the values provided, if vbalues are missing it uses the default class values and fills in the rest

            // This code take in the new values and updates them.  The unchaged values remain the same and the character continues.

           character.Name = updatedCharacter.Name;
           character.HitPoints = updatedCharacter.HitPoints;
           character.Strength = updatedCharacter.Strength;
           character.Defense = updatedCharacter.Defense;
           character.Class = updatedCharacter.Class;

           await _context.SaveChangesAsync();

           serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
           } catch(Exception ex){
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
           }
           return serviceResponse;
        }

  
    }
}