using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class LibraryRepo : Repo, IRepo<Library, int, bool>
    {
        public bool Create(Library obj)
        {
            db.Librarys.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Librarys.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Library> Get()
        {
            return db.Librarys.ToList();
        }

        public Library Get(int id)
        {
            return db.Librarys.Find(id);
        }

        public bool Update(Library obj)
        {
            var exobj = Get(obj.ID);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
