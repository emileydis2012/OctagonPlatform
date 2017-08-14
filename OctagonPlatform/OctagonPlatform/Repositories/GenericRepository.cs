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
            if (obj is AuditEntity)
            {
                var date = DateTime.Now;
                var user = HttpContext.Current.User;
                var userid = user.Identity.GetUserId();
                (obj as AuditEntity).CreatedAt = date;
                (obj as AuditEntity).CreatedBy= userid;

            }
            Save();
        }
        public void Edit(T obj)
        {
            Table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            if (obj is AuditEntity)
            {
                var date = DateTime.Now;
                var user = HttpContext.Current.User;
                var userid = user.Identity.GetUserId();
                (obj as AuditEntity).CreatedAt = date;
                (obj as AuditEntity).CreatedBy = userid;

            }
            Save();
        }
        public void Delete(object id)
        {
            var existing = Table.Find(id);
            if (existing is ISoftDeleted)
            {
                ((ISoftDeleted)existing).Deleted = true;
                if (existing is AuditEntity)
                {
                    var date = DateTime.Now;
                    var user = HttpContext.Current.User;
                    var userid = user.Identity.GetUserId();
                    (existing as AuditEntity).DeletedAt= date;
                    (existing as AuditEntity).DeletedBy = userid;

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