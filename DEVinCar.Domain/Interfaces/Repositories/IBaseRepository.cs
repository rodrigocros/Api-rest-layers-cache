using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey> where TEntity : class
    {
        IList<TEntity> ObterTodos();
        TEntity ObterPorID(int id);
        void Inserir(TEntity entity);
        void Excluir (TEntity entity);
        void Atualizar(TEntity entity);
    }
}