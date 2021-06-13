using System.Collections.Generic;
using poo_exemple.Interfaces;

namespace poo_exemple
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public Serie getById(int id)
        {
            return listSerie[id];
        }

        public List<Serie> List()
        {
            return listSerie;
        }

        public int nextId()
        {
            return listSerie.Count;
        }

        public void save(Serie entity)
        {
            listSerie.Add(entity);
        }

        public void update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }

        public void delete(int id)
        {
            listSerie[id].remove();
        }
    }
}