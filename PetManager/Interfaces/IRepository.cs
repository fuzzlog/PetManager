using PetManager.Managers;
using PetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetManager.Interfaces
{
    public interface IRepository
    {
        List<T> GetEntitiesByIdList<T>(List<int> ids) where T : class;
        //List<T> GetEntitiesByParameter<T>(Func<T, bool> predicate) where T : class;
        List<T> GetEntitiesByStatusList<T>(List<PetStatus> status) where T : class;
        int SaveNewEntity<T>(T newEntity) where T : class;
    }
}
