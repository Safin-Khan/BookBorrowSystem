using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class BookRepo : Repo, IRepo<Book, int, bool>
    {
        public bool Create(Book obj)
        {
            db.Books.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Books.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public bool Update(Book obj)
        {
            var exobj = Get(obj.ID);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }

}
