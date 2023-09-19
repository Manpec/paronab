using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApplicationParonAB.Models;

namespace WebApplicationParonAB.Repositories
{
    public interface IProdukterRepository
    {
        Produkter GetById(string id);
        IEnumerable<Produkter> GetAll();
        IEnumerable<Produkter> Find(Expression<Func<Produkter, bool>> predicate);
        void Add(Produkter entity);
        void Update(Produkter entity);
        void Delete(Produkter entity);
    }
}
