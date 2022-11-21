using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Etiket.Data.Base;
using Etiket.Models;
using Microsoft.EntityFrameworkCore;

namespace Etiket.Data.Services
{
    public class ProducersServices : EntityBaseRepository<Producer>, IProducersServices
    {

        public ProducersServices(AppDbContext appdbContext) : base(appdbContext)
        {

        }

        //private readonly AppDbContext _appContext;

        //public ActorsServices(AppDbContext appContext)
        //{
        //    _appContext = appContext;
        //}

        //public async Task AddAsync(Actor actor)
        //{
        //    await _appContext.Actors.AddAsync(actor);
        //    await _appContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync (int id)
        //{
        //    var result = await _appContext.Actors.FirstOrDefaultAsync(d => d.Id == id);
        //     _appContext.Actors.Remove(result);
        //    await _appContext.SaveChangesAsync();

        //    return;
        //}



        //public async Task<Actor> UpdateAsync(int id, Actor newActor)
        //{
        //    _appContext.Actors.Update(newActor);
        //   await _appContext.SaveChangesAsync();
        //    return newActor;
        //}
    }
}

