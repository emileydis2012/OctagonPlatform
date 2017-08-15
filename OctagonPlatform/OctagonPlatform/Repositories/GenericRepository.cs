using Microsoft.AspNet.Identity;
using OctagonPlatform.Helpers;
using OctagonPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OctagonPlatform.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context = null;
        public DbSet<T> Table = null;

        protected GenericRepository()
        {
            this._context = new ApplicationDbContext();
            Table = _context.Set<T>();
        }

        protected GenericRepository(ApplicationDbContext db)
        {
            this._context = db;
            Table = db.Set<T>();
        }
        public IEnumerable<T> All()
        {
            return Table.ToList();
        }
        public T FindBy(object id)
        {
            return Table.Find(id);
        }
        public void Add(T obj)
        {
            Table.Add(obj);
            if (obj is IAuditEntity)
            {
                var date = DateTime.Now;
                var user = HttpContext.Current.User;
                var userid = user.Identity.GetUserId();
                (obj as IAuditEntity).CreatedAt = date;
                (obj as IAuditEntity).CreatedBy= userid;

            }
            Save();
        }
        public void Edit(T obj)
        {
            Table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            if (obj is IAuditEntity)
            {
                var date = DateTime.Now;
                var user = HttpContext.Current.User;
                var userid = user.Identity.GetUserId();
                (obj as IAuditEntity).CreatedAt = date;
                (obj as IAuditEntity).CreatedBy = userid;

            }
            Save();
        }
        public void Delete(object id)
        {
            var existing = Table.Find(id);
            if (existing is ISoftDeleted)
            {
                ((ISoftDeleted)existing).Deleted = true;
                if (existing is IAuditEntity)
                {
                    var date = DateTime.Now;
                    var user = HttpContext.Current.User;
                    var userid = user.Identity.GetUserId();
                    (existing as IAuditEntity).DeletedAt= date;
                    (existing as IAuditEntity).DeletedBy = userid;

                }

            }
            else
            {
                if (existing != null) Table.Remove(existing);
            }
            Save();
        }

        public void Save()
        {

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}