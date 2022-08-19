using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_Udemy.Data;
using WEB_API_Udemy.Dtos.Fight;

namespace WEB_API_Udemy.Services.FightService
{
    public interface IFightService
    {
       

        public Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);

    }
}