using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class BorrowingRepo : Repo, IRepo<Borrowing, int, bool>, SRepo<string,List<Book>>,UidRepo
    {
        public bool Create(Borrowing obj)
        {
            db.Borrowings.Add(obj);
           return db.SaveChanges() > 0;
            
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Borrowings.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Borrowing> Get()
        {
            return db.Borrowings.ToList();
        }

        public Borrowing Get(int id)
        {
            return db.Borrowings.Find(id);
        }
        public List<Borrowing> GetbyUid(int id)
        {
            return db.Borrowings.Where(p => p.UserID == id).ToList();
        }
        public bool Update(Borrowing obj)
        {
            var exobj = Get(obj.ID);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Book> Search(string str)
        {
            
            return db.Books.Where(p => p.Title.Contains(str)).ToList();
        }

       




        /*public Borrowing GetByUserId(int id)
{
   return db.Borrowings.SingleOrDefault(x => x.BookID.Equals(id));

}

public List<Borrowing> GetAllByUserId(int id)
{
   return db.Borrowings.Where(x => x.BookID.Equals(id)).ToList();
}*/
    }
}
