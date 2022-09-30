using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class BaseRepository<TEntity, Tkey> where TEntity : class
    {
        protected readonly DevInCarDbContext _context;
        public BaseRepository(DevInCarDbContext context)
        {
            _context = context;
        }

        public virtual IList<TEntity> ObterTodos(){
            return _context.Set<TEntity>().ToList();
        }
        public virtual void Inserir(TEntity entity){
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();  
        }
        public virtual void Atualizar(TEntity entity){
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges(); 
        }
        public virtual TEntity ObterPorID(Tkey id){
            return _context.Set<TEntity>().Find(id);
        }
        public virtual void Excluir(TEntity entity){
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges(); 

        }
    }
}