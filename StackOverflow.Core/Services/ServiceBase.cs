using StackOverflow.Core.Contexts;
using StackOverflow.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflow.Core.Services
{
    public class ServiceBase<TClass> : IServiceBase<TClass> where TClass : class
    {
        protected StackOverflowContext db = new StackOverflowContext();

        public void Incluir(TClass obj)
        {
            db.Set<TClass>().Add(obj);
            db.SaveChanges();
        }
        public void Alterar(TClass obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(TClass obj)
        {
            db.Set<TClass>().Add(obj);
            db.SaveChanges();
        }

        public TClass Pesquisar(int id)
        {
            return db.Set<TClass>().Find(id);
        }

        public IEnumerable<TClass> PesquisarTodos()
        {
            return db.Set<TClass>().ToList();
        }
    }
}
