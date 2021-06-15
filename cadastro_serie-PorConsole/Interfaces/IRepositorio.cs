using System.Collections.Generic;

namespace DIO.series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorID(int id);
        void Insere(T entidade);
        void Excluir(int id);
        void  Atualiza(int id, T entidade);
        int ProximoId();
         
    }
}