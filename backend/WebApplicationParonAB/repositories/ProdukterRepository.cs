using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplicationParonAB.Data;
using WebApplicationParonAB.Models;

namespace WebApplicationParonAB.Repositories
{
    public class ProdukterRepository : IProdukterRepository
    {
        private readonly DataContext _context;

        public ProdukterRepository(DataContext context)
        {
            _context = context;
        }

        public Produkter GetById(string id)
        {
            return _context.Produkter.Find(id);
        }

        public IEnumerable<Produkter> GetAll()
        {
            return _context.Produkter.ToList();
        }

        public IEnumerable<Produkter> Find(Expression<Func<Produkter, bool>> predicate)
        {
            return _context.Produkter.Where(predicate);
        }

        public void Add(Produkter entity)
        {
            _context.Produkter.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Produkter entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Produkter entity)
        {
            _context.Produkter.Remove(entity);
            _context.SaveChanges();
        }
    }
}