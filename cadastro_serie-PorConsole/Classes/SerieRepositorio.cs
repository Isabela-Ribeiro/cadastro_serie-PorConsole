using System;
using System.Collections.Generic;
using DIO.series.Interfaces;

namespace DIO.series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaDeSerie = new List<Serie>();
        public void Atualiza(int id,Serie entidades)
        {
            listaDeSerie[id] = entidades;
        }

        public void Excluir(int id)
        {
            listaDeSerie[id].exclui();
        }

        public void Insere(Serie entidade)
        {
            listaDeSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaDeSerie;
        }

        public int ProximoId()
        {
            return listaDeSerie.Count;
        }

        public Serie RetornaPorID(int id)
        {
            return listaDeSerie[id];
        }
    }
}