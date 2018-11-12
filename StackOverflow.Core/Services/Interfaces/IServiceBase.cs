using System.Collections.Generic;

namespace StackOverflow.Core.Services.Interfaces
{
    public interface IServiceBase<TClass> where TClass : class
    {
        void Incluir(TClass obj);

        void Alterar(TClass obj);

        void Excluir(TClass obj);

        TClass Pesquisar(int id);

        IEnumerable<TClass> PesquisarTodos();
    }
}
