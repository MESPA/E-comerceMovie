using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Etiket.Data.Base;
using Etiket.Models;

namespace Etiket.Data.Services

{
    //hereda of the Interface IEntityBaseRepository
    public interface IActorsServices : IEntityBaseRepository<Actor>
    {
        //Task<IEnumerable<Actor>> GetAllAsync();

        //Task<Actor> GetByIdAsync(int id);

        //Task AddAsync(Actor actor);

        //Task<Actor> UpdateAsync(int id, Actor newActor);

        //Task DeleteAsync(int id);
    }
}

