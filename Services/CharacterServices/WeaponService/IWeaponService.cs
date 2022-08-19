using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_Udemy.Dtos.Character;
using WEB_API_Udemy.Dtos.Weapon;

namespace WEB_API_Udemy.Services.CharacterServices.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}